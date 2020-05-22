using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class RGBViewer : MonoBehaviour
{
    int LAYER_WHITE;
    int LAYER_RED;
    int LAYER_BLUE;
    int LAYER_GREEN;
    int LAYER_YELLOW;
    int LAYER_CYAN;
    int LAYER_MAGENTA;
    int LAYER_BLACK;
    int LAYER_PLAYER;

    int CurrentLayer;

    public string layerName;

    public Canvas Canvas_;

    void OnValidate()
    {
        LAYER_RED = LayerMask.NameToLayer("Red");
        LAYER_GREEN = LayerMask.NameToLayer("Green");
        LAYER_BLUE = LayerMask.NameToLayer("Blue");
        LAYER_WHITE = (1 << LAYER_RED) | (1 << LAYER_BLUE) | (1 << LAYER_GREEN);
        LAYER_YELLOW = (1 << LAYER_RED) | (1 << LAYER_GREEN);
        LAYER_CYAN = (1 << LAYER_BLUE) | (1 << LAYER_GREEN);
        LAYER_MAGENTA = (1 << LAYER_RED) | (1 << LAYER_BLUE);
        LAYER_BLACK = 0;
        LAYER_PLAYER = LayerMask.NameToLayer("Player");
    }

    public void SetLayer () {
        switch(layerName) {
            case "Red":
                CurrentLayer = LAYER_RED;
                break;
            case "Green":
                CurrentLayer = LAYER_GREEN;
                break;
            case "Blue":
                CurrentLayer = LAYER_BLUE;
                break;
            default:
                CurrentLayer = 0;
                layerName = "";
                break;
        }
        Canvas_.transform.Find("RedTint").gameObject.SetActive(false);
        Canvas_.transform.Find("GreenTint").gameObject.SetActive(false);
        Canvas_.transform.Find("BlueTint").gameObject.SetActive(false);
        if (layerName != "")
            Canvas_.transform.Find(layerName + "Tint").gameObject.SetActive(true);

        Physics2D.IgnoreLayerCollision(LAYER_PLAYER, LAYER_RED, CurrentLayer == LAYER_RED);
        Physics2D.IgnoreLayerCollision(LAYER_PLAYER, LAYER_GREEN, CurrentLayer == LAYER_GREEN);
        Physics2D.IgnoreLayerCollision(LAYER_PLAYER, LAYER_BLUE, CurrentLayer == LAYER_BLUE);

        // Turn on all colour layers
        // Turn off the colour that you're holding
        Camera.main.cullingMask = ~(1 << CurrentLayer);
        print(CurrentLayer);
    }
}


[CustomEditor(typeof(RGBViewer))]
public class RGBViewerEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RGBViewer myTarget = (RGBViewer)target;

        // myTarget.layerName = EditorGUILayout.TextField("Layer Name", myTarget.layerName);
        if(GUILayout.Button("Set Layer"))
        {
            myTarget.SetLayer();
        }
    }
}