using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float smoothing = 5f;

    public Vector3 offset = new Vector3(0f, 0f, -5f);

    void FixedUpdate()
    {
        // Calculate the target position by adding an offset to the player's position
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position using Lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);


    }

}


