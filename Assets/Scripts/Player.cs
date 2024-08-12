using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    Shooter shooter;
    private float realHorizontalBounds;
    private float realVerticalBounds;

    private Vector2 rawInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    
    void Awake() 
    {
        shooter = GetComponent<Shooter>();    
    }

    void Start() 
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        realHorizontalBounds = gameObject.GetComponentInChildren<Renderer>().bounds.extents.x;
        realVerticalBounds = gameObject.GetComponentInChildren<Renderer>().bounds.extents.y;

        paddingLeft += realHorizontalBounds;
        paddingRight += realHorizontalBounds;
        paddingTop += realVerticalBounds;
        paddingBottom += realVerticalBounds;
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom , maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
