/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle transitions for look for player state
 * GameObjects Associated: Enemy 1 
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/

public class E1_LookForPlayerState : LookForPlayerState
{
    private Enemy1 enemy;
    public E1_LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }
    

    /**E1 look for player update method. Called everyframe*/
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInMinAgroRange) //if found player in agro range
        {
            stateMachine.ChangeState(enemy.playerDetectedState); //move to detected player state
        }
        else if(isAllTurnsTimeDone) //enemy will turn around trying to locate player
        {
            stateMachine.ChangeState(enemy.moveState); //if not found, move in direction facing
        }
    }

   
}
