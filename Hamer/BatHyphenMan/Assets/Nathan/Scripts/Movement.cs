using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
    }
}
