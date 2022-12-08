using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
    [SerializeField] private Animator arm_animator;
    [SerializeField] private Animator body_animator;
    [SerializeField] private Animator hair_animator;

    private static string PlayerTurningState;
    private float decidedMovementSpeed;
    CharacterController characterController;
    Rigidbody2D rb;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();

        decidedMovementSpeed = Settings.walkingSpeed;
        PlayerTurningState = Settings.TurningState;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (moveHorizontal !=0 || moveVertical !=0)
        {
            if (moveHorizontal < 0)
            {
                //Left
                body_animator.SetInteger(PlayerTurningState, 1);
                arm_animator.SetInteger(PlayerTurningState, 1);
                hair_animator.SetInteger(PlayerTurningState, 1);
            }
            else if (moveHorizontal > 0)
            {
                //Right
                body_animator.SetInteger(PlayerTurningState, 3);
                arm_animator.SetInteger(PlayerTurningState, 3);
                hair_animator.SetInteger(PlayerTurningState, 3);
            }
            else if (moveVertical < 0)
            {
                //Down
                body_animator.SetInteger(PlayerTurningState, 2);
                arm_animator.SetInteger(PlayerTurningState, 2);
                hair_animator.SetInteger(PlayerTurningState, 2);
            }
            else if (moveVertical > 0)
            {
                //Up
                body_animator.SetInteger(PlayerTurningState, 4);
                arm_animator.SetInteger(PlayerTurningState, 4);
                hair_animator.SetInteger(PlayerTurningState, 4);
            }
        }
        else
        {
            //Steady
            body_animator.SetInteger(PlayerTurningState, 0);
            arm_animator.SetInteger(PlayerTurningState, 0);
            hair_animator.SetInteger(PlayerTurningState, 0);
        }

        // Adjusting the speed
        if (moveHorizontal != 0 && moveVertical != 0)
            decidedMovementSpeed = Settings.walkingSpeed / Mathf.Sqrt(2);
        else
            decidedMovementSpeed = Settings.walkingSpeed;

        rb.MovePosition(rb.position + movement * decidedMovementSpeed);

    }

    
}
