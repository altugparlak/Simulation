using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed = 1f;
    [SerializeField] private Animator arm_animator;
    [SerializeField] private Animator body_animator;
    [SerializeField] private Animator hair_animator;


    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0f);

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


        characterController.Move(direction.normalized * playerMovementSpeed * Time.deltaTime);

    }

    
}
