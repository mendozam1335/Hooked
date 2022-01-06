/*---------The Platformers-------
 * Contributors: Patrick
 * Prupose: Allow animator to return to start menu after credits
 * GameObjects associated: Credits, Canvas, Animator
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public void End()
    {
        //load back to start menu
        SceneManager.LoadScene("StartMenu");

    }
}
