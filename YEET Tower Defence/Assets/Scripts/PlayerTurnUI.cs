using UnityEngine;
using UnityEngine.UI;


public class PlayerTurnUI : MonoBehaviour
{
    public Text playerTurnText;

    void Update()
    {
        if (TurnManager.GetPlayerWithTurn() != null)
        {
             playerTurnText.text = "Player " + TurnManager.GetPlayerWithTurn().ID.ToString() + "'s turn";
           // playerTurnText.text = "building";
        }
        else if (TurnManager.GetPlayerWithTurn() == null)
        {
            playerTurnText.text = "not building";
        }
    }
}