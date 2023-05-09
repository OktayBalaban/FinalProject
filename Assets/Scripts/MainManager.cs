using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Transform mRoundManagerObj;
    private RoundManager mRoundManager;

    private Transform mTeamManagerObj;
    private TeamManager mTeamManager;

    private List<Team> mTeams;

    public void Awake()
    {
        mRoundManagerObj = transform.Find("RoundManager");
        mRoundManager = this.mRoundManagerObj.GetComponent<RoundManager>();

        mTeamManagerObj = transform.Find("TeamManager");
        mTeamManager = mTeamManagerObj.GetComponent<TeamManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mTeams = mTeamManager.GetTeams();

        mRoundManager.InýtializeNewRound(ref mTeams);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
