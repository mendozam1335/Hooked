/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle Enemy2 transition to look for player state. Can transition to
 *  look for player or move state
 * GameObjects Associated: Enemies 1 and 2
 * Files Associated:FiniteStateMachine, State, Entity, AnimationToStateMachine
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class Entity : MonoBehaviour
{
    
    public D_Entity entityData;
    public FiniteStateMachine stateMachine;
    public int FaceingDirection { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO{ get; private set; }
    public AnimationToStateMachine atsm { get; private set; }
    public int lastDamageDirection { get; private set; }
    
    public Vector2 velocityWorkspace;
    public float currentHealth;
    private float currentStunResitance;
    private float lastDamageTime;
    protected bool isStunned;
    protected bool isDead;
   

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;
    [SerializeField] private Transform groundCheck;

    public virtual void Awake()
    {
        currentHealth = entityData.maxHealth;
        currentStunResitance = entityData.stunResistance;
        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
        atsm = aliveGO.GetComponent<AnimationToStateMachine>();
        FaceingDirection = 1;
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
        if (Time.time >= lastDamageTime + entityData.stunRecoveryTimer)
        {
            ResetStunResistance();
        }
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(FaceingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkspace;
    }

    public virtual void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        velocityWorkspace.Set(angle.x * velocity * direction, angle.y * velocity);
        rb.velocity = velocityWorkspace;
    }

    public virtual bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, entityData.groundCheckRadius, entityData.whatIsGround);
    }
    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance,
            entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance,
            entityData.whatIsGround);
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance,
            entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance,
            entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.closeRangeActionDistance,
            entityData.whatIsPlayer);
    }

    // public virtual bool CheckStoppedMoving()
    // {
    //     if (Mathf.Abs(rb.velocity.x) < 0.1)
    //     {
    //         return true;
    //     }
    //
    //     return false;
    // }

    public virtual void DamageHop(float velocity)
    {
        velocityWorkspace.Set(rb.velocity.x, velocity);
        rb.velocity = velocityWorkspace;
    }

    public virtual void ResetStunResistance()
    {
        isStunned = false;
        currentStunResitance = entityData.stunResistance;
    }
    
    public virtual void Damage(AttackDetails attackDetails)
    {
        currentHealth -= attackDetails.damageAmount;
        lastDamageTime = Time.time;

        currentStunResitance -= attackDetails.stunDamageAmount;
        DamageHop(entityData.damageHopSpeed);
        Instantiate(entityData.hitparticle, aliveGO.transform.position,
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
        if (attackDetails.position.x >= aliveGO.transform.position.x)
        {
            lastDamageDirection = -1;
        }
        else
        {
            lastDamageDirection = 1;
        }

        if (currentStunResitance <= 0f)
        {
            isStunned = true;
        }

        if (currentHealth <= 0f)
        {
            isDead = true;
        }
    }
    public virtual void Flip()
    {
        FaceingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f,0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * FaceingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
        
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.closeRangeActionDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.minAgroDistance), 0.2f);
        Gizmos.DrawWireSphere(playerCheck.position + (Vector3)(Vector2.right * entityData.maxAgroDistance), 0.2f);
    }
}
