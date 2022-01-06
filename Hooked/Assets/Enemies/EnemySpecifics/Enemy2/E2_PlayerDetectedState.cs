/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle Enemy2 transition to player detected state.
 *  Can transition to dodge, melee, ranged, or look for player state
 * GameObjects Associated: Enemy 2
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/

using UnityEngine;

public class E2_PlayerDetectedState : PlayerDetectedState
{
    protected Enemy2 enemy;
    public E2_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetectedState stateData,Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        {
            if (performCloseRangeAction)
            {
                if (Time.time >= enemy.dodgeState.startTime + enemy.dodgeStateData.dodgeCoolDown)
                {
                    stateMachine.ChangeState(enemy.dodgeState);
                }
                else
                {
                    stateMachine.ChangeState(enemy.meleeAttackState);
                }
            }
            else if (performLongRangeAction)
            {
                stateMachine.ChangeState(enemy.rangedAttackState);
            }
            else if(!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }
    
}
