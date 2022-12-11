using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(AudioSource))]
public class Player : SingletonMonobehaviour<Player>
{
    [SerializeField] private Animator arm_animator;
    [SerializeField] private Animator body_animator;
    [SerializeField] private Animator hair_animator;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject hair;

    public Outfit playerOutfit;
    private int outfitIndex = 0;
    private bool _playerInputIsDisabled = false;
    public bool PlayerInputIsDisabled { get => _playerInputIsDisabled; set => _playerInputIsDisabled = value; }

    public int playerMoney = 0;
    private static string PlayerTurningState;
    private float decidedMovementSpeed;
    CharacterController characterController;
    Rigidbody2D rb;
    float moveHorizontal;
    float moveVertical;
    Vector2 movement;

    void Start()
    {
        EventHandler.CallPlayerGoldEvent(playerMoney);
        EventHandler.GameGoldEvent += UpdatePlayerGold;

        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();

        decidedMovementSpeed = Settings.walkingSpeed;
        PlayerTurningState = Settings.TurningState;
        playerOutfit = Outfit.Default;
    }

    void Update()
    {
        if (!PlayerInputIsDisabled)
        {

            PlayerMovementInput();
            PlayerTestInput();
        }
    }

    private void FixedUpdate()
    {
        if (!PlayerInputIsDisabled)
        {
            Move();
        }
    }

    private void PlayerMovementInput()
    {
        moveHorizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
        moveVertical = UnityEngine.Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);
    }

    private void ResetMovement()
    {
        // Reset movement
        moveHorizontal = 0f;
        moveVertical = 0f;
        body_animator.SetInteger(PlayerTurningState, 0);
        arm_animator.SetInteger(PlayerTurningState, 0);
        hair_animator.SetInteger(PlayerTurningState, 0);
    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();

    }

    public void DisablePlayerInput()
    {
        PlayerInputIsDisabled = true;
    }

    public void EnablePlayerInput()
    {
        PlayerInputIsDisabled = false;
    }

    private void PlayerTestInput()
    {

        //if (UnityEngine.Input.GetKey(KeyCode.Space))
        //{
        //    playerMoney += 100;
        //    EventHandler.CallPlayerGoldEvent(playerMoney);
        //}

        //if (UnityEngine.Input.GetKey(KeyCode.E))
        //{
        //    playerMoney -= 100;
        //    EventHandler.CallPlayerGoldEvent(playerMoney);
        //}

    }

    public int GetPlayerGold()
    {
        return playerMoney;
    }

    private void UpdatePlayerGold(int gold)
    {
        playerMoney = gold;
    }

    private void OnDisable()
    {
        EventHandler.GameGoldEvent -= UpdatePlayerGold;
    }


    private void Move()
    {
        //Outfit index helps us to change outfit and animations
        switch (playerOutfit)
        {
            case Outfit.Default:
                outfitIndex = 0;
                break;
            case Outfit.Farmer:
                outfitIndex = 4;
                break;
            default:
                break;
        }
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            if (moveHorizontal < 0)
            {
                //Left
                body_animator.SetInteger(PlayerTurningState, 1 + outfitIndex);
                arm_animator.SetInteger(PlayerTurningState, 1 + outfitIndex);
                hair_animator.SetInteger(PlayerTurningState, 1);
            }
            else if (moveHorizontal > 0)
            {
                //Right
                body_animator.SetInteger(PlayerTurningState, 3 + outfitIndex);
                arm_animator.SetInteger(PlayerTurningState, 3 + outfitIndex);
                hair_animator.SetInteger(PlayerTurningState, 3);
            }
            else if (moveVertical < 0)
            {
                //Down
                body_animator.SetInteger(PlayerTurningState, 2 + outfitIndex);
                arm_animator.SetInteger(PlayerTurningState, 2 + outfitIndex);
                hair_animator.SetInteger(PlayerTurningState, 2);
            }
            else if (moveVertical > 0)
            {
                //Up
                body_animator.SetInteger(PlayerTurningState, 4 + outfitIndex);
                arm_animator.SetInteger(PlayerTurningState, 4 + outfitIndex);
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

    public void ChangeOutfit(Outfit outfit, Sprite bodyOutfit, Sprite armOutfit, Sprite hairOutfit)
    {

        playerOutfit = outfit;
        body.SetActive(false);
        arm.SetActive(false);
        hair.SetActive(false);

        body.GetComponent<SpriteRenderer>().sprite = bodyOutfit;
        arm.GetComponent<SpriteRenderer>().sprite = armOutfit;
        hair.GetComponent<SpriteRenderer>().sprite = hairOutfit;
        StartCoroutine(StartChangingClothes(0.2f));

    }

    private IEnumerator StartChangingClothes(float delay)
    {

        yield return new WaitForSeconds(delay);
        body.SetActive(true);
        arm.SetActive(true);
        hair.SetActive(true);
    }

}
