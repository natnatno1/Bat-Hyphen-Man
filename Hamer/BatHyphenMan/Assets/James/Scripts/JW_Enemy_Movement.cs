﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Movement : MonoBehaviour
{
    public Transform Player;
    public float Enemy_chase_distance = 1.5f;
    public Game_Manager GM;
    public Animator Enemy_anim;
    public Animator Player_anim;

    private float nextActionTime = 0.0f;
    public int period;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
        period = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player); //Look at the player

        if (Vector3.Distance(transform.position, Player.transform.position) >= Enemy_chase_distance) //If player distance from GO this script is attached to is less then the max chase distance...
        {
            Enemy_anim.SetBool("IsAttacking", false);
            Enemy_anim.SetBool("IsWalking", true);
            transform.position += transform.forward * Time.deltaTime * 1.5f;
        }
        if (Vector3.Distance(transform.position, Player.transform.position) < Enemy_chase_distance)
        {
            Enemy_anim.SetBool("IsWalking", false);
            transform.position += transform.forward * Time.deltaTime * 0f;

            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                Enemy_anim.SetBool("IsAttacking", true);
                Invoke("StopAttack", 0.2f);

            }
        }

        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, transform.right, out hitinfo, 3f))
        {
            if (hitinfo.collider.tag == "Enemy")
            {
                transform.position -= transform.right * Time.deltaTime * 2f;
            }
            else
            {
                transform.position -= transform.right * Time.deltaTime * 0f;
            }
        }
        if (Physics.Raycast(transform.position, -transform.right, out hitinfo, 3f))
        {
            if (hitinfo.collider.tag == "Enemy")
            {
                transform.position += transform.right * Time.deltaTime * 2f;
            }
            else
            {
                transform.position += transform.right * Time.deltaTime * 0f;
            }
        }
    }

    void StopAttack()
    {
        Enemy_anim.SetBool("IsAttacking", false);
    }
}
