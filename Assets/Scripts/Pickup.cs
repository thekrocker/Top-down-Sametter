using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Weapon weaponToEquip;
    public GameObject pickUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);

            Instantiate(pickUpEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }


}
