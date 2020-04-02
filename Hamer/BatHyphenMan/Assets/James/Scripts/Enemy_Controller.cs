using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    public Transform Player;
    public float EnemyChaseMin = 1.5f;
    public float EnemyChaseMax = 30f;
    public Game_Manager GM;
    public Animator Enemy_anim;
    public Animator Player_anim;
    private float nextActionTime = 0.0f;
    public float period;
    public bool InstantAttack;
    private NavMeshAgent Nav;
    public bool EnemyActivated;

    public float Enemy_Health_Points;
    public float HealthBarDropSize;
    public Transform EnemyHealthBar;
    public bool EnemyCanLoseHealth;

    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
        period = Random.Range(3f, 5f);
        InstantAttack = true;
        Nav = GetComponent<NavMeshAgent>();
        EnemyActivated = false;
        EnemyCanLoseHealth = true;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.transform.position) <= EnemyChaseMax)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitinfo))
            {
                if (hitinfo.collider.gameObject.tag == "Player")
                {
                    EnemyActivated = true;
                }
            }
        }

        if (EnemyActivated == true)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > EnemyChaseMin)
            {
                Enemy_anim.SetBool("IsAttacking", false);
                Enemy_anim.SetBool("IsWalking", true);
                Nav.enabled = true;
                Nav.destination = Player.transform.position;
            }
            if (Vector3.Distance(transform.position, Player.transform.position) < EnemyChaseMin)
            {
                Enemy_anim.SetBool("IsWalking", false);
                Nav.enabled = false;

                if (InstantAttack == true)
                {
                    Enemy_anim.SetBool("IsAttacking", true);
                    Invoke("StopAttack", 0.5f);
                }
                if (InstantAttack == false)
                {
                    if (Time.time > nextActionTime)
                    {
                        nextActionTime += period;
                        Enemy_anim.SetBool("IsAttacking", true);
                        Invoke("StopAttack", 0.5f);

                    }
                }
            }
        }

        if (Enemy_Health_Points < 1)
        {
            Enemy_anim.SetBool("IsDead", true);
            Invoke("DestroyEnemy", 2);
        }

        if (EnemyHealthBar.transform.localScale == new Vector3(transform.localScale.x, 0f, transform.localScale.x))
        {
            Destroy(EnemyHealthBar);
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
                    EnemyHealthBar.transform.localScale -= new Vector3(0f, (HealthBarDropSize), 0f); //Reduce health bar size. Note the bar is not actually linked to the health but just changes at the same time.

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
                Nav.enabled = false;
                Invoke("StopStaggering", 0.5f);
            }
        }

    }

    void StopAttack()
    {
        Enemy_anim.SetBool("IsAttacking", false);
        InstantAttack = false;
    }

    void FinishAttack()
    {
        Enemy_anim.SetBool("IsAttackDone", false);
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
