using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    public float RunSpeed = 1;
    public float gravity = -5;
    float CurrentSpeedUp = 0;
    float CurrentSpeedDown = 0;
    float CurrentSpeedX = 0;
    float velocityY = 0;

    public CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;

        Vector3 temp = Vector3.zero;
        if (input.z == 1)
        {
            temp += transform.forward;
            CurrentSpeedUp = 1;
            CurrentSpeedDown = 0;
        }
        else if (input.z == -1)
        {
            temp += transform.forward * -1;
            CurrentSpeedDown = 1;
            CurrentSpeedUp = 0;
        }

        else
        {
            CurrentSpeedUp = 0;
            CurrentSpeedDown = 0;
        }

        if (input.x == 1)
        {
            temp += transform.right;
            CurrentSpeedX = 1;
        }
        else if (input.x == -1)
        {
            temp += transform.right * -1;
            CurrentSpeedX = 1;
        }

        else
        {
            CurrentSpeedX = 0;
        }


        if (Input.GetMouseButton(0))
        {
            velocityY ++;
        }

        else if (Input.GetMouseButton(1))
        {
            velocityY --;
        }

        else
        {
            velocityY = 0;
        }
        
        

        Vector3 velocity = temp * RunSpeed;
        velocity.y = velocityY;

        controller.Move(velocity * Time.deltaTime);

        //NOT REALISTIC ROTATIONS

        //You may have to move the '-' sign to the other one (- means opposite) E.G. - Negative so I THINK -Vector.up is left. Could be wrong though.

        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, h, 0);
    }
}

