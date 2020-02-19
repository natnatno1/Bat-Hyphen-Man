using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Health : MonoBehaviour
{
    public int Enemy_Health_Points;
    public Animator Enemy_anim;
    public Animator Player_anim;
    public Game_Manager GM;
    public bool EnemyCanLoseHealth;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCanLoseHealth = true;
        Enemy_Health_Points = 0;
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_Health_Points >= 5)
        {
            Enemy_anim.SetBool("IsDead", true);
            Invoke("DestroyEnemy", 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            if (GM.Attacking == true)
            {
                if (EnemyCanLoseHealth == true)
                {
                    Enemy_Health_Points += 1;
                    EnemyCanLoseHealth = false;
                    Invoke("EnemyDamageReset", 0.5f);

                    if (Enemy_Health_Points < 10)
                    {
                        Enemy_anim.SetBool("IsHit", true);
                        Invoke("StopStaggering", 0.3f);
                    }
                }
            }
        }

        if (other.gameObject.tag == "PlayerWeapon" || other.gameObject.tag == "Player")
        {
            if (GM.Blocking == true && GM.EnemyAttacking == true)
            {
                Enemy_anim.SetBool("ClashedSword", true);
                Invoke("StopStaggering", 0.5f);
            }
        }

    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void StopStaggering()
    {
        Enemy_anim.SetBool("ClashedSword", false);
        Enemy_anim.SetBool("IsHit", false);
    }

    void EnemyDamageReset()
    {
        EnemyCanLoseHealth = true;
    }
}