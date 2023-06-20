using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private Transform mAgentManagerObj;
    private AgentManager mAgentManager;

    private bool mIsMatchPlaying;
    private int mTurnLimit;
    private int mPlayedTurns;

    private Team mRedTeam;
    private Team mBlueTeam;

    private List<Agent> mRedAgents;
    private List<Agent> mBlueAgents;

    private List<KeyValuePair<Vector2, Agent>> mRedAgentsLocations;
    private List<KeyValuePair<Vector2, Agent>> mBlueAgentsLocations;

    private string mWinner;

    void Awake()
    {
        mAgentManagerObj = transform.Find("AgentManager");
        mAgentManager = mAgentManagerObj.GetComponent<AgentManager>();

        mIsMatchPlaying = false;
        mTurnLimit = 50;
        mPlayedTurns = 0;

        mRedAgents = new List<Agent>();
        mBlueAgents = new List<Agent>();

        mRedAgentsLocations = new List<KeyValuePair<Vector2, Agent>>();
        mBlueAgentsLocations = new List<KeyValuePair<Vector2, Agent>>();

        mWinner = "draw";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewMatch(ref Team redTeam, ref Team blueTeam)
    {
        destroyOldMatch();

        mRedTeam = redTeam;
        mBlueTeam = blueTeam;

        mRedTeam.PrepareTeam("red");
        mBlueTeam.PrepareTeam("blue");

        Debug.Log("Teams are prepared");

        mRedAgents = mRedTeam.GetAliveAgents();
        mBlueAgents = mBlueTeam.GetAliveAgents();

        Debug.Log("Agents Are Taken");

        populateAgentLocations();
        setEnemyTargets();

        Debug.Log("Targets are prioritized");

        mIsMatchPlaying = true;

        
        while (mIsMatchPlaying)
        {
            processTurn();

            if(checkWinner())
            {
                Debug.Log("Changing Winner to: " + mWinner);
                mIsMatchPlaying=false;
            }
        }
    }

    public string GetWinner()
    {
        return mWinner;
    }

    private void destroyOldMatch()
    {
        mPlayedTurns = 0;

        mRedAgents.Clear();
        mBlueAgents.Clear();

        mRedAgentsLocations.Clear();
        mBlueAgentsLocations.Clear();
    }

    private void populateAgentLocations()
    {
        foreach (Agent agent in mRedAgents)
        {
            Vector2 agentLoc = agent.GetAgentLocation();

            KeyValuePair<Vector2, Agent> newAgent = new KeyValuePair<Vector2, Agent>(agentLoc, agent);

            mRedAgentsLocations.Add(newAgent);
        }

        foreach (Agent agent in mBlueAgents)
        {
            Vector2 agentLoc = agent.GetAgentLocation();

            KeyValuePair<Vector2, Agent> newAgent = new KeyValuePair<Vector2, Agent>(agentLoc, agent);

            mBlueAgentsLocations.Add(newAgent);
        }
    }

    private void setEnemyTargets()
    {
        foreach (Agent agent in mRedAgents)
        {
            agent.SetEnemyTargetList(mBlueAgentsLocations);
        }

        foreach (Agent agent in mBlueAgents)
        {
            agent.SetEnemyTargetList(mRedAgentsLocations);
        }
    }

    private void processTurn()
    {
        if(mPlayedTurns == mTurnLimit)
        {
            mWinner = "draw";
            mIsMatchPlaying = false;
            return;
        }

        processAgentMoves();
        updateAliveAgents();

        mPlayedTurns++;
    }

    private void processAgentMoves()
    {
        foreach (Agent agent in mRedAgents)
        {
            agent.MakeMove();
        }

        foreach (Agent agent in mBlueAgents)
        {
            agent.MakeMove();
        }
    }

    private void updateAliveAgents()
    {
        mRedAgents = mRedTeam.GetAliveAgents();
        mBlueAgents = mBlueTeam.GetAliveAgents();
    }

    private bool checkWinner()
    {
        Debug.Log("-----------------------------Checking Winner---------------------");
        Debug.Log("Red Agents Left: " + mRedAgents.Count.ToString());
        Debug.Log("Blue Agents Left: " + mBlueAgents.Count.ToString());

        bool isBlueStanding = true;
        bool isRedStanding = true;

        bool isMatchConcluded = false;

        if (mRedAgents.Count == 0) 
        {
            isRedStanding = false;
        }

        if (mBlueAgents.Count == 0)
        {
            isBlueStanding = false;
        }

        Debug.Log("isRedStanding: " + isRedStanding + ", isBlueStanding: " + isBlueStanding);

        if (!(isRedStanding || isBlueStanding))
        {
            mWinner = "draw";
            isMatchConcluded = true;
        }
        else
        {
            if (!isRedStanding)
            {
                mWinner = "blue";
                isMatchConcluded = true;
            }
            if (!isBlueStanding)
            {
                mWinner = "red";
                isMatchConcluded = true;
            }
        }

        return isMatchConcluded;
    }
}
