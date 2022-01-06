/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose:Main Class to handle boss health,
 *  damaga, and Dead 
 * GameObjects Associated: Boss, Boss healthBar in UI
 * Files Associated: D_BossData for the data 
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class B1_Stats : MonoBehaviour
{
    [SerializeField] private D_BossData baseData;
    [SerializeField] private GameObject portal;
    [SerializeField] private PlayableDirector deadCutscene;
    [SerializeField] private HealthBar bossHealth;
    [SerializeField] private GameObject bossHealthBar;
    public float currenHealth;
    
    private bool isDead;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currenHealth = baseData.maxHealth;
        isDead = false;
        anim = GetComponent<Animator>();
        bossHealth.SetMaxHealth(currenHealth);
    }

    private void Update()
    {
        if (isDead) // update in damage function
        {
            anim.SetBool("Dead", true); //trigger death animation
        }
    }
    /**Take damage and update Boss health bar on UI*/
    public void Damage(AttackDetails attackDetails)
    {
        Instantiate(baseData.hitParticle, transform.position, baseData.hitParticle.transform.rotation);
        currenHealth -= attackDetails.damageAmount;
        bossHealth.SetHealth(currenHealth);
        
        if (currenHealth <= 0f) // check if dead
        {
            isDead = true;
            Instantiate(baseData.deadParticle, transform.position, baseData.deadParticle.transform.rotation);
        }
    }

    /**Called by animtor once dead animation is played. Destroy gameobject
     * Play cutscene. and get rid of the healthbar
     */
    public void Dead()
    {
        Destroy(gameObject);
        bossHealthBar.SetActive(false);
        deadCutscene.Play();
        //TODO: play victory sounds 
    }
}
