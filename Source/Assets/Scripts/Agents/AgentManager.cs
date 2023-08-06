using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AgentManager;

public class AgentManager : MonoBehaviour
{
    public struct Team
    {
        public int agentId;
        public string team;
        public string agentType;
        public Vector2 position;
        public int health;

        public Team(int agentId, string team, string agentType, Vector2 position, int health)
        {
            this.agentId = agentId;
            this.team = team;
            this.agentType = agentType;
            this.position = position;
            this.health = health;
        }
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InýtializeTeams()
    {

    }
}
