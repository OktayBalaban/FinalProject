using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static GridManager _instance;

    private int mWidth = 100;
    private int mHeight = 100;
    private Grid[] mGridArray = new Grid[100];

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

    public Grid[] GetGrids()
    {
        return mGridArray;
    }

    public void SetAgent(int agentId, int gridId)
    {

    }

    private void populateGridArray()
    {
        for (int i = 0; i < mGridArray.Length; ++i)
        {
            int posX = i / 10;
            int posY = i % 10;
            mGridArray[i] = new Grid(posX, posY, mWidth, mHeight, i);
            //Debug.Log("Grid " + i.ToString() + " is created.");
        }
    }
}
