﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Enemy_Controller : MonoBehaviour
{
    private Transform Player;
    private Game_Manager GM;
    public Animator Enemy_anim;

    private bool EnemyCanLoseHealth;
    public float HealthBarDropSize;
    public float Enemy_Health_Points;
    public Transform EnemyHealthBar;
    public GameObject RedBar2;

    public GameObject EnemyVision;
    public GameObject myPrefab;
    private bool CanEnemyFire;

    private float NextShotTime;
    public float CoolDown;
    public bool test;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        Enemy_anim = GetComponent<Animator>();
        EnemyCanLoseHealth = true;
        CanEnemyFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(Player.transform.position.x,
                                               transform.position.y,
                                               Player.transform.position.z);
        transform.LookAt(targetPosition);

        if (Enemy_Health_Points < 1)
        {
            Enemy_anim.SetBool("IsDead", true);
            Destroy(RedBar2);
            Invoke("DestroyEnemy", 2.5f);
        }

        if (Time.time > NextShotTime)
        {
            RaycastHit hitinfo;
            if (Physics.Raycast(EnemyVision.transform.position, EnemyVision.transform.forward, out hitinfo))
            {
                if (hitinfo.collider.gameObject.tag == "Player" || hitinfo.collider.gameObject.tag == "PlayerWeapon")
                {
                    FireAtTarget();
                }
            }
        }
    }

    void FireAtTarget()
    {
        GameObject Arrow_clone = Instantiate(myPrefab, transform.position + transform.TransformDirection(new Vector3(0f, 1.1f, 0.9f)), transform.rotation);

        NextShotTime = Time.time + CoolDown;
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void EnemyDamageReset()
    {
        EnemyCanLoseHealth = true;
    }

    void StopStaggering()
    {
        Enemy_anim.SetBool("IsHit", false);
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
                    Invoke("EnemyDamageReset", 1f);

                    if (Enemy_Health_Points >= 1)
                    {
                        Enemy_anim.SetBool("IsHit", true);
                        Invoke("StopStaggering", 0.3f);
                    }
                }
            }
        }
    }
}
