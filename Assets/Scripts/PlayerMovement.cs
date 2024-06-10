using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput playerActions;
    Animator animator;

    public float speed, turnSpeed, jumpForce;
    bool isGrounded, doJump;
    private bool stayInPlate;

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
        playerActions = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        speed = 8;
        jumpForce = 4;
        turnSpeed = 90;

        isGrounded = false;
        doJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = playerActions.actions["Move"].ReadValue<Vector2>();
        Vector3 fwd = (transform.forward * move.y) * speed;
        fwd.y = rb.velocity.y;


        rb.velocity = fwd;
        transform.Rotate(0, move.x * turnSpeed * Time.deltaTime, 0);

        animator.SetFloat("Velocidad", move.y);
        animator.SetBool("Salto", doJump);

        if (isGrounded && !PuzzleManager.Instance.inPuzzleMode)
        {
            doJump = playerActions.actions["Jump"].ReadValue<float>() == 1;
        }

        if (stayInPlate)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PuzzleManager.Instance.inPuzzleMode = true;
                SceneManager.LoadScene(GameManager.Instance.gameScenePuzzle);
            }
        }
    }

    private void FixedUpdate()
    {
        if (doJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            doJump = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Terrain")) 
        {
            isGrounded = true;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("PrincipalPlate") && !GameManager.Instance.noMorePuzzles && !PuzzleManager.Instance.inPuzzleMode)
        {
            stayInPlate = true;
        }
        else
        {
            stayInPlate = false;
        }
    }
}
