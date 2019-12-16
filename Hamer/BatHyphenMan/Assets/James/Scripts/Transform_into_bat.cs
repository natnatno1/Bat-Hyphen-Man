using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_into_bat : MonoBehaviour
{
    public GameObject Vampire;
    public GameObject Bat;

    bool Vampire_here;
    bool Bat_here;

    bool cooldown_done;

    public int change_bat;
    public int the_cooldown;

    public Game_Manager GM;
    

    // Start is called before the first frame update
    void Start()
    {

        //Vampire = GameObject.FindGameObjectWithTag("Vampire");
        //Bat = GameObject.FindGameObjectWithTag("Bat");

        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();

        Bat.SetActive(false);

        cooldown_done = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(Vampire.activeSelf)
        {
            Vampire_here = true;
            GM.IsBat = true;
        }

        if (!Vampire.activeSelf)
        {
            Vampire_here = false;
            GM.IsBat = false;
        }
        
        if (Bat.activeSelf)
        {
            Bat_here = true;
            GM.IsBat = true;
        }

        if (!Bat.activeSelf)
        {
            Bat_here = false;
            GM.IsBat = false;
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Vampire_here == true)
            {
                if (cooldown_done == true)
                {
                    Bat.SetActive(true);

                    Bat.transform.position = Vampire.transform.position;

                    Vampire.SetActive(false);
                }
            }

            if (Bat_here == true)
            {
                Vampire.SetActive(true);

                Vampire.transform.position = Bat.transform.position;

                Bat.SetActive(false);

                cooldown_done = false;

                Invoke("End_Cooldown", the_cooldown);
            }
        }

        if (Bat_here == true)
        {
            Invoke("Change_back_to_Vampire", change_bat);
        }
    }

    void Change_back_to_Vampire()
    {
        if (Bat_here == true)
        {
            Vampire.SetActive(true);

            Vampire.transform.position = Bat.transform.position;

            Bat.SetActive(false);

            cooldown_done = false;

            Invoke("End_Cooldown", the_cooldown);
        }
    }

    void End_Cooldown()
    {
        cooldown_done = true;
    }
}
