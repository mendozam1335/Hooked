/*---------The Platformers-------
 * Contributors: Mario
 * Prupose: Class to handle game over scene, including play button, and quit game.Displays
 *  final score
 * GameObjects associated: Game Over Scene, Static score
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreText;
    private void Start()
    {
        scoreText.text = "Final Score: " +  ScoreData.score;
    }

    public void PlayAgain(string currentScene)
    {
        SceneManager.LoadScene(currentScene);
        ScoreData.ResetScore();
    }

    public void Quit(string mainMenuScene)
    {
        SceneManager.LoadScene(mainMenuScene);
        ScoreData.ResetScore();
    }
}
