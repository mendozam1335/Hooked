/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Main class for the Enemy 1. Holds all the states
 *  this enemy can move to and their respective data. Also
 *  handles what happens if enemy dies
 * GameObjects Associated: Enemy 1 
 * Files Associated:FiniteStateMachine, State, Entity, All data for states, All states for E1
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }
    
    public E1_MeleeAttackState meleeAttackState { get; private set; }
    public E1_StunState stunState { get; private set; }
    public E1_DeadState deadState { get; private set; }
    
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_PlayerDetectedState playerDetectedData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerData;
    [SerializeField] private D_MeleeAttackState meleeAttackData;
    [SerializeField] private D_StunState stunStateData;
    [SerializeField] private D_DeadState deadStateData;

    [SerializeField] private Transform meleeAttackPosition;
    public override void Awake()
    {
        base.Awake();
        moveState = new E1_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E1_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(this, stateMachine, "PlayerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
        meleeAttackState =
            new E1_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackData, this);
        stunState = new E1_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E1_DeadState(this, stateMachine, "dead", deadStateData, this);
        
        stateMachine.Initialize(moveState);
    }

    public override void Damage(AttackDetails attackDetails)
    {
        base.Damage(attackDetails);
        if (isDead)
        {
            stateMachine.ChangeState(deadState);
        }
        else if (isStunned && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }

    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
    }
}
