using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
      if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("DoorOpen", true);
                anim.SetBool("DoorClosed", true);
            }
            else
            {
                anim.SetBool("DoorOpen", false);
                anim.SetBool("DoorClosed", false);
            }
        }
    }
}
