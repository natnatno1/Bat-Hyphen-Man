using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public Animator Anim;
    public Game_Manager GM;
    public bool Interactable;
    public bool Unlocked;
    public string DoorDetails;
    public string KeyNeeded;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInParent<Animator>();
        GM = GameObject.Find("GameManager").GetComponent < Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Interactable == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (GM.Inventory.Contains("" + KeyNeeded))
                {
                   // SceneManager.LoadScene(2);

                    if (Unlocked == false)
                    {
                        GM.StatusReportTimer = 5;
                        GM.StatusReport.text = ("You used " + KeyNeeded);
                        Unlocked = true;
                        Anim.SetBool("Open?", true);
                    }


                    if (Anim.GetBool("Open?") == false)
                    {
                        Anim.SetBool("Open?", true);
                    }
                    
                    else if (Anim.GetBool("Open?") == true)
                    {
                        Anim.SetBool("Open?", false);
                    }

                    if (DoorDetails == "FinalDoor")
                    {
                        SceneManager.LoadScene(2);
                    }
                }

                else
                {
                    GM.StatusReportTimer = 5;
                    GM.StatusReport.text = ("" + DoorDetails);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Interactable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Interactable = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Interactable = false;
        }
    }
}
