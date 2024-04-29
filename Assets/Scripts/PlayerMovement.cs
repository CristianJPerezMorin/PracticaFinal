using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerInput _playerActions;

    public float horizontal, vertical, speed, turnSpeed;

    public static PlayerMovement Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerActions = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody>();

        speed = 5;
        turnSpeed = 150;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = _playerActions.actions["Move"].ReadValue<Vector2>();
        //move *= speed;
        Vector3 fwd = (transform.forward * move.y) * speed;
        fwd.y = _rb.velocity.y;


        _rb.velocity = fwd;
        transform.Rotate(0, move.x * turnSpeed * Time.deltaTime, 0);
    }
}
