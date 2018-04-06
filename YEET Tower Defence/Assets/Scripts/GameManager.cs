using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameEnded;
    public GameObject gameOverUI;

    public static List<Player> players;
    public Player player1;
    public Player player2;

    public static Player winner;

    void Start()
    {
        players = new List<Player>();
        players.Add(player1);
        players.Add(player2);
        gameEnded = false;
    }


	void Update ()
    {
        #region TestGameOverButton
        //if (Input.GetKeyDown("e"))
        //{
        //    EndGame();
        //}
        #endregion

        if (gameEnded)
        {
            return;
        }

        if (players[0].Lives <= 0)
        {
            winner = players[1];
            EndGame(); //player 2 wint
        }
        else if (players[1].Lives <= 0)
        {
            winner = players[0];
            EndGame(); //player1 wint
        }
	}

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }

}
