using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JW_Enemy_Movement : MonoBehaviour
{
    public Transform Player;
    public float Enemy_chase_distance = 2;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player); //Look at the player

        if (Vector3.Distance(transform.position, Player.transform.position) > Enemy_chase_distance) //If player distance from GO this script is attached to is less then the max chase distance...
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", true);
            transform.position += transform.forward * Time.deltaTime * 1;
        }
        else
        {
            anim.SetBool("IsWalking", false);
            transform.position += transform.forward * Time.deltaTime * 0;
            anim.SetBool("IsAttacking", true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HumanForm")
        {
            anim.SetBool("IsAttacking", false);
            Invoke("Delay", 0.5f);
        }
    }

    void Delay()
    {
        anim.SetBool("IsAttacking", true);
    }
}
