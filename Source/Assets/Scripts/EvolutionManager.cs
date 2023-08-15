using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{

    public int mRemovalCount;
    public int mCrossbreedCount;
  
    public float mChangeAgentCoefficient;
    public float mChangeBase;

    private int mEvolutionCount;
    private int mIndex;

    public int mTeamSize = 10;
    private List<Team> mTeams;

    private SettingsData settings;


    void Awake()
    {
        settings = SettingsData.Instance;

        mRemovalCount = settings.numberOfCrossbreedReplacements;
        mCrossbreedCount = settings.numberOfCrossbreedParents;

        mChangeAgentCoefficient = settings.mutationCoefficient;
        mChangeBase = settings.mutationBias;

        mTeamSize = settings.teamSize;

        mTeams = new List<Team>();

        mEvolutionCount = 0;
        mIndex = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Team> EvolveTeams(List<Team> teamList)
    {
        mTeams = teamList;

        mEvolutionCount++;

        removeUnsuccessfulTeams();
        crossbreedNewTeams();
        mutateTeams();

        return mTeams;
    }

    private void removeUnsuccessfulTeams()
    {
        for (int i = 0; i < mRemovalCount; i++) 
        {
            mTeams.RemoveAt(mTeams.Count - 1);
        }
    }

    private void crossbreedNewTeams()
    {
        List<Team> crossbreederTeams = new List<Team>();

        for (int i = 0;i < mCrossbreedCount;i++) 
        {
            crossbreederTeams.Add(mTeams[i]);
        }

        List<KeyValuePair<string, int>> agentPool = getAgentPool(crossbreederTeams);

        for (int i = 0; i < mRemovalCount; i++)
        {
            createNewTeam(agentPool);
        }

        mIndex = 0;
    }

    private List<KeyValuePair<string, int>> getAgentPool(List<Team> parents)
    {
        List<KeyValuePair<string, int>> agentPool = new List<KeyValuePair<string, int>>();

        foreach (Team parent in parents)
        {
            List<KeyValuePair<string, int>> agents = parent.GetTeamComposition();
            
            foreach (KeyValuePair<string, int> agent in agents)
            {
                agentPool.Add(agent);
            }
        }

        return agentPool;
    }

    private void createNewTeam(List<KeyValuePair<string, int>> agentPool)
    {
        HashSet<int> occupiedLocations = new HashSet<int>();
        List<KeyValuePair<string, int>> teamComposition = new List<KeyValuePair<string, int>>();

        for(int i = 0; i < mTeamSize; ++i)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, agentPool.Count);
            }
            while (occupiedLocations.Contains(agentPool[randomIndex].Value));

            teamComposition.Add(agentPool[randomIndex]);
            occupiedLocations.Add(agentPool[randomIndex].Value);
        }

        int index = mEvolutionCount * 100 + mIndex;
        mIndex++;

        Team newTeam = new Team(index);
        newTeam.In�tializeTeamByOrder(teamComposition);

        mTeams.Add(newTeam);
    }

    private void mutateTeams()
    {
        // Change index is for elitism, the most successful team stays same, the less successful has much more chance to mutate
        int changeIndex = 0;
        foreach (Team team in mTeams)
        {
            float changeRate = changeIndex * mChangeAgentCoefficient + mChangeBase;
            changeRate = Mathf.Min(1.00f, changeRate);
            team.MutateAgents(changeRate);
            changeIndex++;
        }
    }
}
