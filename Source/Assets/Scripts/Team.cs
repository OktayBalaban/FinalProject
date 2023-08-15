using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Team
{
    enum AgentType { paladin, knight, mage, archer, cleric, warlock };

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

    public void InıtializeTeam(int teamSize)
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

        var orderedAgents = mAgents
                            .OrderBy(agent => agent.Key == "mage" || agent.Key == "archer")
                            .ToList();

        mAgents = orderedAgents;
    }

    public void InıtializeTeamByOrder(List<KeyValuePair<string, int>> unitList)
    {
        //Debug.Log("Unit Count: " + unitList.Count);
        foreach(KeyValuePair<string, int> agent in unitList)
        {
            mOccupiedGrids.Add(agent.Value);

            CreateAgent(agent.Key, agent.Value);
        }

        var orderedAgents = mAgents
                            .OrderBy(agent => agent.Key == "mage" || agent.Key == "archer")
                            .ToList();

        mAgents = orderedAgents;
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

    public void MutateAgents(float changeRate)
    {
        int changedAgentCount = 0;

        for (int i = mAgents.Count - 1; i >= 0; i--)
        {
            float randomFloat = Random.Range(0f, 1f);

            if (randomFloat < changeRate)
            {
                //Debug.Log("Mutation Happens");
                mOccupiedGrids.Remove(mAgents[i].Value);
                mAgents.RemoveAt(i);
                changedAgentCount++;
            }
        }

        for (int i = 0; i < changedAgentCount; i++)
        {
            //Debug.Log("New Mutation");
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
                case "paladin":
                    Paladin newAgentPaladin = new Paladin(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentPaladin);
                    //Debug.Log("Agent " + agentId.ToString() + "is being created for " + mTeamId.ToString() + " (" + teamColour + ") as Paladin");
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
                case "cleric":
                    Cleric newAgentcleric = new Cleric(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentcleric);
                    //Debug.Log("Agent " + agentId.ToString() + "is being created for " + mTeamId.ToString() + " (" + teamColour + ") as cleric");
                    break;
                case "warlock":
                    Warlock newAgentWarlock = new Warlock(teamColour, agentId, agent.Value);
                    mAliveAgents.Add(newAgentWarlock);
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
