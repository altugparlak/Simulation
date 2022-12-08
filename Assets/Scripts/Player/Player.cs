using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
    [SerializeField] private float playerMovementSpeed = 1f;
    [SerializeField] private Animator arm_animator;
    [SerializeField] private Animator body_animator;
    [SerializeField] private Animator hair_animator;

    private float decidedMovementSpeed;
    CharacterController characterController;
    Rigidbody2D rb;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();

        decidedMovementSpeed = playerMovementSpeed;
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
                body_animator.SetInteger("TurningState", 1);
                arm_animator.SetInteger("TurningState", 1);
                hair_animator.SetInteger("TurningState", 1);
            }
            else if (moveHorizontal > 0)
            {
                //Right
                body_animator.SetInteger("TurningState", 3);
                arm_animator.SetInteger("TurningState", 3);
                hair_animator.SetInteger("TurningState", 3);
            }
            else if (moveVertical < 0)
            {
                //Down
                body_animator.SetInteger("TurningState", 2);
                arm_animator.SetInteger("TurningState", 2);
                hair_animator.SetInteger("TurningState", 2);
            }
            else if (moveVertical > 0)
            {
                //Up
                body_animator.SetInteger("TurningState", 4);
                arm_animator.SetInteger("TurningState", 4);
                hair_animator.SetInteger("TurningState", 4);
            }
        }
        else
        {
            //Steady
            body_animator.SetInteger("TurningState", 0);
            arm_animator.SetInteger("TurningState", 0);
            hair_animator.SetInteger("TurningState", 0);
        }

        // Adjusting the speed
        if (moveHorizontal != 0 && moveVertical != 0)
            playerMovementSpeed = decidedMovementSpeed / Mathf.Sqrt(2);
        else
            playerMovementSpeed = decidedMovementSpeed;

        rb.MovePosition(rb.position + movement * playerMovementSpeed);

    }

    
}
