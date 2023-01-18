using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    float walkSpeed = 4f;
    float inputHorizontal;
    float inputVertical;
    float lastInputHorizontal;
    float lastInputVertical;

    // Animator and states
    Animator animator;
    string currentState;

    // Movement animations
    const string PLAYER_MOVE_LEFT = "Player_Move_Left";
    const string PLAYER_MOVE_RIGHT = "Player_Move_Right";
    const string PLAYER_MOVE_BACK = "Player_Move_Back";
    const string PLAYER_MOVE_FRONT = "Player_Move_Front";

    // Idle animations
    const string PLAYER_IDLE_LEFT = "Player_Idle_Left";
    const string PLAYER_IDLE_RIGHT = "Player_Idle_Right";
    const string PLAYER_IDLE_BACK = "Player_Idle_Back";
    const string PLAYER_IDLE_FRONT = "Player_Idle_Front";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        // Set the default state to idle animation so the player
        // won't start without an idle animation
        ChangeAnimationState(PLAYER_IDLE_FRONT);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0) return;

            rb.velocity = new Vector2(inputHorizontal, inputVertical).normalized * walkSpeed;
            lastInputHorizontal = inputHorizontal;
            lastInputVertical = inputVertical;

            if (inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_MOVE_RIGHT);
            }
            else if (inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_MOVE_LEFT);
            }
            else if (inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_MOVE_BACK);
            }
            else if (inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_MOVE_FRONT);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
            if (lastInputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_IDLE_RIGHT);
            }
            else if (lastInputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_IDLE_LEFT);
            }
            else if (lastInputVertical > 0)
            {
                ChangeAnimationState(PLAYER_IDLE_BACK);
            }
            else if (lastInputVertical < 0)
            {
                ChangeAnimationState(PLAYER_IDLE_FRONT);
            }

        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);
        currentState = newState;
    }
}
