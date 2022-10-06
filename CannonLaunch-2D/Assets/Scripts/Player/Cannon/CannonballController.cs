using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{


    [HideInInspector] private Rigidbody2D rb;
    [HideInInspector] private CircleCollider2D col;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

    }

    private void Start()
    {
        
    }
    void Update()
    {

    }
    public void Launch (Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    public void ActivateRb()
    {
        rb.isKinematic = false;
    }

    public void DeactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
}
