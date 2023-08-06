using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainManager : MonoBehaviour
{
    //Temp List//
    private bool isDraw = true;


    private Transform mRoundManagerObj;
    private RoundManager mRoundManager;

    private Transform mGridManagerObj;
    private GridManager mGridManager;

    private Transform mEvolutionManagerObj;
    private EvolutionManager mEvolutionManager;

    private List<Team> mTeams;
    private List<KeyValuePair<Team, int>> mScoreTable;

    public int mRoundNumber;
    private int mRoundCount;

    public int mTeamSize;
    public int mTeamCount;

    private SettingsData settings;

    public TMPro.TextMeshProUGUI mRoundCounter;

    public void Awake()
    {
        mRoundManagerObj = transform.Find("RoundManager");
        mRoundManager = mRoundManagerObj.GetComponent<RoundManager>();

        mGridManagerObj = transform.Find("GridManager");
        mGridManager = mGridManagerObj.GetComponent<GridManager>();

        mEvolutionManagerObj = transform.Find("EvolutionManager");
        mEvolutionManager = mEvolutionManagerObj.GetComponent<EvolutionManager>();

        mScoreTable = new List<KeyValuePair<Team, int>>();

        mTeamSize = 10;
        mTeamCount = 20;

        mTeams = new List<Team>();
        mRoundCount = 0;

        settings = SettingsData.Instance;
    }

    void Start()
    {
        Debug.Log("Round: " +  mRoundCount.ToString());
        
        createOriginalTeams();

        mRoundManager.InýtializeNewRound(mTeams);

        getScores();

        drawTeam(mScoreTable[0].Key);

        evolveTeams();
        mRoundCount++;

 
        isDraw = false;
    }

    void Update()
    {
        mRoundCounter.text = mRoundCount.ToString();
        //Debug.Log("Round: " + mRoundCount.ToString());
        if (isDraw)
        {
            drawTeam(mScoreTable[0].Key);
            isDraw = false;
        }

        if (mRoundCount < mRoundNumber) 
        {
            mRoundManager.InýtializeNewRound(mTeams);

            getScores();
            evolveTeams();
            mRoundCount++;
            isDraw = true;
        }
    }

    private void getScores()
    {
        mScoreTable = mRoundManager.GetScoreTable();
        //Debug.Log("mScoreTable[2].Key.TeamId: " + mScoreTable[2].Key.GetTeamId().ToString());
    }

    private void evolveTeams()
    {
        mTeams.Clear();
        foreach (KeyValuePair<Team, int> team in mScoreTable)
        {
            mTeams.Add(team.Key);
        }

        mTeams = mEvolutionManager.EvolveTeams(mTeams);
    }

    private void drawTeam(Team team)
    {
        mGridManager.DrawTeam(team);
    }

    private void createOriginalTeams()
    {
        for (int i = 0; i < mTeamCount; i++)
        {
            mTeams.Add(new Team(i));
            mTeams[i].InýtializeTeam(mTeamSize);
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
