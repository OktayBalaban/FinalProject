using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private Transform mMatchManagerObj;
    private MatchManager mMatchManager;

    private List<KeyValuePair<Team, int>> mTeams;
    private List<KeyValuePair<Team, int>> mScoreTable;
    private List<KeyValuePair<KeyValuePair<Team, int>, KeyValuePair<Team, int>>> mFixture;

    public void Awake()
    {
        mMatchManagerObj = transform.Find("MatchManager");
        mMatchManager = mMatchManagerObj.GetComponent<MatchManager>();

        mTeams = new List<KeyValuePair<Team, int>>();
        mScoreTable = new List<KeyValuePair<Team, int>>();
        mFixture = new List<KeyValuePair<KeyValuePair<Team, int>, KeyValuePair<Team, int>>>();
}

    void Start()
    {

    }

    void Update()
    {

    }

    public void InýtializeNewRound(ref List<Team> teams)
    {
        int roundTeamId = 0;
        foreach (Team team in teams) 
        {
            mTeams.Add(new KeyValuePair<Team, int>(team, roundTeamId));
            roundTeamId++;
        }

        createFixture();
        Debug.Log("Fixture Created");
        processRounds();

    }

    public List<KeyValuePair<Team, int>> GetScoreTable()
    {
        prepareScoreTable();
        return mScoreTable;
    }

    private void createFixture()
    {
        for (int i = 0; i < mTeams.Count; i++)
        {
            for(int j = i + 1; j < mTeams.Count; j++)
            {
                mFixture.Add(new KeyValuePair<KeyValuePair<Team, int>, KeyValuePair<Team, int>>(mTeams[i], mTeams[j]));
                //Debug.Log(mTeams[i].Key.GetTeamId().ToString() + " vs " + mTeams[j].Key.GetTeamId().ToString());
            }
        }
    }

    private void processRounds()
    {
        foreach(KeyValuePair<KeyValuePair<Team, int>, KeyValuePair<Team, int>> match in mFixture)
        {
            Team teamRed = match.Key.Key;
            Team teamBlue = match.Value.Key;

            mMatchManager.StartNewMatch(ref teamRed, ref teamBlue);

            string winner = mMatchManager.GetWinner();

            if (winner == "red")
            {
                match.Key.Key.IncrementScore(2);
            }
            else if (winner == "blue")
            {
                match.Value.Key.IncrementScore(2);
            }
            else
            {
                match.Key.Key.IncrementScore(1);
                match.Value.Key.IncrementScore(1);
            }
        }
    }

    private void prepareScoreTable()
    {
        foreach (KeyValuePair<Team, int> team in mTeams)
        {
            Debug.Log("Team " + team.Value + " Score: " + team.Key.GetScore());
            mScoreTable.Add(new KeyValuePair<Team, int>(team.Key, team.Key.GetScore()));
        }

        mScoreTable.Sort((x, y) => y.Value.CompareTo(x.Value));
    }
}
