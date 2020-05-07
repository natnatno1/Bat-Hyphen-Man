using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMovement : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public float RunSpeed = 1;
    public float gravity = -5;
    float CurrentSpeedUp = 0;
    float CurrentSpeedDown = 0;
    float CurrentSpeedX = 0;
    float velocityY = 0;

    public bool Pushing;
    public bool CanPush;

    Rigidbody rb;
    Animator anim;
    public float speed = 2.0f;
    public float rotationsPerMinute = 10;
    public Game_Manager GM;

    public CharacterController controller;
    public bool PlayerCanLoseHealth;

    public bool CanParry = false;

    void Start()
    {
        PlayerCanLoseHealth = true;
        controller = GetComponent<CharacterController>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        rb = GameObject.Find("HumanForm").GetComponent<Rigidbody>();
        anim = GameObject.Find("HumanForm").GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;

        Vector3 temp = Vector3.zero;

        if (input.z == 1)
        {
            anim.SetBool("walkForward", true);
        }

        else
        {
            anim.SetBool("walkForward", false);
        }

        if (input.z == -1)
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("runBackward", true);
        }
        else
        {
            anim.SetBool("runBackward", false);
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
        
        
       // Vector3 velocity = temp * RunSpeed;
       // velocity.y = velocityY;

      //  controller.Move(velocity * Time.deltaTime);

        //NOT REALISTIC ROTATIONS

        //You may have to move the '-' sign to the other one (- means opposite) E.G. - Negative so I THINK -Vector.up is left. Could be wrong though.

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);

        if (h < 0)
        {
            anim.SetBool("TurningLeft", true);
        }

        else
        {
            anim.SetBool("TurningLeft", false);
        }

        if (h > 0)
        {
            anim.SetBool("TurningRight", true);
        }

        else
        {
            anim.SetBool("TurningRight", false);
        }

        if (Input.GetMouseButton(1))
        {
            anim.SetBool("Blocking", true);
        }
        else
        {
            anim.SetBool("Blocking", false);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Blocking", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            CanParry = true;
            Invoke("Parrytimer", 2f);
        }
        if (Input.GetMouseButtonUp(1))
        {
            CanParry = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            if (GM.EnemyAttacking == true)
            {
                if (GM.Blocking == true)
                {
                    GM.Health -= 0;

                }

                if (GM.Blocking == false)
                {
                    if (PlayerCanLoseHealth == true)
                    {
                        GM.Health -= 1;
                        PlayerCanLoseHealth = false;
                        anim.SetBool("Hit", true);

                        Invoke("PlayerDamageReset", 1.5f);
                    }
                }
            }
        }

        if (other.gameObject.tag == "Item/Health")
        {
            if (GM.Health >= 5)
            {
                GM.Health = 10;
            }

            else if (GM.Health < 5)
            {
                GM.Health += 5;
            }
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
    }

     private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Pushable")
       {
          Pushing = true;
      }
      }

     private void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.tag == "Pushable")
        {
           Pushing = false;
        }
     }

    void PlayerDamageReset()
    {
        PlayerCanLoseHealth = true;
        anim.SetBool("Hit", false);
    }

    void Parrytimer()
    {
        CanParry = false;
    }
}
