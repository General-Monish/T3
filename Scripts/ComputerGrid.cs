using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerGrid : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI buttonText;
    private ComputerSideGmaePlay gameController;

    public void SetSpace()
    {
        if (gameController.playerMove == true)
        {
            buttonText.text = gameController.GetPlayerSide();
            button.interactable = false;
            gameController.EndTurn();
        }
        
    }
    public void setGameControllerReferance(ComputerSideGmaePlay Controller)
    {
        gameController = Controller;
    }
}



