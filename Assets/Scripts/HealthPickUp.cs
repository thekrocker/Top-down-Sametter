using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    Player playerScript;
    public int healAmount;
    public GameObject pickUpEffect;


    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.HealYourself(healAmount);

            Instantiate(pickUpEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);

        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
