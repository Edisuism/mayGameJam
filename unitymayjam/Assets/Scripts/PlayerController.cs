using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
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
    public GameObject orbDropObject;
    private GameObject orbDropObjectInstantiation;
    private SpriteRenderer orb;
    private SpriteRenderer orbDropObjectColor;
    private RGBViewer rGBViewer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        orb = transform.Find("orb").gameObject.GetComponent<SpriteRenderer>();
        orbDropObjectColor = orbDropObject.GetComponent<SpriteRenderer>();
        rGBViewer = GetComponent<RGBViewer>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (isAlive)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            AnimationHandle(movement);

            if (Input.GetMouseButton(1))
            {
                if (orb.color == Color.red)
                {
                    OrbDrop(OrbColor.red);
                }
                if (orb.color == Color.blue)
                {
                    OrbDrop(OrbColor.blue);
                }
                if (orb.color == Color.green)
                {
                    OrbDrop(OrbColor.green);
                }
            }
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

    public void OrbPickup(Color orbColor)
    {
        orb.color = orbColor;
        orbDropObjectColor.color = orbColor;
        ColorType colorType = ColorType.white;
        if (orbColor == Color.red)
        {
            colorType = ColorType.red;
        }
        if (orbColor == Color.blue)
        {
            colorType = ColorType.blue;
        }
        if (orbColor == Color.green)
        {
            colorType = ColorType.green;
        }
        rGBViewer.SetLayer(colorType);
    }

    public void OrbDrop(OrbColor orbColor)
    {
        if (orbDropObjectColor.color != Color.white)
        {
            orbDropObjectInstantiation = Instantiate(orbDropObject, transform.position, Quaternion.identity);
            orbDropObjectInstantiation.GetComponent<Orbs>().orbColor = orbColor;
            orb.color = Color.white;
            orbDropObjectColor.color = Color.white;
            rGBViewer.SetLayer(ColorType.white);
        }

    }

}
