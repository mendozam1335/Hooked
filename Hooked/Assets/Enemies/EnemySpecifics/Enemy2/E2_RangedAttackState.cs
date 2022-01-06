/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle Enemy2 transition to ranged attack state. Can transition to
 *  look for player or player detected
 * GameObjects Associated: Enemy 2
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class E2_RangedAttackState : RangedAttackState
{
    private Enemy2 enemy;
    public E2_RangedAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attacakPosition, D_RangedAttackState stateData, Enemy2 enemy) : base(entity, stateMachine, animBoolName, attacakPosition, stateData)
    {
        this.enemy = enemy;
    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }
}
