/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle suplamentary functions to help boss
 *  look more alive
 * GameObjects Associated: Boss, D_BossData, Branch prefab
 * Files Associated: Branch script
 * Source: https://www.youtube.com/watch?v=AD4JIXQDw0s&t=230s
 *--------------------------------*/
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public bool isFlipped = false;
    private GameObject projectile;
    private Branch branchScript;
    private AttackDetails attackDetails;
    [SerializeField] private Transform CloseRangePosition;
    [SerializeField] private Transform player;
    [SerializeField] private Transform longRangeAttackPosition;
    [SerializeField] private D_BossData baseData;

    /**Flip the sprite of the Boss so that he is always facing the player*/
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

    /**Rotate the Throwing position of the boss to face the player
     * This will allow the projectile to file in the direction of the player
     */
    public void RotateThrow()
    {
        Vector3 distance = player.position - longRangeAttackPosition.position;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        
        longRangeAttackPosition.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    /**Will be called on by the animator of the boss when he tranistions into the attacking state*/
    public void LongRangeAttack()
    {
            //first make sure that the position of the attack is facing the player
        RotateThrow();
            //Then instatiate the branch brojectile
        projectile =
            Instantiate(baseData.projectile, longRangeAttackPosition.position, longRangeAttackPosition.rotation);
        branchScript = projectile.GetComponent<Branch>();
        branchScript.FireProjectile(baseData.projectileSpeed,baseData.projectileDamage); //set the speed and damage 

    }

    /**Will be called by the animation when the boss is close enough to the player.
     * detects a hit on player using Physics2d.OverlapCircle at position of melee attack
     */
    public void CloseRangeAttack()
    {
        attackDetails.damageAmount = baseData.CRDamage;
        attackDetails.position = transform.position;
        
        Collider2D col = Physics2D.OverlapCircle(CloseRangePosition.position, baseData.closeRangeAttackRadius,
            baseData.whatIsPlayer);
        if (col != null)
        {
            col.GetComponent<PlayerStats>().Damage(attackDetails);
        }
    }

}
