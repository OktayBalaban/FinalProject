using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    enum AgentType { Healer, Knight, Mage };

    private int mTeamId;

    private List<KeyValuePair<string, int>> mAgents;
    private HashSet<int> mOccupiedGrids;

    private int mWins;

    public Team(int teamId)
    {
        mTeamId = teamId;

        mAgents = new List<KeyValuePair<string, int>>();
        mOccupiedGrids = new HashSet<int>();

        mWins = 0;
    }

    public void InýtializeTeam(int teamSize)
    {
        for (int i = 0; i < teamSize; i++) 
        {
            AgentType agentType = getRandomAgent();

            int gridId;
            do
            {
                gridId = Random.Range(0, 50);
            }
            while (mOccupiedGrids.Contains(gridId));

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

    public int GetScore()
    {
        return mWins;
    }

    public void ResetScore()
    {
        mWins = 0;
    }

    AgentType getRandomAgent()
    {
        System.Array enumValues = System.Enum.GetValues(typeof(AgentType));
        int RandomIndex = Random.Range(0, enumValues.Length);

        return (AgentType)enumValues.GetValue(RandomIndex);
    }
}
