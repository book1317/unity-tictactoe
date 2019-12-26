using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public string currentTurn = "O";
    public List<GridController> allGrid;
    public bool isStart = true;
    private int turnCounter = 0;
    public Text winText;
    public Text currentTurnText;


    public void ChangeTurn()
    {
        turnCounter++;
        ToggleTurn();
        if (turnCounter >= 9)
        {
            Draw();
        }
    }

    public void CheckWin()
    {
        if (GetGridType(0, 0).Equals(currentTurn) && GetGridType(1, 1).Equals(currentTurn) && GetGridType(2, 2).Equals(currentTurn))
            Win();
        else if (GetGridType(2, 0).Equals(currentTurn) && GetGridType(1, 1).Equals(currentTurn) && GetGridType(0, 2).Equals(currentTurn))
            Win();
        else if (GetGridType(0, 0).Equals(currentTurn) && GetGridType(1, 0).Equals(currentTurn) && GetGridType(2, 0).Equals(currentTurn))
            Win();
        else if (GetGridType(0, 1).Equals(currentTurn) && GetGridType(1, 1).Equals(currentTurn) && GetGridType(2, 1).Equals(currentTurn))
            Win();
        else if (GetGridType(0, 2).Equals(currentTurn) && GetGridType(1, 2).Equals(currentTurn) && GetGridType(2, 2).Equals(currentTurn))
            Win();
        else if (GetGridType(0, 0).Equals(currentTurn) && GetGridType(0, 1).Equals(currentTurn) && GetGridType(0, 2).Equals(currentTurn))
            Win();
        else if (GetGridType(1, 0).Equals(currentTurn) && GetGridType(1, 1).Equals(currentTurn) && GetGridType(1, 2).Equals(currentTurn))
            Win();
        else if (GetGridType(2, 0).Equals(currentTurn) && GetGridType(2, 1).Equals(currentTurn) && GetGridType(2, 2).Equals(currentTurn))
            Win();
    }

    void ToggleTurn()
    {
        switch (currentTurn)
        {
            case "O":
                currentTurn = "X";
                winText.color = Color.blue;
                currentTurnText.text = "Blue";
                break;
            case "X":
                currentTurn = "O";
                winText.color = Color.red;
                currentTurnText.text = "Red";
                break;
        }
    }

    GridController GetGrid(int x, int y)
    {
        for (int i = 0; i < allGrid.Count; i++)
            if (allGrid[i].X == x && allGrid[i].Y == y)
                return allGrid[i];
        return null;
    }

    string GetGridType(int x, int y)
    {
        return GetGrid(x, y).gridType;
    }


    void Draw()
    {
        winText.text = "Draw";
        winText.color = Color.gray;
        isStart = false;
    }

    void Win()
    {
        switch (currentTurn)
        {
            case "O":
                winText.text = "Red Win";
                winText.color = Color.red;
                break;
            case "X":
                winText.text = "Blue Win";
                winText.color = Color.blue;
                break;
        }
        isStart = false;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
