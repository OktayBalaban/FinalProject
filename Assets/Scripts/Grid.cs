using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    private int mWidth;
    private int mHeight;
    private int mGridId;
    private int mPosX;
    private int mPosY;


    private string mGridIdStr;

    // -1 means no agent is located in the grid
    private int mAgentId = -1;
    private string mAgentType;

    public Grid(int posX, int posY, int width, int height, int gridId)
    {
        mWidth = width;
        mHeight = height;
        mGridId = gridId;

        mPosX = posX * mWidth;
        mPosY = posY * mHeight;

        mGridIdStr = "Rectangle" + mGridId.ToString();
    }

    public int GetGridId()
    {
        return mGridId;
    }

    public void SetAgent(int agentId,string agentType)
    {
        mAgentId = agentId;
        mAgentType = agentType;

        //Debug.Log("Agent " + agentId.ToString() + " is created as " +  agentType + " on grid " + mGridId.ToString());
    }

    public void ClearAgent()
    {
        mAgentId = -1;
    }
    
    public int GetAgent()
    {
        return mAgentId;
    }

    public List<int> GetAgentPosition()
    {
        List<int> agentPos = new List<int> { mPosX, mPosY };
        return agentPos;
    }

}
