using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int mWidth = 1;
    private int mHeight = 1;
    private Grid[] mGridArray = new Grid[100];

    public GameObject prefabKnight;
    public GameObject prefabMage;
    public GameObject prefabHealer;
    public GameObject prefabArcher;

    void Awake()
    {

    }

    void Start()
    {
        populateGridArray();
    }

    void Update()
    {

    }

    public void DrawTeam(Team team)
    {
        Debug.Log("Drawing Teams in Grid Manager");
        clearAgentsFromGrids();

        List<KeyValuePair<string, int>> teamComposition = team.GetTeamComposition();

        int agentId = 0;

        foreach(KeyValuePair<string, int> agent in teamComposition)
        {
            mGridArray[agent.Value].SetAgent(agentId, agent.Key);
            agentId++;

            List<int> agentPos = mGridArray[agent.Value].GetAgentPosition();
            Vector2 spawnPosition = new Vector2(agentPos[0], agentPos[1]);

            switch (agent.Key)
            {
                case "knight":
                    GameObject newAgentKnight = Instantiate(prefabKnight, spawnPosition, Quaternion.identity);
                    newAgentKnight.name = $"Agent_{agentId}_{agent.Key}";
                    break;
                case "healer":
                    GameObject newAgentHealer = Instantiate(prefabHealer, spawnPosition, Quaternion.identity);
                    newAgentHealer.name = $"Agent_{agentId}_{agent.Key}";
                    break;
                case "mage":
                    GameObject newAgentMage = Instantiate(prefabMage, spawnPosition, Quaternion.identity);
                    newAgentMage.name = $"Agent_{agentId}_{agent.Key}";
                    break;
                case "archer":
                    GameObject newAgentArcher = Instantiate(prefabArcher, spawnPosition, Quaternion.identity);
                    newAgentArcher.name = $"Agent_{agentId}_{agent.Key}";
                    break;
            }
        }

    }

    public Grid[] GetGrids()
    {
        return mGridArray;
    }

    private void populateGridArray()
    {
        for (int i = 0; i < mGridArray.Length; ++i)
        {
            int posX = i % 10;
            int posY = i / 10;
            mGridArray[i] = new Grid(posX, posY, mWidth, mHeight, i);
            //Debug.Log("Grid " + i.ToString() + " is created.");
        }
    }

    private void clearAgentsFromGrids()
    {
        foreach(Grid grid in mGridArray)
        {
            grid.ClearAgent();
        }
    }
}