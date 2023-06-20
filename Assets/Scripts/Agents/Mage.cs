using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Agent
{
    // This constructor calls the base constructor of Agent
    public Mage(string team, int agentId, int gridId) : base(team, "mage", agentId, gridId)
    {
        mHealth = 50;
        mOffense = 20;
        mDefense = 0;
    }

}
