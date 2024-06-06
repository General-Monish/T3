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
    public GameObject backbtnn;

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

    private string computerSide;
    public bool playerMove;
    public float delay;
    private int value;

    private void Awake()
    {
        choseSide.SetActive(true);
        SetGameControllerReferanceOnButtons();
        restartBtn.SetActive(false);
        backbtnn.SetActive(false);
        GameOverPanel.SetActive(false);
        moveCount = 0;
        playerMove = true;
        
    }
/*    private void Update()
    {
        if (playerMove == false)
        {
            delay += delay + Time.deltaTime;
            if (delay >= 100)
            {
                value = UnityEngine.Random.Range(0, 8);
                if (Buttontextlist[value].GetComponentInParent<Button>().interactable == true)
                {
                    Buttontextlist[value].text = GetComputerSide();
                    Buttontextlist[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }*/
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
            //computerSide = "O";
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            //computerSide = "X";
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

    public string GetComputerSide()
    {
        return computerSide;
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
            backbtnn.SetActive(true);
            SetPlayerColorsInActive();
        }
    }


    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        //playerMove = (playerMove == true) ? false : true;
        if (!isWinLose)
        {
            if (playerSide == "X")
            //if(playerMove==true)
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
        backbtnn.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        GameOverPanel.SetActive(true);
        gameoverText.text = value;
    }

    public void ResetBtn() // ======================== Restart game here  ================================
    {
        SceneManager.LoadScene(1);
        setPlayerButtons(true);
        SetPlayerColorsInActive();
       
    }

   public void backbtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SetBoardInteractable(bool toggle)
    {
        
        for (int i = 0; i < Buttontextlist.Length; i++)
        {
            Buttontextlist[i].GetComponentInParent<Button>().interactable = toggle;
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
