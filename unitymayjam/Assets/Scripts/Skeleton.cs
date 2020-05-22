using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType { red, green, blue, yellow, magenta, cyan, white }

public class Skeleton : MonoBehaviour
{
    public ColorType colorType;
    public GameObject pos1;
    public GameObject pos2;
    private bool goingPos1 = true;
    private float speed = 1.0f;
    private SpriteRenderer spriteRenderer;
    private float SinTime { get { return Mathf.Sin(Time.time); } }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ColorGet(colorType);
        
    }

    void Update()
    {
        transform.position = Vector2.Lerp(pos1.transform.position, pos2.transform.position, (SinTime + 1f) * .5f);
        spriteRenderer.flipX = Mathf.Cos(Time.time) < 0;
        
        /*
        if (goingPos1)
        {
            transform.Translate(pos1.transform.position * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(pos2.transform.position * speed * Time.deltaTime);
        }

        if (transform.position == pos1.transform.position)
        {
            goingPos1 = false;
        }

        if (transform.position == pos2.transform.position)
        {
            goingPos1 = true;
        }
        */
    }

    private void ColorGet(ColorType color)
    {
        switch (color)
        {
            case ColorType.red:
                spriteRenderer.color = Color.red;
                break;
            case ColorType.green:
                spriteRenderer.color = Color.green;
                break;
            case ColorType.blue:
                spriteRenderer.color = Color.blue;
                break;
            case ColorType.yellow:
                spriteRenderer.color = Color.yellow;
                break;
            case ColorType.magenta:
                spriteRenderer.color = Color.magenta;
                break;
            case ColorType.cyan:
                spriteRenderer.color = Color.cyan;
                break;
            case ColorType.white:
                spriteRenderer.color = Color.white;
                break;
        }
    }
}
