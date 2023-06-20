using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    enum AgentType { healer, knight, mage, archer };

    private int mTeamId;

    private List<KeyValuePair<string, int>> mAgents;
    private HashSet<int> mOccupiedGrids;

    private int mScore;

    private List<Agent> mAliveAgents;

    public Team(int teamId)
    {
        mTeamId = teamId;

        mAgents = new List<KeyValuePair<string, int>>();
        mOccupiedGrids = new HashSet<int>();

        mAliveAgents = new List<Agent>();

        mScore = 0;
    }

    public void InýtializeTeam(int teamSize)
    {
        for (int i = 0; i < teamSize; i++) 
        {
            AgentType agentType = getRandomAgent();

            // Set a unique Grid
            int gridId;
            do
            {
                gridId = Random.Range(0, 50);
            }
            while (mOccupiedGrids.Contains(gridId));
            mOccupiedGrids.Add(gridId);

            CreateAgent(agentType.ToString(), gridId);
        }
    }

    public void CreateAgent(string agentType, int gridId)
    {
        mAgents.Add(new KeyValuePair<string, int>(agentType, gridId));
    }

    public List<KeyValuePair<string, int>> GetTeamComposition()
    {
        return mAgents;
    }

    public int GetTeamId()
    { 
        return mTeamId; 
    }

    public void IncrementScore(int increment)
    {
        mScore += increment;
    }

    public int GetScore()
    {
        return mScore;
    }

    public void ResetScore()
    {
        mScore = 0;
    }

    public void PrepareTeam(string teamColour)
    {
        //Debug.Log("Preparing Team " + teamColour + " for " + mTeamId.ToString());
        int agentId = 0;

        if (teamColour == "blue")
        {
            agentId = 10;
        }

        foreach (KeyValuePair<string, int> agent in mAgents)
        {
            //Debug.Log("Agent " + agentId.ToString() + " is being created for " + mTeamId.ToString());
            switch (agent.Key)
            {
                case "knight":
                    Knight newAgentKnight = new Knight(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentKnight);
                    //Debug.Log("Agent " + agentId.ToString() + "is being created for " + mTeamId.ToString() + " (" + teamColour + ") as Knight");
                    break;
                case "healer":
                    Healer newAgentHealer = new Healer(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentHealer);
                    //Debug.Log("Agent " + agentId.ToString() + "is being created for " + mTeamId.ToString() + " (" + teamColour + ") as Healer");
                    break;
                case "mage":
                    Mage newAgentMage = new Mage(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentMage);
                    //Debug.Log("Agent " + agentId.ToString() + "is being created for " + mTeamId.ToString() + " (" + teamColour + ") as Mage");
                    break;
                case "archer":
                    Archer newAgentArcher = new Archer(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentArcher);
                    //Debug.Log("Agent " + agentId.ToString() + "is being created for " + mTeamId.ToString() + " (" + teamColour + ") as Archer");
                    break;
            }

            agentId++;

        }
    }

    public List<Agent> GetAliveAgents()
    {
        for (int i = mAliveAgents.Count - 1; i >= 0; i--)
        {
            if (!mAliveAgents[i].IsAlive())
            {
                mAliveAgents.RemoveAt(i);
            }
        }

        return mAliveAgents;
    }

    public void EndProcedure()
    {
        destroyTeamAgents();
    }

    private void destroyTeamAgents()
    {

    }

    AgentType getRandomAgent()
    {
        System.Array enumValues = System.Enum.GetValues(typeof(AgentType));
        int RandomIndex = Random.Range(0, enumValues.Length);

        return (AgentType)enumValues.GetValue(RandomIndex);
    }
}
