using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Health : MonoBehaviour
{
    public int Enemy_Health_Points = 5;
    public Animator Enemy_anim;
    public Animator Player_anim;
    public Game_Manager GM;
    public bool EnemyCanLoseHealth;
    public Transform EnemyHealth;
    public float HealthBarDrop;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCanLoseHealth = true;
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_Health_Points < 1)
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
                    EnemyHealth.transform.localScale -= new Vector3(0f, HealthBarDrop, 0f); //Reduce health bar size. Note the bar is not actually linked to the health but just changes at the same time.
                    Enemy_Health_Points -= 1;
                    EnemyCanLoseHealth = false;
                    Invoke("EnemyDamageReset", 0.8f);

                    if (Enemy_Health_Points >= 1)
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
        Enemy_anim.SetBool("IsHit", false);

        Enemy_anim.SetBool("ClashedSword", false);
    }

    void EnemyDamageReset()
    {
        EnemyCanLoseHealth = true;
    }
}