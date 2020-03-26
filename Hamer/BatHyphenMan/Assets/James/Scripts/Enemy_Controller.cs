using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Transform Player;
    public float Enemy_chase_distance = 1.5f;
    public float Enemy_chase_distance2 = 4f;
    public Game_Manager GM;
    public Animator Enemy_anim;
    public Animator Player_anim;

    private float nextActionTime = 0.0f;
    public float period;
    public bool Move_Restriction;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
        period = Random.Range(1f, 5f);
        Move_Restriction = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player); //Look at the player

        if (Vector3.Distance(transform.position, Player.transform.position) > Enemy_chase_distance2)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > Enemy_chase_distance)
            {
                Enemy_anim.SetBool("IsAttacking", false);
                Enemy_anim.SetBool("IsWalking", true);
                transform.position += transform.forward * Time.deltaTime * 1.5f;
            }
        }
        if (Vector3.Distance(transform.position, Player.transform.position) <= Enemy_chase_distance2)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) > Enemy_chase_distance)
            {
                if (Move_Restriction == true)
                {
                    Enemy_anim.SetBool("IsAttacking", false);
                    Enemy_anim.SetBool("IsWalking", false);
                    transform.position += transform.forward * Time.deltaTime * 0f;

                    Invoke("Enemy_Attack", 5f);
                }             
            }
        }
    }

    void Enemy_Attack()
    {
        Move_Restriction = false;
        if (Vector3.Distance(transform.position, Player.transform.position) > Enemy_chase_distance)
        {
            Enemy_anim.SetBool("IsWalking", true);
            transform.position += transform.forward * Time.deltaTime * 1.5f;
        }
        if (Vector3.Distance(transform.position, Player.transform.position) <= Enemy_chase_distance)
        {
            Enemy_anim.SetBool("IsAttacking", true);
            Invoke("StopAttack", 0.2f);
            Enemy_anim.SetBool("IsWalking", false);
            transform.position += transform.forward * Time.deltaTime * 0f;
        }
    }

    void StopAttack()
    {
        Enemy_anim.SetBool("IsAttacking", false);
    }
}
