using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warlock : Agent
{
    private List<KeyValuePair<Agent, List<Agent>>> mDebuffingList;
    public int mDefenseDebuff;


    public Warlock(string team, int agentId, int gridId) : base(team, "warlock", agentId, gridId)
    {
        mDebuffingList = new List<KeyValuePair<Agent, List<Agent>>>();
    }

    public override void setAOETargetList(List<KeyValuePair<Vector2, Agent>> enemyAgents, List<KeyValuePair<Vector2, Agent>> friendlyAgents)
    {
        foreach (Agent enemy in mEnemyTargetsPriorityList)
        {
            findAffectedEnemies(enemyAgents, enemy);
        }

    }


    protected override void loadParameters()
    {
        SettingsData settings = SettingsData.Instance;

        mHealth = settings.warlockHealth;
        mDefense = settings.warlockDefense;
        mDefenseDebuff = settings.warlockDefenseDebuff;
    }

    public override void MakeMove()
    {
        bool isMoveHappened = false;

        //Debug.Log("Warlock " + mAgentId + " Takes Action");

        while (!isMoveHappened)
        {
            if (mDebuffingList.Count == 0)
            {
                //Debug.Log("Warlock " + mAgentId + " has no more enemies left!");
                isMoveHappened = true;
                break;
            }

            if (mDebuffingList[0].Key.IsAlive())
            {
                //Debug.Log("Warlock" + mAgentId + " attacks!");
                foreach (Agent enemy in mDebuffingList[0].Value)
                {
                    enemy.ChangeDefense(-mDefenseDebuff);
                }

                isMoveHappened = true;
            }
            else
            {
                //Debug.Log("Warlock " + mAgentId + " removed one enemy from priority list and looking for another enemy");
                mEnemyTargetsPriorityList.RemoveAt(0);
                mDebuffingList.RemoveAt(0);
            }
        }
    }

    private void findAffectedEnemies(List<KeyValuePair<Vector2, Agent>> enemyAgents, Agent targetAgent)
    {
        Vector2 hitLocation = setHitLocation(targetAgent.GetAgentLocation());

        List<Vector2> affectedLocations = findAffectedLocations(hitLocation);

        List<Agent> affectedAgents = new List<Agent>();

        foreach (KeyValuePair<Vector2, Agent> enemy in enemyAgents)
        {
            foreach (Vector2 location in affectedLocations)
            {
                if (enemy.Key == location)
                {
                    affectedAgents.Add(enemy.Value);
                }
            }
        }

        mDebuffingList.Add(new KeyValuePair<Agent, List<Agent>>(targetAgent, affectedAgents));
    }

    // To have a better Mage, we always set hit location for maximum effect. 
    //If the target is close to the border, where some of the aoe attack will be wasted, we hit a neighbouring grid where we will have 3x3 attacking area
    private Vector2 setHitLocation(Vector2 hitLocation)
    {
        int targetX = (int)hitLocation.x;
        int targetY = (int)hitLocation.y;

        if (targetX == 0)
        {
            targetX = 1;
        }
        else if (targetX == 9)
        {
            targetX = 8;
        }

        if (targetY == 0 || targetY == 5)
        {
            targetY = targetY + 1;
        }
        else if (targetY == 4 || targetY == 9)
        {
            targetY = targetY - 1;
        }

        Vector2 adjustedHitLocation = new Vector2(targetX, targetY);

        return adjustedHitLocation;
    }

    private List<Vector2> findAffectedLocations(Vector2 hitLocation)
    {
        List<Vector2> affectedLocations = new List<Vector2>();

        for (int i = -1; i < 2; ++i)
        {
            for (int j = -1; j < 2; ++j)
            {
                affectedLocations.Add(new Vector2(hitLocation.x + i, hitLocation.y + j));
            }
        }

        return affectedLocations;
    }
}

