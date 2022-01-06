/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Class to handle the movement, rotation and attack of the projectiles in the game
 * GameObjects associated: Branch
 * Files Associated: AttackDetails
 * Source:
 *--------------------------------*/
using UnityEngine;

public class Branch : MonoBehaviour
{

    private AttackDetails attackDetails;
    private Rigidbody2D rb;
    public float speed = 2f;

    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private LayerMask whatIsPlayer;

    [SerializeField] private Transform damagePosition;

    [SerializeField] private float damageRadius;
    [SerializeField] private float destroyTimer = 2f;

    private bool hasHitGround;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHitGround)
        {
            attackDetails.position = transform.position;

        }
    }
    
    private void FixedUpdate()
    {
        if (!hasHitGround)
        {
            Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

            if (damageHit)
            {
                damageHit.transform.SendMessage("Damage", attackDetails);
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

    private void Despawn()
    {
        Destroy(gameObject);
    }

    public void FireProjectile(float speed, float damage)
    {
        this.speed = speed;
        attackDetails.damageAmount = damage;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }
}
