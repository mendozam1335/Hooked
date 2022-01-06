/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Handle the transitions between all states. Calls exit and enter of each state
 * GameObjects Associated: Enemies 1 and 2 
 * Files Associated:State
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
public class FiniteStateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
