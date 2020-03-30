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

    //private void OnTriggerEnter(Collider other)
    //{
    //   if (other.gameObject.tag == "PlayerWeapon" || other.gameObject.tag == "Player")
    //    {
    //        if (GM.EnemyAttacking == true && GM.Blocking == false)
    //        {
    //            Enemy_anim.SetBool("IsAttacking", false);
    //            Enemy_anim.SetBool("IsAttackDone", true);
    //            Invoke("FinishAttack", 2f);
    //
    //        }
    //    }
    //}
}
