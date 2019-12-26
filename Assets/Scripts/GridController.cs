using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public int X;
    public int Y;
    public string gridType = "N";

    private LevelController theLevel;

    void Start()
    {
        theLevel = FindObjectOfType<LevelController>();
    }

    void OnMouseDown()
    {
        if (theLevel.isStart && gridType.Equals("N"))
        {
            ChangeType();
            theLevel.CheckWin();
            if (theLevel.isStart)
                theLevel.ChangeTurn();
        }
    }

    void ChangeType()
    {
        gridType = theLevel.currentTurn;
        ChangeColor();
    }

    void ChangeColor()
    {
        switch (gridType)
        {
            case "O":
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case "X":
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }
    }
}
