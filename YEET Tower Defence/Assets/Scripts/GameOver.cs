using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text winner;

    void OnEnable()
    {
        winner.text = "Player " + GameManager.winner.ID + " has won";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene"); //index 0 
    }
}
