/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle transitions to and from Melee attack state
 * GameObjects Associated: Enemy 1 
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class E1_MeleeAttackState : MeleeAttackState
{

    private Enemy1 enemy;
    public E1_MeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attacakPosition, D_MeleeAttackState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, attacakPosition, stateData)
    {
        this.enemy = enemy;
    }
    
    /**E1 MelleAtack State. Called every frame*/
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished) //need to do entire animation
        {
            if (isPlayerInMinAgroRange) //after done, check if player still in range
            {
                stateMachine.ChangeState(enemy.playerDetectedState); 
            }
            else //if not in range, look for player
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
    }

   
}
