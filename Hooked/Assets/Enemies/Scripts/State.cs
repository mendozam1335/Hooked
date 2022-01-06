/*---------The Platformers-------
 * Contributors: Mario Mendoza
 * Prupose: Parent class for all states. has enter, exit, dochecks, logic update and physics update
 * GameObjects Associated: Enemies 1 and 2 
 * Files Associated: FiniteStateMachine
 * Source:https://www.youtube.com/channel/UCKrEpRpu7isPB3p_nRv9Jwg
 *--------------------------------*/
using UnityEngine;

public class  State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    public float startTime { get; protected set; }
    protected string animBoolName;

    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName,true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName,false);
    }
    public virtual void LogicUpdate(){}

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    
    public virtual void DoChecks(){}
}
