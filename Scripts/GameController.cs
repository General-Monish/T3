using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI[] Buttontextlist;
    private string playerSide;
    private void Awake()
    {
        SetGameControllerReferanceOnButtons();
        playerSide = "X";
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
        if (Buttontextlist[0].text ==playerSide&& Buttontextlist[1].text == playerSide && Buttontextlist[2].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[3].text ==playerSide&& Buttontextlist[4].text == playerSide && Buttontextlist[5].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[6].text ==playerSide&& Buttontextlist[7].text == playerSide && Buttontextlist[8].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[0].text ==playerSide&& Buttontextlist[3].text == playerSide && Buttontextlist[6].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[1].text ==playerSide&& Buttontextlist[4].text == playerSide && Buttontextlist[7].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[2].text ==playerSide&& Buttontextlist[5].text == playerSide && Buttontextlist[8].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[0].text ==playerSide&& Buttontextlist[4].text == playerSide && Buttontextlist[8].text == playerSide)
        {
            GameOver();
        }
        if (Buttontextlist[2].text ==playerSide&& Buttontextlist[4].text == playerSide && Buttontextlist[6].text == playerSide)
        {
            GameOver();
        }
        ChangeSides();
    }
    void GameOver()
    {
        for(int i = 0; i < Buttontextlist.Length; i++)
        {
            Buttontextlist[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
}
