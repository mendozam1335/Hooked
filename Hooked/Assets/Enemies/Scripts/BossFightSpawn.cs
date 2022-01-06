/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle the cutscene starts for the boss fight. 
 * GameObjects Associated: Boss Fight spawn, Boss
 * Files Associated:
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.Playables;

public class BossFightSpawn : MonoBehaviour
{

    private GameObject boss;
    [SerializeField] private PlayableDirector cutscene;
    
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindWithTag("Boss");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            cutscene.Play();
            cutscene.played += CutsceneOnplayed;
            Debug.Log("Play cutscene");

            cutscene.stopped += CutsceneOnstopped;
        }
    }

    public void CutsceneEnd()
    {
        Debug.Log("Cutscene ended in CutsceneEnd");
    }
    private void CutsceneOnplayed(PlayableDirector obj)
    {
        Debug.Log("Cutscene Started");
    }

    private void CutsceneOnstopped(PlayableDirector obj)
    {
        Debug.Log("Cutscene Ended");
    }
}
