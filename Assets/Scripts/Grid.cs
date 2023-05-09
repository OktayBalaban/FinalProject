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

    // 0 means no agent is located in the grid
    private int mAgentId = 0;

    public Grid(int posX, int posY, int width, int height, int gridId)
    {
        mPosX = posX;
        mPosY = posY;
        mWidth = width;
        mHeight = height;
        mGridId = gridId;

        mGridIdStr = "Rectangle" + mGridId.ToString();
    }

    public int GetGridId()
    {
        return mGridId;
    }

    public void SetAgent(int agentId)
    {
        mAgentId = agentId;
    }
    
    public int GetAgent()
    {
        return mAgentId;
    }




}
