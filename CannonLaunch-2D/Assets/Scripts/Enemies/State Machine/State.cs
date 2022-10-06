using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    

    protected string animBoolName;

    public float startTime { get; protected set; }
    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
    public virtual void Enter() // means that this function can be redefined in the derived classes 
    {
        entity.anim.SetBool(animBoolName, true);
        startTime = Time.time;
    }
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        
    }
    public virtual void DoChecks()
    {

    }
}
