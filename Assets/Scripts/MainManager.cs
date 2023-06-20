using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //Temp List//
    private bool isDraw = true;


    private Transform mRoundManagerObj;
    private RoundManager mRoundManager;

    private Transform mTeamManagerObj;
    private TeamManager mTeamManager;

    private Transform mGridManagerObj;
    private GridManager mGridManager;

    private List<Team> mTeams;
    private List<KeyValuePair<Team, int>> mScoreTable;

    public void Awake()
    {
        mRoundManagerObj = transform.Find("RoundManager");
        mRoundManager = mRoundManagerObj.GetComponent<RoundManager>();

        mGridManagerObj = transform.Find("GridManager");
        mGridManager = mGridManagerObj.GetComponent<GridManager>();

        mTeamManagerObj = transform.Find("TeamManager");
        mTeamManager = mTeamManagerObj.GetComponent<TeamManager>();

        mScoreTable = new List<KeyValuePair<Team, int>>();
    }

    void Start()
    {
        mTeams = mTeamManager.GetTeams();

        mRoundManager.InýtializeNewRound(ref mTeams);
    }

    void Update()
    {
        while (isDraw)
        {
            GetScores();
            DrawTeam(mScoreTable[0].Key);
            isDraw = false;
        }
    }

    public void GetScores()
    {
        mScoreTable = mRoundManager.GetScoreTable();
        //Debug.Log("mScoreTable[2].Key.TeamId: " + mScoreTable[2].Key.GetTeamId().ToString());
    }

    public void DrawTeam(Team team)
    {
        mGridManager.DrawTeam(team);
    }
}
