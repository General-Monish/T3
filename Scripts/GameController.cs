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
    public Button button;
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
    public GameObject choseSide;

    private void Awake()
    {
        choseSide.SetActive(true);
        SetGameControllerReferanceOnButtons();
        restartBtn.SetActive(false);
        GameOverPanel.SetActive(false);
        moveCount = 0;
        
    }
    void SetGameControllerReferanceOnButtons()
    {
        for(int i = 0; i < Buttontextlist.Length; i++)
        {
            Buttontextlist[i].GetComponentInParent<GridSpace>().setGameControllerReferance(this);
        }
    }
    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
        StartGame();
    }

    void StartGame()
    {
        choseSide.SetActive(false);
        Debug.Log("Game is started");
        SetBoardInteractable(true);
        setPlayerButtons(false);
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
            SetPlayerColorsInActive();
        }
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

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activatePlayerColor.panelColor;
        newPlayer.text.color = activatePlayerColor.textColor;
        oldPlayer.panel.color = deAactivatePlayerColor.panelColor;
        oldPlayer.text.color = deAactivatePlayerColor.textColor;
    }

    void GameOver()
    {
        isWinLose = true;
        SetBoardInteractable(false);
        SetGameOverText( playerSide + " Wins!");
        restartBtn.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        GameOverPanel.SetActive(true);
        gameoverText.text = value;
    }

    public void ResetBtn() // ======================== Restart game here  ================================
    {
        SceneManager.LoadScene(0);
        setPlayerButtons(true);
        SetPlayerColorsInActive();
    }
    public void SetBoardInteractable(bool toggle)
    {
        Debug.Log("Board Is Interactable");
        for (int i = 0; i < Buttontextlist.Length; i++)
        {
            Buttontextlist[i].GetComponentInParent<Button>().interactable = true;
        }
    }
    void setPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorsInActive()
    {
        playerX.panel.color = activatePlayerColor.panelColor;
        playerX.text.color = activatePlayerColor.textColor;
        playerO.panel.color = deAactivatePlayerColor.panelColor;
        playerO.text.color = deAactivatePlayerColor.textColor;
    }
}
