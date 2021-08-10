using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;
    
    [HideInInspector]
    public Transform player;

    public float speed;

    public float timeBetweenAttacks;

    [SerializeField] public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public int healthPickupChance;
    public GameObject healthPickup;

    public GameObject deathEffect;

    public GameObject deathSound;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)  // Düşmanın canı amq.
        {
            DropRandomItems();
            DropRandomHealths();


            Instantiate(deathSound, transform.position, Quaternion.identity);

            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

    }

    private void DropRandomHealths()
    {
        int randHealth = Random.Range(0, 101);
        if (randHealth < healthPickupChance)
        {
            Instantiate(healthPickup, transform.position, transform.rotation);

        }
    }

    private void DropRandomItems()
    {
        int randomNumber = Random.Range(0, 101);
        if (randomNumber < pickupChance)
        {
            GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
            Instantiate(randomPickup, transform.position, transform.rotation);

        }
    }
}
