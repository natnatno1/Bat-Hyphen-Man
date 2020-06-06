using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    private Transform Player;
    public float EnemyChaseMin = 1.5f;
    public float EnemyChaseMax = 30f;
    private Game_Manager GM;
    public Animator Enemy_anim;
    private Animator Player_anim;
    private float nextActionTime = 0.0f;
    private float period;
    private bool InstantAttack;
    private NavMeshAgent Nav;
    private bool EnemyActivated;

    public float Enemy_Health_Points;
    public float HealthBarDropSize;
    public Transform EnemyHealthBar;
    public bool EnemyCanLoseHealth;

    public float Min_Hit_Speed;
    public float Max_Hit_Speed;

    public GameObject EnemyVision;
    HumanMovement HumanMovement;

    public AudioSource AS;
    public AudioClip[] EnemySounds;
    public int CurrentSound;
    public bool AudioPlaying;
    public float AudioClipLength;


    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
        period = Random.Range(Min_Hit_Speed, Max_Hit_Speed);
        InstantAttack = true;
        Nav = GetComponent<NavMeshAgent>();
        EnemyActivated = false;
        EnemyCanLoseHealth = true;
        AS = GetComponent<AudioSource>();
        AudioClip[] EnemySounds = new AudioClip[10];
        CurrentSound = 0;
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.transform.position) <= EnemyChaseMax)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(EnemyVision.transform.position, EnemyVision.transform.forward, out hitinfo))
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
                    Enemy_anim.SetBool("IsAttackingpt2", true);

                    Invoke("StopAttack", 2f);
                }
                if (InstantAttack == false)
                {
                    if (Time.time > nextActionTime)
                    {
                        nextActionTime += period;
                        Enemy_anim.SetBool("IsAttacking", true);
                        Enemy_anim.SetBool("IsAttackingpt2", true);
                        Invoke("StopAttack", 2f);

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

        AS.clip = EnemySounds[CurrentSound];

        if (AudioPlaying == true)
        {
            AudioClipLength = EnemySounds[CurrentSound].length;
            AS.Play();

            if (AS.isPlaying == true)
            {
                AudioPlaying = false;
            }

        }

        else if (AudioPlaying == false)
        {
            if (AudioClipLength > 0)
            {
                AudioClipLength -= Time.deltaTime;
            }

            else if (AudioClipLength <= 0)
            {
                CurrentSound = 0;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            if (GM.Attacking == true || GM.Attack1 == true || GM.Attack2 == true || GM.Attack3 == true)
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
                if (GameObject.Find("HumanForm").GetComponent<HumanMovement>().CanParry == true)
                {
                    //CurrentMovementSound = 3;
                    Enemy_anim.SetBool("ClashedSword", true);
                    Invoke("StopStaggering", 0.5f);
                    Nav.enabled = false;
                }
                if (GameObject.Find("HumanForm").GetComponent<HumanMovement>().CanParry == false)
                {
                    Enemy_anim.SetBool("IsAttacking", false);
                    Enemy_anim.SetBool("IsAttackingpt2", false);
                }

            }
        }

    }

    void StopAttack()
    {
        Enemy_anim.SetBool("IsAttacking", false);
        Enemy_anim.SetBool("IsAttackingpt2", false);

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
