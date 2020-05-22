using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTarget;
    public float SPEED;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(FollowTarget.position.x, FollowTarget.position.y, -10f), SPEED);
    }
}
