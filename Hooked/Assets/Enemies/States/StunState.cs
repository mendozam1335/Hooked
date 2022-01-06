/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Parent class for Enemies Stun state. Inherits from State
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: State
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class StunState : State
{
    protected D_StunState stateData;
    protected bool isStunTimeOver;
    protected bool isGrounded;
    protected bool isMovementStoped;
    protected bool performCloseRangeAction;
    protected bool isPlayerInMinAgroRange;
    
    public StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isStunTimeOver = false;
        isMovementStoped = false;
        entity.SetVelocity(stateData.stunKnockBackSpeed, stateData.stunKnockBackAngle, entity.lastDamageDirection);
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.stunTme)
        {
            isStunTimeOver = true;
        }

        if (isGrounded && Time.time >= startTime + stateData.stunKnockBackTime && !isMovementStoped)
        {
            entity.SetVelocity(0f);
            isMovementStoped = true;
        }
    }

    
    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = entity.CheckGround();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
}
