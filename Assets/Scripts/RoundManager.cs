using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private Transform mGridManagerObj;
    private GridManager mGridManager;

    private Transform mAgentManagerObj;
    private AgentManager mAgentManager;

    private List<KeyValuePair<Team, int>> mTeams;
    private List<KeyValuePair<Team, Team>> mFixture;

    public void Awake()
    {
        mGridManagerObj = transform.Find("GridManager");
        mGridManager = mGridManagerObj.GetComponent<GridManager>();

        mAgentManagerObj = transform.Find("AgentManager");
        mAgentManager = mAgentManagerObj.GetComponent<AgentManager>();

        mTeams = new List<KeyValuePair<Team, int>>();
        mFixture = new List<KeyValuePair<Team, Team>>();
}

    void Start()
    {

    }

    void Update()
    {

    }

    public void InýtializeNewRound(ref List<Team> teams)
    {
        foreach (Team team in teams) 
        {
            mTeams.Add(new KeyValuePair<Team, int>(team, 0));
        }

        createFixture();
        Debug.Log("Fixture Created");
    }

    private void createFixture()
    {
        for (int i = 0; i < mTeams.Count; i++)
        {
            for(int j = i + 1; j < mTeams.Count; j++)
            {
                mFixture.Add(new KeyValuePair<Team, Team>(mTeams[i].Key, mTeams[j].Key));
                Debug.Log(mTeams[i].Key.GetTeamId().ToString() + " vs " + mTeams[j].Key.GetTeamId().ToString());
            }
        }
    }
}
