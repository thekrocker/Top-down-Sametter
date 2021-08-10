using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int health;
    public Enemy[] enemies;
    public float spawnOffset;

    private int halfHealth;
    private Animator anim;

    public int damage;

    public GameObject deathEffect;
    public GameObject bossDeathSound;

    private Slider healthBar;

    SceneTransition sceneTransition;





    // Start is called before the first frame update
    void Start()
    {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();

        healthBar = FindObjectOfType<Slider>();

        healthBar.maxValue = health;
        healthBar.value = health;

        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        healthBar.value = health;


        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(bossDeathSound, transform.position, Quaternion.identity);
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);

            sceneTransition.LoadScene("Win");
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");

        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            if (collision.tag == ("Player"))
            {
                collision.GetComponent<Player>().TakeDamage(damage);

            }
        
       
    }
}

