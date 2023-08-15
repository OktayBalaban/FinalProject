using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleric : Agent
{
    private List<Agent> mBuffingList;

    public int mOffenseBuff;
    public int mDefenseBuff;

    public Cleric(string team, int agentId, int gridId) : base(team, "cleric", agentId, gridId)
    {
        mBuffingList = new List<Agent>();
    }

    protected override void loadParameters()
    {
        SettingsData settings = SettingsData.Instance;

        mHealth = settings.clericHealth;
        mDefense = settings.clericDefense;
        mOffenseBuff = settings.clericOffenseBuff;
        mDefenseBuff = settings.clericDefenseBuff;
    }

    public override void setAOETargetList(List<KeyValuePair<Vector2, Agent>> enemyAgents, List<KeyValuePair<Vector2, Agent>> friendlyAgents)
    {
        List<Vector2> locations = findBuffingLocations();

        findAffectedFriendlies(friendlyAgents, locations);
    }

    public override void MakeMove()
    {

        //Debug.Log("Paladin " + mAgentId + " Takes Action");

        foreach (Agent target in mBuffingList)
        {
            if (target.IsAlive())
            {
                target.ChangeOffense(mOffenseBuff);
                target.ChangeDefense(mDefenseBuff);
            }
        }

    }

    private List<Vector2> findBuffingLocations()
    {
        List<Vector2> locations = new List<Vector2>();

        // Check the grid around the cleric, 2 grids in each direction.
        for (int i = -2; i <= 2; i++)
        {
            for (int j = -2; j <= 2; j++)
            {
                int targetX = (int)mLocation.x + i;
                var targetY = (int)mLocation.y + j;

                // Only include positions that are within the 10x10 grid.
                if (targetX >= 0 && targetX < 10 && targetY >= 0 && targetY < 10)
                {
                    locations.Add(new Vector2(targetX, targetY));
                }
            }
        }

        return locations;
    }

    private void findAffectedFriendlies(List<KeyValuePair<Vector2, Agent>> friendlyAgents, List<Vector2> healingLocations)
    {
        List<Agent> affectedAgents = new List<Agent>();

        foreach (KeyValuePair<Vector2, Agent> friend in friendlyAgents)
        {
            foreach (Vector2 location in healingLocations)
            {
                if (friend.Key == location)
                {
                    mBuffingList.Add(friend.Value);
                }
            }
        }
    }

}
