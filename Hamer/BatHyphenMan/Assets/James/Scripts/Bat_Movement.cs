using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Movement : MonoBehaviour
{
    public float Speed_forward_back;
    public float Speed_up_down;
    public float Speed_rotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * Speed_forward_back;
        }
        if (Input.GetKey("s"))
        {
            transform.position -= transform.forward * Time.deltaTime * Speed_forward_back;
        }

        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, Speed_rotate);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.down, Speed_rotate);
        }

        if (Input.GetKey("up"))
        {
            transform.position += transform.up * Time.deltaTime * Speed_up_down;
        }
        if (Input.GetKey("down"))
        {
            transform.position -= transform.up * Time.deltaTime * Speed_up_down;
        }
    }
}
