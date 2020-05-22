using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private Light2D light;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool key1 = false;
    public bool key2 = false;
    public bool key3 = false;
    public bool isAlive = true;
    private Vector2 movement;
    //public GameManager gameManager;
    private float lastdirx, lastdiry;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        light = GetComponentInChildren<Light2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (isAlive)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            AnimationHandle(movement);
        }
        else if (!isAlive)
        {
            movement.x = 0;
            movement.y = 0;
            AnimationHandle(new Vector2(0, -1));
            //gameManager.GameOver();
        }

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        // animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    private void AnimationHandle(Vector2 movement)
    {
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            lastdirx = movement.x;
        }
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            lastdirx = movement.x;
        }
        animator.SetFloat("Horizontal", movement.x);
        if (movement.x == 0)
        {
            animator.SetFloat("Horizontal", lastdirx);
        }
        float s = Mathf.Abs(movement.x) + Mathf.Abs(movement.y);
        animator.SetFloat("Speed", s);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
