using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Agent
{
    
    enum AgentType {paladin, knight, mage, archer, cleric, warlock}

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

    protected Transform mSettingManagerObj;
    protected SettingsManager mSettingsManager;
    protected SettingsData mSettings;

    public Agent(string team, string agentType, int agentId, int gridId)
    {
        mTeam = team;
        mAgentType = (AgentType)System.Enum.Parse(typeof(AgentType), agentType);
        mAgentId = agentId;
        mGridId = gridId;

        mIsAlive = true;

        loadParameters();
        setBaseStats();

        mLocation = setMapLocation();

        mEnemyTargetsPriorityList = new List<Agent>();

    }

    

    protected virtual void loadParameters()
    {
        //
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
        ResetStats();
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

    public int GetAgentDefense()
    {
        return mDefense;
    }

    public int GetAgentOffense()
    {
        return mOffense;
    }

    public virtual void MakeMove()
    {
        // Moves of the agents here
    }

    public void PrepareAgent()
    {
        ResetStats();
        mIsAlive = true;
    }

    protected void setBaseStats()
    {
        mBaseDefense = mDefense;
        mBaseOffense = mOffense;
        mBaseHealth = mHealth;
    }

    public void ResetStats() 
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

    public void AdjustHealth()
    {
        mHealth = Math.Min(mHealth, mBaseHealth);
    }

    protected void attack(Agent agent)
    {
        int enemyDefense = agent.GetAgentDefense();
        int amount = Math.Max(0, mOffense - enemyDefense);
        agent.ChangeHealth(-amount);
    }

    protected void heal(Agent agent, int healAmount)
    {
        agent.ChangeHealth(healAmount);
        //agent.AdjustHealth();
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

    public virtual void setAOETargetList(List<KeyValuePair<Vector2, Agent>> enemyAgents, List<KeyValuePair<Vector2, Agent>> friendlyAgents)
    {
        // Implementation is unique to agents
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




