using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerController player;
    public float height = 11;
    public float smoothTime;
    Vector3 smoothV;

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(player.rb.position.x, 7, player.rb.position.z - 5);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref smoothV, smoothTime);
    }
}
