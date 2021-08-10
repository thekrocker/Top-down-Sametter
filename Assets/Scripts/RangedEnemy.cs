﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{

    public float stopDistance;
    private float attackTime;

    public Transform shotPoint;
    public GameObject bullet;

    private Animator anim;
    
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)

        { if (Vector2.Distance(transform.position, player.position) > stopDistance)

            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            }

        if (Time.time >= attackTime)
            {

                attackTime = Time.time + timeBetweenAttacks;
                anim.SetTrigger("attack");
            }
                
                    
                    
                    
                    }
        
    }

    public void RangedAttack()
    {


         if (player != null)

        {
            Vector2 direction = player.position - shotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shotPoint.rotation = rotation;

            Instantiate(bullet, shotPoint.position, shotPoint.rotation);

        }
      

    }
}