using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicmovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a"))
        {
            this.transform.position = this.transform.position + new Vector3(-0.1f, 0, 0);
        }
        if(Input.GetKey("d"))
        {
            this.transform.position = this.transform.position + new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, 0.1f);
        }
        if (Input.GetKey("s"))
        {
            this.transform.position = this.transform.position + new Vector3(0, 0, -0.1f);
        }
    }
}
