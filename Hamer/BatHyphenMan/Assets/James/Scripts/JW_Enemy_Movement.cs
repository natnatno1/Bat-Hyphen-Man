using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Movement : MonoBehaviour
{
    public Transform Player;
    public float Enemy_chase_distance = 1.5f;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player); //Look at the player

        if (Vector3.Distance(transform.position, Player.transform.position) >= Enemy_chase_distance) //If player distance from GO this script is attached to is less then the max chase distance...
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", true);
            transform.position += transform.forward * Time.deltaTime * 2;
        }
        if (Vector3.Distance(transform.position, Player.transform.position) < Enemy_chase_distance)
        {
            anim.SetBool("IsWalking", false);
            transform.position += transform.forward * Time.deltaTime * 0;
            anim.SetBool("IsAttacking", true);
        }
    }
}
