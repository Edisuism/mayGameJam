using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType { red, green, blue, yellow, magenta, cyan, white, black }

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
        LayerGet();
        
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

    void LayerGet() {
        // Set the enemy layer
        switch (colorType) {
            case ColorType.red:
                gameObject.layer = LayerMask.NameToLayer("Red");
                break;
            case ColorType.green:
                gameObject.layer = LayerMask.NameToLayer("Green");
                break;
            case ColorType.blue:
                gameObject.layer = LayerMask.NameToLayer("Blue");
                break;
            default:
                gameObject.layer = LayerMask.NameToLayer("Default");
                break;
        }
    }

    private void SetSpriteColour(Color colour) {
        spriteRenderer.color = colour;
    }

    private void ColorGet(ColorType color)
    {
        switch (color)
        {
            case ColorType.red:
                SetSpriteColour(Color.red);
                break;
            case ColorType.green:
                SetSpriteColour(Color.green);
                break;
            case ColorType.blue:
                SetSpriteColour(Color.blue);
                break;
            case ColorType.yellow:
                SetSpriteColour(Color.yellow);
                break;
            case ColorType.magenta:
                SetSpriteColour(Color.magenta);
                break;
            case ColorType.cyan:
                SetSpriteColour(Color.cyan);
                break;
            case ColorType.white:
                SetSpriteColour(Color.white);
                break;
            case ColorType.black:
                SetSpriteColour(Color.black);
                break;
        }
    }

    public void ColorTint(ColorType color) {
        switch (color) {
            case ColorType.red:
                switch (colorType) {
                    case ColorType.red:
                        SetSpriteColour(Color.black);
                        break;
                    case ColorType.yellow:
                        SetSpriteColour(Color.green);
                        break;
                    case ColorType.magenta:
                        SetSpriteColour(Color.blue);
                        break;
                    default:
                        ColorGet(colorType);
                        break;
                }
                break;
            case ColorType.green:
                switch (colorType) {
                    case ColorType.green:
                        SetSpriteColour(Color.black);
                        break;
                    case ColorType.yellow:
                        SetSpriteColour(Color.red);
                        break;
                    case ColorType.cyan:
                        SetSpriteColour(Color.blue);
                        break;
                    default:
                        ColorGet(colorType);
                        break;
                }
                break;
            case ColorType.blue:
                switch (colorType) {
                    case ColorType.blue:
                        SetSpriteColour(Color.black);
                        break;
                    case ColorType.cyan:
                        SetSpriteColour(Color.green);
                        break;
                    case ColorType.magenta:
                        SetSpriteColour(Color.red);
                        break;
                    default:
                        ColorGet(colorType);
                        break;
                }
                break;
        }
    }

}
