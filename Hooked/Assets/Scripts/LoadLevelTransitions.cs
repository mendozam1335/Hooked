/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Load transitions at the start and end of scenes
 * GameObjects associated: LoadNextSceneTransition, Animator
 * Files Associated:
 * Source:
 *--------------------------------*/
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelTransitions : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
