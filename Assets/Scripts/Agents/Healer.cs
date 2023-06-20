using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Agent
{
    // This constructor calls the base constructor of Agent
    public Healer(string team, int agentId, int gridId) : base(team, "healer", agentId, gridId)
    {
        mHealth = 60;
        mOffense = 0;
        mDefense = 10;
    }

}
