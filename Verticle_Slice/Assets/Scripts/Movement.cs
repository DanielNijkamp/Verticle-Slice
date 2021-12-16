using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float moveSpeed = 5f;
    public bool isIdle;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Sprite[] idlesprites;
    public int direction;

    public bool isHitting;

    Vector2 movement;
    private void Start()
    {
        isHitting = false;
    }
    void Update()
    {
        if (movement.x == 0 && movement.y == 0)
        {
            isIdle = true;
            animator.SetBool("IsIdle", true);
            spriteRenderer.sprite = idlesprites[direction];
            if (isHitting)
            {
                animator.enabled = true;
            }
            else
            {
                animator.enabled = false;
                animator.StopPlayback();
            }
        }
        else
        {
            animator.enabled = true;
            isIdle = false;
            animator.SetBool("IsIdle", false);

        }

    }
    
    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (!isIdle)
        { 
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }
        switch (movement.y)
        {
            case -1f:
                animator.SetInteger("Direction", 0);
                direction = 0;
                break;
            case 1f:
                animator.SetInteger("Direction", 1);
                direction = 1;
                break;

        }
        switch (movement.x)
        {
            case -1f:
                animator.SetInteger("Direction", 2);
                direction = 2;
                break;
            case 1f:
                animator.SetInteger("Direction", 3);
                direction = 3;
                break;

        }
        
    }
    
}
