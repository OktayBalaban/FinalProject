using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent
{
    
    enum AgentType {healer, knight, mage, archer}

    protected string mTeam;
    private AgentType mAgentType;
    protected int mAgentId;
    protected int mGridId;
    protected Vector2 mLocation;

    protected int mHealth;
    protected int mOffense;
    protected int mDefense;

    protected int mBaseOffense;
    protected int mBaseDefense;
    protected int mBaseHealth;

    protected bool mIsAlive;

    protected List<Agent> mEnemyTargetsPriorityList;

    public Agent(string team, string agentType, int agentId, int gridId)
    {
        mTeam = team;
        mAgentType = (AgentType)System.Enum.Parse(typeof(AgentType), agentType);
        mAgentId = agentId;
        mGridId = gridId;

        mIsAlive = true;
        mBaseHealth = mHealth;

        mLocation = setMapLocation();

        mEnemyTargetsPriorityList = new List<Agent>();
}

    protected void commonAgentStart()
    {
        setBaseStats();
    }

    protected void commonAgentTurnStart()
    {

    }

    protected void commonAgentTurnEnd() 
    {
        resetBaseStats();
    }

    protected void commonAgentEnd() 
    { 
        
    }

    public int GetAgentId()
    {
        return mAgentId;
    }

    public Vector2 GetAgentLocation()
    {
        return mLocation;
    }

    public virtual void MakeMove()
    {
        // Moves of the agents here
    }

    public void PrepareAgent()
    {
        resetBaseStats();
        mIsAlive = true;
    }

    protected void setBaseStats()
    {
        mBaseDefense = mDefense;
        mBaseOffense = mOffense;
        mBaseHealth = mHealth;
    }

    protected void resetBaseStats() 
    {
        mOffense = mBaseOffense;
        mDefense = mBaseDefense;
        mHealth = mBaseHealth;
    }

    public bool IsAlive()
    {
        if (mHealth > 0)
        {
            return true;
        }

        mIsAlive = false;
        return false;
    }

    public void ChangeOffense(int change)
    {
        mOffense += change;
    }

    public void ChangeHealth(int change)
    {
        mHealth += change;
    }

    public void ChangeDefense(int change)
    {
        mDefense += change;
    }

    protected void attack(Agent agent)
    {
        agent.ChangeHealth(-mOffense);
    }

    public void SetEnemyTargetList(List<KeyValuePair<Vector2, Agent>> enemyAgents)
    {
        List<KeyValuePair<Agent, float>> enemyDistances = new List<KeyValuePair<Agent, float>>();

        foreach (KeyValuePair<Vector2, Agent> enemy in enemyAgents) 
        {

            Vector2 diff = mLocation - enemy.Key;
            float distanceSqr = diff.sqrMagnitude;

            KeyValuePair<Agent, float> newEnemy = new KeyValuePair<Agent, float>(enemy.Value, distanceSqr);

            enemyDistances.Add(newEnemy);
        }

        
        // Sort enemies by distances from smaller to higher
        enemyDistances.Sort((x, y) => x.Value.CompareTo(y.Value));


        foreach (KeyValuePair<Agent, float> enemy in enemyDistances)
        {
            //Debug.Log("Agent Id: " +  enemy.Key + " Distance: " + enemy.Value);
            mEnemyTargetsPriorityList.Add(enemy.Key);
        }

    }

    // TODO Make a real calculation
    private Vector2 setMapLocation()
    {
        int posX;
        int posY;
        if (mTeam == "blue")
        {
            int reverseGridId = 99 - mGridId;
            posX = reverseGridId % 10;
            posY = reverseGridId / 10;
        }
        else
        {
            posX = mGridId % 10;
            posY = mGridId / 10;
        }

        Vector2 agentPos = new Vector2(posX, posY);

        return agentPos;
    }
}
