using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MovementState { idle, walk, run, crouch, crawl, die }
public enum LightState { day, night, light }
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private SpriteRenderer _sprite;
    private Animator _anim;
    private AudioSource _audioSources;
    private Transform normalLightPos, squatsLightPos, lightTrans;

    [HideInInspector]
    public InteractionTipsController interactionTipsController;

    private float dirX = 0f;
    [SerializeField] private float crawlSpeed = 2f;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float jumpForce = 14f;



    private MovementState state = MovementState.idle;
    public MovementState GetMovementState()
    {
        return state;
    }
    private LightState lightState;
    public LightState GetLightState
    {
        get
        {
            return lightState;
        }
        set
        {
            this.lightState = value;
        }
    }

    private Vector2 _velocity;


    private bool disableInput = false;
    private bool dead = false;

    private void Awake()
    {
        interactionTipsController = GetComponent<InteractionTipsController>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        lightTrans = transform.GetChild(2);
        normalLightPos = transform.GetChild(0);
        squatsLightPos = transform.GetChild(1);
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _audioSources = GetComponent<AudioSource>();

        lightState = GameSave.instance.currentLightState;

        InventoryUI.FindInstance().OnInventoryOpenCallback += DisableInput;
        InventoryUI.FindInstance().OnInventoryCloseCallback += EnableInput;
    }

    // Update is called once per frame
    private void Update()
    {
        if (dead)
        {
            // Debug.Log("died");
            state = MovementState.die;
            _audioSources.Stop();
            _velocity = Vector2.zero;
        }
        else
        {
            if (!disableInput)
            {
                CheckPlayerInput();
            }
            else
            {
                state = MovementState.idle;
                _audioSources.Stop();
                _velocity = Vector2.zero;
            }
            StateMachine();
            CheckInteraction();
            ChangeState();
        }

        UpdateAnimationState();
    }
    private void CheckInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.GetInteractionTarget() == null) return;
            float x = Mathf.Abs(GameManager.instance.GetInteractionTarget().transform.position.x - transform.position.x);
            float mutiX = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x);
            if ((x < 3 && !InteractionUIManager.instance.GetInteractionState()) || (mutiX < 3 && !InteractionUIManager.instance.GetInteractionState()))
            {
                state = MovementState.idle;
                _audioSources.Stop();
                _velocity = Vector2.zero;
                GameManager.instance.GetInteractionTarget().OnPlayerInteraction(this);
                GameHalper.instance.Wait(0.05f, () => _anim.SetInteger("state", 0));
            }
        }

    }

    private void CheckPlayerInput()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (dirX == 0)
            { state = MovementState.crouch; }
            else
            {
                state = MovementState.crawl;
            }
        }
        else if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (dirX != 0))
        {
            state = MovementState.run;
        }
        else if (dirX == 0)
        {
            state = MovementState.idle;
            _audioSources.Stop();
        }
        else
        {
            state = MovementState.walk;
            if (!_audioSources.isPlaying) _audioSources.Play();
        }
    }

    private void DisableInput()
    {
        // _rb.velocity = Vector2.zero;
        disableInput = true;
    }

    private void EnableInput()
    {
        // _rb.velocity = Vector2.zero;
        disableInput = false;
    }

    private void StateMachine()
    {
        switch (state)
        {
            case MovementState.die:
                // _rb.velocity = new Vector2(dirX * crouchSpeed, _rb.velocity.y);
                _velocity = new Vector2(0, 0);
                break;
            case MovementState.idle:
                // _rb.velocity = new Vector2(0, _rb.velocity.y);
                _velocity = new Vector2(0, _rb.velocity.y);
                break;
            case MovementState.walk:
                // _rb.velocity = new Vector2(dirX * walkSpeed, _rb.velocity.y);
                _velocity = new Vector2(dirX * walkSpeed, _rb.velocity.y);
                break;
            case MovementState.run:
                // _rb.velocity = new Vector2(dirX * runSpeed, _rb.velocity.y);
                _velocity = new Vector2(dirX * runSpeed, _rb.velocity.y);
                break;
            case MovementState.crouch:
                // _rb.velocity = new Vector2(dirX * crouchSpeed, _rb.velocity.y);
                _velocity = new Vector2(0, _rb.velocity.y);
                break;
            case MovementState.crawl:
                // _rb.velocity = new Vector2(dirX * crouchSpeed, _rb.velocity.y);
                _velocity = new Vector2(dirX * crawlSpeed, _rb.velocity.y);
                break;
        }

        UpdateAnimationState();
        UpdateLightPosition();
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.Lerp(_rb.velocity, _velocity, Time.fixedDeltaTime * 8f);
        // _rb.velocity = _velocity;
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (dirX < 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        _anim.SetInteger("state", (int)state);
    }
    private void UpdateLightPosition()
    {
        if (state == MovementState.crouch || state == MovementState.crawl)
        {
            lightTrans.position = squatsLightPos.position;
        }
        else
        {
            lightTrans.position = normalLightPos.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
    void ChangeState()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StateAI();
            GameSave.instance.currentLightState = lightState;
        }
        if (lightState == LightState.day)
        {
            GameHalper.GetChildGameObjectByName(transform, "Point Light", false).SetActive(false);
            GetComponent<Animator>().SetLayerWeight(1, 0);
        }
        else if (lightState == LightState.night)
        {
            GameHalper.GetChildGameObjectByName(transform, "Point Light", false).SetActive(false);
            GetComponent<Animator>().SetLayerWeight(1, 1);
        }
        else
        {
            GameHalper.GetChildGameObjectByName(transform, "Point Light", false).SetActive(true);
            GetComponent<Animator>().SetLayerWeight(1, 1);
        }

    }
    public void DieState()
    {
        dead = true;
        state = MovementState.die;
    }
    void StateAI()
    {
        if (lightState == LightState.day)
        {
            if (StateUIManager.instance.GetState("KeroseneLamp"))
            {
                lightState = LightState.night;
            }
        }
        else if (lightState == LightState.night)
        {
            if (StateUIManager.instance.GetState("matchstick"))
            {
                lightState = LightState.light;
            }
            else
            {
                lightState = LightState.day;
            }
        }
        else
        {
            lightState = LightState.day;
        }

    }


    public void FinishDeath()
    {
        Debug.Log("died end");
        FindObjectOfType<DeathScreen>().Open();
    }
}
