using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float lifeTime = 5;

    [SerializeField] GameObject explosion;

    [SerializeField] int damage;

    public GameObject fireSound;
    

    
    void Start()
    {


        Invoke("DestroyProjectile", lifeTime);

        Instantiate(fireSound, transform.position, Quaternion.identity);



    }


    void Update()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);

            DestroyProjectile();

        }

        if (collision.tag == "Boss")
        {
            collision.GetComponent<Boss>().TakeDamage(damage);

            DestroyProjectile();

        }


    }
}
