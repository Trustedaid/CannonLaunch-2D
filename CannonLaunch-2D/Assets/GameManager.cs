using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton class: GameManager

    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    Camera cam;

    // public CannonballController cannonball;
    public Trajectory trajectory;


    [SerializeField]
    public CannonballController cannonPrefab;

    [SerializeField]
    public float pushForce = 4f;
    public float shootCooldown;
    private float lastInputTime = Mathf.NegativeInfinity;
    private float inputTimer;

    private bool isShooting;
    private bool isDragging = false;
    private bool gotInput;
    

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;

    float distance;


    void Start()
    {
        cam = Camera.main;
       // cannonball.DeactivateRb();
    }

    void Update()
    {
        Shoot();
    }


    void OnDragStart()
    {
     //   cannonball.DeactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();

    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        // Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(transform.position, force);
    }

    void OnDragEnd()
    {
        //push the ball
        //   cannonball.ActivateRb();

        //   cannonball.Launch(force);

        CannonballController controller = GameObject.Instantiate(cannonPrefab);
        controller.transform.position = transform.position;
        controller.ActivateRb();
        controller.Launch(force);
 
        trajectory.Hide();

        StartCoroutine(Reload());



    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(2); // freeze for 2 seconds the code flow
        isShooting = false;
    }
    private void Shoot()
    {

        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            isShooting = true;
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            OnDragEnd();
        }

        if (isDragging)
        {

            OnDrag();
        }

    }
    private void CheckShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
          
                gotInput = true;
                lastInputTime = Time.time;
            
        }

    }



    private void CheckShootCooldown()
    {
        if (isShooting)
        {
            gotInput = true;
        }
        if(Time.time >=  lastInputTime + inputTimer)
        {
            gotInput = false;
        }
    }

}
