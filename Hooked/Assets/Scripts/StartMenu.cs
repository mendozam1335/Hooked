/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Class to handle interactions for the pause menu including, resume, quit, and credits
 * GameObjects associated: Branch, Arrow
 * Files Associated: LoadLevelTransitions
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public LoadLevelTransitions llt;
    public void Play()
    {
        llt.LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    
    
}
