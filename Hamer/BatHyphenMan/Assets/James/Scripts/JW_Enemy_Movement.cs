using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Movement : MonoBehaviour
{
    public Transform Player;
    public float Enemy_chase_distance = 1.5f;
    public Game_Manager GM;
    public Animator Enemy_anim;
    public Animator Player_anim;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        Enemy_anim = GetComponent<Animator>();
        Player_anim = GameObject.Find("Vampire").GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player); //Look at the player

        if (Vector3.Distance(transform.position, Player.transform.position) >= Enemy_chase_distance) //If player distance from GO this script is attached to is less then the max chase distance...
        {
            Enemy_anim.SetBool("IsAttacking", false);
            Enemy_anim.SetBool("IsWalking", true);
            transform.position += transform.forward * Time.deltaTime * 2;
        }
        if (Vector3.Distance(transform.position, Player.transform.position) < Enemy_chase_distance)
        {
            Enemy_anim.SetBool("IsWalking", false);
            transform.position += transform.forward * Time.deltaTime * 0;
            Enemy_anim.SetBool("IsAttacking", true);
        }
    }
}
