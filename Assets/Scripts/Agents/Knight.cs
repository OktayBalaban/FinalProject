using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Agent
{
    // This constructor calls the base constructor of Agent
    public Knight(string team, int agentId, int gridId) : base(team, "knight", agentId, gridId)
    {
        mOffense = 0;
        mHealth = 350;
        mDefense = 10;
    }


}
