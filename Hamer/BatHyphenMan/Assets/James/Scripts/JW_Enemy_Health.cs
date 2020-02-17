﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Health : MonoBehaviour
{
    public int Enemy_Health_Points;
    public Animator Enemy_anim;
    public Animator Player_anim;

    // Start is called before the first frame update
    void Start()
    {
        Enemy_Health_Points = 0;
        Enemy_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_Health_Points >= 3)
        {
            Enemy_anim.SetBool("IsDead", true);
            Invoke("DestroyEnemy", 2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            if (!Player_anim.GetCurrentAnimatorStateInfo(0).IsName("attacking?"))
            {
                Enemy_Health_Points += 1;
            }
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
