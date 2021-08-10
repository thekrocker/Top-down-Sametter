using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] float cameraSpeed;


    float minX = -22f;
    float maxX = 30f;
    float minY = -15f;
    float maxY = 13f;
    void Start()
    {
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(playerTransform != null) // player ölürse bişi yapma anlamında. player öldüğünde takip edilecek bir şey kalmayacak.

        {

            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);


            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), cameraSpeed);

        }
    }
}
