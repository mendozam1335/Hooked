/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Parent class for Attack states like ranged and melee attack
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: MeleeAttackState, RangeAttackState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class AttackState : State
{
    protected Transform attacakPosition;
    protected bool isAnimationFinished;
    protected bool isPlayerInMinAgroRange;
    public AttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attacakPosition) : base(entity, stateMachine, animBoolName)
    {
        this.attacakPosition = attacakPosition;
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;
        isAnimationFinished = false;
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }
    public virtual void TriggerAttack(){}

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
