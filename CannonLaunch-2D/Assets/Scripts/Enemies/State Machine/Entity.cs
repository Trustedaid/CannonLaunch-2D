using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }




    public virtual void Start()
    {
        
        
        stateMachine = new FiniteStateMachine();
    }
    public virtual void Update()
    {
      
    }
    public virtual void FixedUpdate()
    {
       

    }

    
    public virtual void OnDrawGizmos()
    {
        
    }
}
