/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: control for the Projectile fired
 *  from boss 2
 * GameObjects Associated: Magic Orb, Explosion VFX
 * Files Associated: AttackDetails
 * Source:
 *--------------------------------*/
using UnityEngine;

namespace Enemies.EnemySpecifics.Boss2
{
    public class MagicOrb : MonoBehaviour
    {
        private AttackDetails attackDetails;
        private Rigidbody2D rb;
        public float speed = 2f;

        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private float damageRadius;
        [SerializeField] private float destroyTimer = 0.5f;
        [SerializeField] private float explosionRadius;
        [SerializeField] private GameObject explosion;
        
        private bool hasHitGround;
        private bool exploded = false;
            
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
                Collider2D damageHit = Physics2D.OverlapCircle(transform.position, damageRadius, whatIsPlayer);
                Collider2D groundHit = Physics2D.OverlapCircle(transform.position, damageRadius, whatIsGround);
        
                if (damageHit)
                {
                    Explode();
                    damageHit.transform.SendMessage("Damage", attackDetails);
                    Destroy(gameObject);
                }
        
                if (groundHit && !exploded)
                {
                    hasHitGround = true;
                    rb.gravityScale = 0f;
                    rb.velocity = Vector2.zero;
                    Explode();
                }
                if (hasHitGround)
                {
                    Invoke("Despawn", destroyTimer);
                }
        
            }
        
        }
        
        private void Despawn()
        {
            Destroy(gameObject);
        }

        private void Explode()
        {
            GameObject.Instantiate(explosion, transform.position, explosion.transform.rotation);
            damageRadius = explosionRadius;
            exploded = true;
        }
        public void FireProjectile(float speed, float damage)
        {
            this.speed = speed;
            attackDetails.damageAmount = damage;
        }
            
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, damageRadius);
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}