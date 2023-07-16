using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Agent
{

    // This constructor calls the base constructor of Agent
    public Archer(string team, int agentId, int gridId) : base(team, "archer", agentId, gridId)
    {
        mHealth = 70;
        mOffense = 40;
        mDefense = 0;
    }

    public override void MakeMove()
    {
        bool isMoveHappened = false;

        //Debug.Log("Archer " + mAgentId + " Takes Action");

        while (!isMoveHappened)
        {
            if (mEnemyTargetsPriorityList.Count == 0)
            {
                //Debug.Log("Archer " + mAgentId + " has no more enemies left!");
                isMoveHappened = true;
                break;
            }

            if (mEnemyTargetsPriorityList[0].IsAlive())
            {
                //Debug.Log("Archer" + mAgentId + " attacks!");
                attack(mEnemyTargetsPriorityList[0]);
                isMoveHappened = true;
            }
            else
            {
                //Debug.Log("Archer " + mAgentId + " removed one enemy from priority list and looking for another enemy");
                mEnemyTargetsPriorityList.RemoveAt(0);
            }
        }
    }

}
