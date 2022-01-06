/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Parent class for Enemies MeleeAttack state. Inherits from AttackState
 * GameObjects associated: Enemies 1 and 2
 * Files Associated: State, AttackState
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class MeleeAttackState : AttackState
{

    protected D_MeleeAttackState stateData;
    protected AttackDetails attackDetails;
    public MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attacakPosition, D_MeleeAttackState stateData) : base(entity, stateMachine, animBoolName, attacakPosition)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        attackDetails.damageAmount = stateData.attackDamage;
        attackDetails.position = entity.aliveGO.transform.position;
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
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        Collider2D[] detectedObjects =
            Physics2D.OverlapCircleAll(attacakPosition.position, stateData.attackRadius, stateData.whatIsPlayer);

        foreach (Collider2D collider in  detectedObjects)
        {
            collider.transform.SendMessage("Damage", attackDetails);
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }
}
