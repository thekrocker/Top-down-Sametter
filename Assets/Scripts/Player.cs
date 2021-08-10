using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 moveAmount;
    Animator anim;
    [SerializeField] public int health;
    public Transform WeaponPickUpPosition;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtPanel;

    SceneTransition sceneTransition;

    public GameObject hurtSound;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    
    void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveInput != Vector2.zero)
        {

            anim.SetBool("isRunning", true);
        }

        else
        {
            anim.SetBool("isRunning", false);


        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        hurtPanel.SetTrigger("hurt");
        Instantiate(hurtSound, transform.position, Quaternion.identity);
        UpdateHealthUI(health);

        if (health <= 0)
        {

            Destroy(gameObject);

            sceneTransition.LoadScene("Lose");
        }

    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, WeaponPickUpPosition.transform.position, transform.rotation, transform);

    }

    void UpdateHealthUI(int currentHealth)
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {

                hearts[i].sprite = fullHeart;
            }


            else
            {
                hearts[i].sprite = emptyHeart;
            }
            


        }
    }


    public void HealYourself(int healAmount)
    {
        if (health + healAmount > 5)
        {
            health = 5;

        } else { 
        
        health+= healAmount;

        }
        UpdateHealthUI(health);


    }
}
