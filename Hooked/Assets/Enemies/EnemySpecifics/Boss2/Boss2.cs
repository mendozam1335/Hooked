/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Main class for boss 2. Almost
 *  Identical to Boss1
 * GameObjects Associated: Boss 2, Projetile, Magic Orb
 * Files Associated: AttackDetails, 
 * Source:
 *--------------------------------*/
using Enemies.EnemySpecifics.Boss2;
using UnityEngine;

public class Boss2 : MonoBehaviour
{

    public bool isFlipped = false;
    private GameObject projectile;
    //private Branch branchScript;
    private MagicOrb magicOrbScript;
    private AttackDetails attackDetails;

    [SerializeField] private Transform player;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private D_BossData baseData;
    
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        //if player is on left side of boss and boss is facing right, then flip the boss
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        //if player is on right side of boss and boss is facing left, then flip the boss
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    
    public void RotateThrow()
    {
        Vector3 distance = player.position - FirePoint.position;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        
        FirePoint.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }
    
    /**Will be called on by the animator of the boss when he tranistions into the attacking state*/
    public void LongRangeAttack()
    {
        //first make sure that the position of the attack is facing the player
        RotateThrow();
        //Then instatiate the branch brojectile
        projectile =
            Instantiate(baseData.projectile, FirePoint.position, FirePoint.rotation);
        magicOrbScript = projectile.GetComponent<MagicOrb>();
        magicOrbScript.FireProjectile(baseData.projectileSpeed,baseData.projectileDamage); //set the speed and damage 

    }
    
}
