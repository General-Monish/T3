using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Player
{
    public Image panel;
    public TextMeshProUGUI text;
}

[Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}
public class GameController : MonoBehaviour
{
    public TextMeshProUGUI[] Buttontextlist;
    private string playerSide;

    public GameObject GameOverPanel;
    public TextMeshProUGUI gameoverText;
     int moveCount;
    public GameObject restartBtn;

    public Player playerX;
    public Player playerO;
    public PlayerColor activatePlayerColor;
    public PlayerColor deAactivatePlayerColor;
    bool isWinLose;
    private void Awake()
    {
        restartBtn.SetActive(false);
        GameOverPanel.SetActive(false);
        SetGameControllerReferanceOnButtons();
        playerSide = "X";
        moveCount = 0;
        SetPlayerColors(playerX, playerO);
    }
    void SetGameControllerReferanceOnButtons()
    {
        for(int i = 0; i < Buttontextlist.Length; i++)
        {
            Buttontextlist[i].GetComponentInParent<GridSpace>().setGameControllerReferance(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;
        if (Buttontextlist[0].text == playerSide && Buttontextlist[1].text == playerSide && Buttontextlist[2].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[3].text == playerSide && Buttontextlist[4].text == playerSide && Buttontextlist[5].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[6].text == playerSide && Buttontextlist[7].text == playerSide && Buttontextlist[8].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[0].text == playerSide && Buttontextlist[3].text == playerSide && Buttontextlist[6].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[1].text == playerSide && Buttontextlist[4].text == playerSide && Buttontextlist[7].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[2].text == playerSide && Buttontextlist[5].text == playerSide && Buttontextlist[8].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[0].text == playerSide && Buttontextlist[4].text == playerSide && Buttontextlist[8].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[2].text == playerSide && Buttontextlist[4].text == playerSide && Buttontextlist[6].text == playerSide)
        {
            GameOver();
        }

        Draw();
        ChangeSides();
    }

    private void Draw()
    {
        if (moveCount >= 9)
        {
            SetGameOverText("Its a Draw");
            restartBtn.SetActive(true);
        }
    }

    void GameOver()
    {
        for(int i = 0; i < Buttontextlist.Length; i++)
        {
            Buttontextlist[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText( playerSide + " Wins!");
        isWinLose = true;
        restartBtn.SetActive(true);
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (!isWinLose)
        {
            if (playerSide == "X")
            {
                SetPlayerColors(playerX, playerO);
            }
            else
            {
                SetPlayerColors(playerO, playerX);
            }
        }
       
    }

    void SetGameOverText(string value)
    {
        GameOverPanel.SetActive(true);
        gameoverText.text = value;
    }

    public void ResetBtn()
    {
        SceneManager.LoadScene(0);
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activatePlayerColor.panelColor;
        newPlayer.text.color = activatePlayerColor.textColor;
        oldPlayer.panel.color = deAactivatePlayerColor.panelColor;
        oldPlayer.text.color = deAactivatePlayerColor.textColor;
    }
}
