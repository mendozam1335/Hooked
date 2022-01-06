/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle Enemy2 transition to stun state. Can transition to
 *  look for player or player detected
 * GameObjects Associated: Enemy 2
 * Files Associated:FiniteStateMachine, State, Entity, D_Chargestate
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
public class E2_StunState : StunState
{
    private Enemy2 enemy;
    public E2_StunState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_StunState stateData,Enemy2 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isStunTimeOver)
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
