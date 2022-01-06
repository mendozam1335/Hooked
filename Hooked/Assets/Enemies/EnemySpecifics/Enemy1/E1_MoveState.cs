/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle transitions to and from Move state
 * GameObjects Associated: Enemy 1 
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
public class E1_MoveState : MoveState
{

    private Enemy1 enemy;
    public E1_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    /**E1 MoveState update method. Called every frame*/
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAgroRange) // if player in range
        {
            stateMachine.ChangeState(enemy.playerDetectedState); 
        }
        else if (isDetectingWall || !isDetectingLedge) //if reached a ledge or wall
        {
            enemy.idleState.setFlipAfterIdle(true); //flip enemy 
            stateMachine.ChangeState(enemy.idleState); //change to idle
        }
    }
    
}
