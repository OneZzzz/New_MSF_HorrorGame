using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private SpriteRenderer _sprite;
    private Animator _anim;

    private GameObject trigger;
    [SerializeField] private Transform sightRaycast;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private float walkSpeed = 4.5f;
    [SerializeField] private float runSpeed = 7f;

    private Vector2 _velocity;
    private float sightRange = 5f;
    private float facingDir = 1f;
    private float idleTime;

    private bool stateEnter = true;
    public bool canKill = false;
    private bool walkStateMove = true;

    public enum MovementState { idle, walk, run, scream }
    public MovementState state = MovementState.idle;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (state)
        {
            case MovementState.idle:
                IdleState();
                break;
            case MovementState.walk:
                WalkState();
                break;
            case MovementState.run:
                RunState();
                break;
            case MovementState.scream:
                ScreamState();
                break;
        }

        UpdateAnimationState();
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.Lerp(_rb.velocity, _velocity, Time.fixedDeltaTime * 8f);
        // _rb.velocity = _velocity;
    }

    private void IdleState()
    {
        if (stateEnter)
        {
            stateEnter = false;
            canKill = false;
            idleTime = Random.Range(1f, 2f);
        }

        FindPlayer();

        idleTime -= Time.deltaTime;
        if (idleTime <= 0f)
        {
            facingDir *= -1;
            state = MovementState.walk;
            stateEnter = true;
        }

        _velocity = new Vector2(0, _rb.velocity.y);
    }

    private void WalkState()
    {
        if (stateEnter)
        {
            canKill = false;
            stateEnter = false;
        }

        FindPlayer();
        FindWall();
        if (walkStateMove)
        {
            _velocity = new Vector2(facingDir * walkSpeed * -1, _rb.velocity.y);
        }
        else
        {
            _velocity = new Vector2(0, _rb.velocity.y);
        }
    }
    public void WalkMove()
    {
        walkStateMove = true;
    }
    public void WalkPause()
    {
        walkStateMove = false;
    }

    private void RunState()
    {
        if (stateEnter)
        {
            stateEnter = false;
        }

        canKill = true;
        FindWall();

        _velocity = new Vector2(facingDir * runSpeed * -1, _rb.velocity.y);
    }

    private void ScreamState()
    {
        if (stateEnter)
        {
            stateEnter = false;
            idleTime = 0.5f;
        }

        idleTime -= Time.deltaTime;
        if (idleTime <= 0f)
        {
            state = MovementState.run;
            stateEnter = true;
        }

        _velocity = new Vector2(0, _rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canKill && other.tag == "Player")
        {
            Debug.Log("Die");
        }
    }

    private void FindWall()
    {
        if (CheckWall())
        {
            state = MovementState.idle;
            stateEnter = true;
        }
    }

    private void FindPlayer()
    {
        if (CheckPlayer())
        {
            state = MovementState.scream;
            stateEnter = true;
        }
    }

    private void UpdateAnimationState()
    {
        transform.localScale = new Vector3(facingDir, 1, 1);
        _anim.SetInteger("state", (int)state);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(sightRaycast.position, sightRaycast.position + (Vector3)(Vector2.left * facingDir * sightRange));
    }

    private bool CheckPlayer()
    {
        return Physics2D.Raycast(sightRaycast.position, -sightRaycast.right * facingDir, sightRange, whatIsPlayer);
    }

    private bool CheckWall()
    {
        return Physics2D.Raycast(sightRaycast.position, -sightRaycast.right * facingDir, sightRange, whatIsWall);
    }
}
