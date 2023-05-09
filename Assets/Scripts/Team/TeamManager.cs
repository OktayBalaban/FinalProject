using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeamManager : MonoBehaviour
{
    private List<Team> mTeams;

    private int mNumberOfTeams;
    private int mTeamSize;

    void Awake()
    {
        mTeams = new List<Team>();

        mNumberOfTeams = 20;
        mTeamSize = 10;

        createOriginalTeams();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public List<Team> GetTeams()
    {
        return mTeams;
    }

    private void createOriginalTeams()
    {
        for (int i = 0; i < mNumberOfTeams; i++)
        {
            mTeams.Add(new Team(i));
            mTeams[0].InýtializeTeam(mTeamSize);
        }
    }
}
