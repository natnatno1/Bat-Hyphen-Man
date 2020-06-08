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
    public AudioAndSoundEffects ASEScript;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponentInParent<Animator>();
        GM = GameObject.Find("GameManager").GetComponent < Game_Manager>();
        ASEScript = Camera.main.transform.Find("SoundEffectsController").GetComponent<AudioAndSoundEffects>();
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

                        if (KeyNeeded == "Rusty Key")
                        {
                            Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 3;
                            ASEScript.PlayingSound = true;
                        }

                        else if (KeyNeeded == "Silver Key")
                        {
                            Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 7;
                            ASEScript.PlayingSound = true;
                        }
                    }


                    if (Anim.GetBool("Open?") == false)
                    {
                        Anim.SetBool("Open?", true);

                        if (KeyNeeded == "Rusty Key")
                        {
                            Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 4;
                            ASEScript.PlayingSound = true;

                        }

                        else if (KeyNeeded == "Silver Key")
                        {
                            Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 8;
                            ASEScript.PlayingSound = true;
                        }
                    }
                    
                    else if (Anim.GetBool("Open?") == true)
                    {
                        Anim.SetBool("Open?", false);

                        if (KeyNeeded == "Rusty Key")
                        {
                            Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 5;
                            ASEScript.PlayingSound = true;
                        }

                        else if (KeyNeeded == "Silver Key")
                        {
                            Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 9;
                            ASEScript.PlayingSound = true;
                        }

                    }

                    if (DoorDetails == "FinalDoor")
                    {
                        SceneManager.LoadScene(3);
                    }
                }

                else
                {
                    GM.StatusReportTimer = 5;
                    GM.StatusReport.text = ("" + DoorDetails);

                    if (KeyNeeded == "Rusty Key")
                    {
                        Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 2;
                        ASEScript.PlayingSound = true;
                    }

                    else if (KeyNeeded == "Silver Key")
                    {
                        Camera.main.GetComponentInChildren<AudioAndSoundEffects>().CurrentSound = 6;
                        ASEScript.PlayingSound = true;
                    }
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
