using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Agent
{
    // This constructor calls the base constructor of Agent
    public Knight(string team, int agentId, int gridId) : base(team, "knight", agentId, gridId)
    {

    }

    protected override void loadParameters()
    {
        SettingsData settings = SettingsData.Instance;

        mHealth = settings.knightHealth;
        mDefense = settings.knightDefense;
    }


}
