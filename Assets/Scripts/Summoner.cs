using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    private Vector2 targetPosition; // selected area where spawns mobs.
    private Animator anim;

    public float timeBetweenSummons;
    private float summonTime;

    public Enemy enemyToSummon;

    public float attackSpeed;
    public float stopDistance;
    private float attackTime;

    public override void Start()
    {
        base.Start(); // enemy nin start methodunu çağırır.

        DefineRandomPlace();

    }

    private void DefineRandomPlace()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);  // target positionu random şekilde belirlenen koordinatlara atadık.
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Şimdi oraya yönlendireceğiz.

        if(player != null)  // eğer player canlıysa.. bu kodu çalıştır. ölüyse zaten yapma. Null exceptionlara karşı iyi bi önlem.
        {
            if (Vector2.Distance(transform.position, targetPosition) > .5f )  // eğer şuanki pozisyonu ile targetpozisoynunun uzaklığı o sayıdan uzaksa..
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            } 
            
            else  // eğer gerekli yere ulaştıysa. 
            {
                anim.SetBool("isRunning", false);

                if(Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }

            }
            if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {

                if (Time.time > attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
                // Eğer melee enemy'nin pozisyonu ile player'in pozisyonu stopDistanceden büyükse, ona doğru koş.
            }

        }

       

    }

    public void SummonMobs()
    {
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);

        }
    }

    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position; // before he leaps
        Vector2 targetPosition = player.position;

        float percent = 0;

        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;

            float formula = (-Mathf.Pow(percent, 2) + percent) * 4; // Leap animasyon formülü

            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);

            yield return null;
        }
    }
}
