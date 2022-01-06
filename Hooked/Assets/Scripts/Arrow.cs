/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Class to handle the movement, rotation and attack of the Arrow
 * GameObjects associated: Arrow
 * Files Associated:
 * Source:
 *--------------------------------*/
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasHitGround = false;

    [SerializeField] private float damage = 5f;
    [SerializeField] private float destroyTimer = 2f;

    [SerializeField] private float xBounds = 30f;
    [SerializeField] private float stunDamage = 1f;
    [SerializeField] private float lowerBounds = -5f;
    [SerializeField] private float launchForce = 10f;
    
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsBoss;
    [SerializeField] private Transform damagePosition;
    [SerializeField] private float damageRadius = 0.12f;

    protected AttackDetails attackDetails;
    private float startingX;

    private float startingY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingX = transform.position.x;
        startingY = transform.position.y;
        attackDetails.damageAmount = damage;
        attackDetails.stunDamageAmount = stunDamage; 
        rb.velocity = transform.right * launchForce;
    }

    // Update is called once per frame
    void Update()
    {
        // Keep rotating arrow in direction of its velocity as long as it is still moving through the air
        if (!hasHitGround)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg; // function to generate angle based on velocity
            transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward); //rotate arrow towards that angle 
            attackDetails.position = transform.position;
           
            if (OutOfBounds()) // destroy arrow if out of sight of player
            {
                Despawn();
            }
        }

    }

    private void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D enemyHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsEnemy);
            Collider2D bossHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsBoss);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);
    
            if (enemyHit)
            {
                enemyHit.transform.parent.SendMessage("Damage", attackDetails);
                Destroy(gameObject);
            }
            
            else if (bossHit)
            {
                bossHit.transform.SendMessage("Damage", attackDetails);
                Destroy(gameObject);
            }
            if (groundHit)
            {
                hasHitGround = true;
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
                Invoke("Despawn",destroyTimer);
            }
    
        }
    }

    private bool OutOfBounds()
    {
        //if too far out of sight then despawn the arrow
        if (transform.position.x < startingX - xBounds || transform.position.x > startingX + xBounds)
        {
            return true;
        }
        //if goes below bounds then despawn the arrow
        if (transform.position.y < startingY - lowerBounds)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     
    //     rb.velocity = Vector2.zero; // stop the arrow from moving
    //     rb.isKinematic = true; // stop the arrow from being affected by other objects
    //     attackDetails.position = transform.position;
    //     attackDetails.stunDamageAmount = stunDamage; 
    //     
    //     Invoke("Despawn", destroyTimer); // As soon as you hit something, set expiration
    //     
    //     if (col.gameObject.CompareTag("Enemy") && !hasHit) //only hit the enemy once
    //     {
    //        col.transform.parent.SendMessage("Damage",attackDetails); // Damage function on enemy script
    //     }
    //     else if (col.gameObject.CompareTag("Boss") && !hasHit)
    //     {
    //         col.transform.SendMessage("Damage", attackDetails);
    //     }
    //     hasHit = true; // regardless of what you hit, disable damage
    // }
    
    /** After a certain amount of time, Destroy the arrow
     */
    private void Despawn()
    {
        Destroy(gameObject);
    }
}
