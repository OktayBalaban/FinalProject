using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    enum Team { red, blue };
    enum AgentType {healer, knight, mage}

    Team team;
    AgentType agentType;
    int agentId;
    int gridId;

    int health;

    public Agent(string team, string agentType, int agentId, int gridId)
    {
        this.team = (Team)System.Enum.Parse(typeof(Team), team);
        this.agentType = (AgentType)System.Enum.Parse(typeof(AgentType), agentType);
        this.agentId = agentId;
        this.gridId = gridId;

        this.health = 100;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetAgentId()
    {
        return agentId;
    }

    private void instantiateAgent()
    {
        Vector2 location = getMapLocation();
        Quaternion rotation = Quaternion.identity;
        Instantiate(gameObject, location, rotation);
    }

    // TODO Make a real calculation
    private Vector2 getMapLocation()
    {
        Vector3 location = new Vector3(20, 20, 0);
        return location;
    }
    
}
