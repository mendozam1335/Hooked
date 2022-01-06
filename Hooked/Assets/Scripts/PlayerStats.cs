/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Manage the players health, take damage, and update the UI healthbar
 * GameObjects associated: Player, Canvas HealthBar UI
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public AttackDetails attackDetails;
    public AudioSource hitSound;
    public static bool isDead = false;

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth); //will set max int on slider for healthbar and set slider to that value
        currentHealth = maxHealth;  //initialyze current health
    }

    //wil be called by player movement when he respawns
    //Set current health to max health and reset the healthbar ui
    public void resetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    //Reduce health of player using struct with damage details. 
    public void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;
        healthBar.SetHealth(currentHealth);
        hitSound.Play();
        if (currentHealth <= 0f) //check if players health went below zero
        {
            isDead = true;
        }
        
        
    }
    //Overload Damage function using float instead of struct
     public void Damage(float damageAmount)
        {
            currentHealth -= damageAmount;
            healthBar.SetHealth(currentHealth);
            hitSound.Play();
            if (currentHealth <= 0f) //check if players health went below zero
            {
                isDead = true;
            }
        }


}
