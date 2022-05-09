
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    public float turnSpeed;
    public float maxSpeed;
    private bool gameStarted;
    private PlayerInteractionManager playerInteractionManager;

    private void OnEnable()
    {
        EventManager.onGameStart += GameStartEvent;
    }
    private void OnDisable()
    {

        EventManager.onGameStart -= GameStartEvent;
    }

    void GameStartEvent()
    {
        gameStarted = true;

    }

    private void Start()
    {
        playerInteractionManager = GetComponent<PlayerInteractionManager>();
    }


    private void Update()
    {
        if (!gameStarted&&Input.GetKey(KeyCode.Mouse0))
        {
            EventManager.Instance.GameStart();
        }
    }


    public void FixedUpdate()
    {
        float horizontonal = floatingJoystick.Horizontal;
        float vertical = floatingJoystick.Vertical;

        Vector3 directon = new Vector3(horizontonal, 0, vertical);
        rb.velocity = Vector3.ClampMagnitude(directon * 3 * speed, maxSpeed);

        if (rb.velocity.magnitude < .01)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            playerInteractionManager.FindClosestObject();
            PlayerStateManager.Instance.playerState = PlayerStateManager.PlayerStates.Idle;
        }
        else
        {
            PlayerStateManager.Instance.playerState = PlayerStateManager.PlayerStates.Run;
            Vector3 lookRotation = Vector3.forward * vertical + Vector3.right * horizontonal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookRotation), turnSpeed * Time.deltaTime);
        }
       
    }

}