/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle transitions between Idle state and move state
 * GameObjects Associated: Enemy 1 
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
public class E1_IdleState : IdleState
{
    private Enemy1 enemy;

    public E1_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
   
    /**E1 idle state update method*/
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAgroRange) //if player is close to enemy
        {
            stateMachine.ChangeState(enemy.playerDetectedState); //detect the player
        }
        else if (isIdleTimeOver) //stop being idle and move to a different state
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    
}
