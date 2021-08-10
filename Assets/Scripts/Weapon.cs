using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;

    Animator cameraShake;
    

    private void Start()
    {
        cameraShake = Camera.main.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        FollowMouse();

        InstantiateFireBall();

    }

    private void InstantiateFireBall()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {

                
             
             Instantiate(projectile, shotPoint.position, shotPoint.rotation );
                cameraShake.SetTrigger("shake");

                // Instantiate(projectile, new Vector3(shotPoint.position.x, shotPoint.position.y, 0), transform.rotation);
                shotTime = Time.time + timeBetweenShots;
            }

        }
    }

    private void FollowMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
