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
        Vector2 hitLocation = targetAgent.GetAgentLocation();

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

    private List<Vector2> findAffectedLocations(Vector2 hitLocation)
    {
        List<Vector2> affectedLocations = new List<Vector2>();

        for (int i = 0; i < 10; ++i)
        {
            affectedLocations.Add(new Vector2(i, hitLocation.y));
        }

        return affectedLocations;
    }

}
