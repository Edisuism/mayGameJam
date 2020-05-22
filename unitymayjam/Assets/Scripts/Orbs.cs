using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbColor { red, green, blue }

public class Orbs : MonoBehaviour
{
    public OrbColor orbColor;
    private SpriteRenderer spriteRenderer;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetOrbColor(orbColor);
    }

    void GetOrbColor(OrbColor orb)
    {
        switch (orb)
        {
            case OrbColor.red:
                spriteRenderer.color = Color.red;
                break;
            case OrbColor.green:
                spriteRenderer.color = Color.green;
                break;
            case OrbColor.blue:
                spriteRenderer.color = Color.blue;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetMouseButton(0))
            {
                player.GetComponent<PlayerController>().OrbPickup(spriteRenderer.color);
                Destroy(gameObject);
            }
        }
    }
}
