/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle transitions between Charge state and other states
 * GameObjects Associated: Enemy 1 
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;
    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    /**E1 update method. Called every frame*/
    public override void LogicUpdate() 
    {
        base.LogicUpdate();
        if (performCloseRangeAction) // check if close enough to perform close action
        {
            stateMachine.ChangeState(enemy.meleeAttackState); //change states to close range action
        }
        else if (!isDetectingLedge || isDetectingWall) //if reached a ledge or wall
        {
            stateMachine.ChangeState(enemy.lookForPlayerState); //change states to look for player
        }
        
        else if (isChargeTimeOver) //if was able to do full animation 
        {
            if (isPlayerInMinAgroRange) //if player still in range 
            {
                stateMachine.ChangeState(enemy.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState); //didnt find player so look
            }
        }
    }

    
}
