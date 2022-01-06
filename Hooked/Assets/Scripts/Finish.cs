/*---------The Platformers-------
 * Contributors: Mario Mendoza, John Paduh, Dillion
 * Prupose: Causes player to move to next level upon reaching portal
 * GameObjects associated: Portal
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;

public class Finish : MonoBehaviour
{

    public LoadLevelTransitions llt;
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && !levelCompleted)
        {

            levelCompleted = true;
            Invoke("CompleteLevel",2f);
        }
    }

    private void CompleteLevel()
    {
       llt.LoadNextLevel();
    }
}
