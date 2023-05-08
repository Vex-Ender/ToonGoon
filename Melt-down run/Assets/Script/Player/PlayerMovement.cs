using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [SerializeField]
    float speed = 0f;
    [SerializeField]
    float jumpforce = 0f;
    float moveHorizontal;
    float moveVertical;
    bool IsJumping;

    Animator animator;
    //private string currentState;

    /*//Animation States
    const string Player_Idle = "Player_idle";
    const string Player_Jump = "Player_jump";
    const string Player_Run = "Player_run";
    const string Player_Fall = "Player_fall";
    public enum PlayerState
    { 

        Player_idle,
        Player_jump,
        Player_run,
        Player_fall,
    }*/

    private FacingDirection _playerDirection;
    public enum FacingDirection
    {
        Left,
        Right,
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        _playerDirection = FacingDirection.Right;

        float Speed = speed;
        float JumpForce = jumpforce;
        IsJumping = false;
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");


        if (moveHorizontal > 0)
        {
            switch (_playerDirection)
            {
                case FacingDirection.Left:
                    Flip();
                    break;
                case FacingDirection.Right:
                    break;
            }
            _playerDirection = FacingDirection.Right;
        }
        if (moveHorizontal < 0)
        {
            
            switch (_playerDirection)
            {
                case FacingDirection.Left:
                    break;
                case FacingDirection.Right:
                    Flip();
                    break;
            }
            _playerDirection = FacingDirection.Left;
        }
    }

    private void FixedUpdate()
    {
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * speed, 0f), ForceMode2D.Impulse);
        }
        
        if (!IsJumping && moveVertical > 0.1f) 
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpforce), ForceMode2D.Impulse); 
        }
    }

    //It tells the player that touching the ground you can jump.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            IsJumping = false;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsJumping = true;
            
        }
    }

    void Flip()
    {
        //This will help player to flip left and right
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1f;
        gameObject.transform.localScale = currentScale;
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        
    }

    /*void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //Ressign the current state
        currentState = newState;
    }*/
}
