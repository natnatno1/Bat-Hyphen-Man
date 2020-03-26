using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float speed = 2.0f;
    public float rotationsPerMinute = 10;
    public Game_Manager GM;
    private bool CanPlayerLoseHealth;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        rb = GameObject.Find("HumanForm").GetComponent<Rigidbody>();
        anim = GameObject.Find("HumanForm").GetComponent<Animator>();
        CanPlayerLoseHealth = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walkForward", true);
        }
        else
        {
            anim.SetBool("walkForward", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walkBackward", true);
        }
        else
        {
            anim.SetBool("walkBackward", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("runForward", true);
        }
        else
        {
            anim.SetBool("runForward", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("turnLeft", true);
        }
        else
        {
            anim.SetBool("turnLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("turnRight", true);
        }
        else
        {
            anim.SetBool("turnRight", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("attacking?", true);
        }
        else
        {
            anim.SetBool("attacking?", false);
        }


        if (anim.GetBool("runForward") == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 6 * rotationsPerMinute * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -6 * rotationsPerMinute * Time.deltaTime, 0);
            }
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            if (GM.EnemyAttacking == true)
            {
                if (CanPlayerLoseHealth == true)
                {
                    GM.Health -= 1;
                    CanPlayerLoseHealth = false;
                    Invoke("PlayerDamageReset", 0.8f);
                }
            }
        }

        if (other.gameObject.tag == "Item/Health")
        {
            GM.Health += 25;
        }
    }

    void PlayerDamageReset()
    {
        CanPlayerLoseHealth = true;
    }

}
