using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_into_bat2 : MonoBehaviour
{
    public GameObject Vampire;
    public GameObject Bat;

    public bool Vampire_Is_Active;
    public bool Bat_Is_Active;

    // Start is called before the first frame update
    void Start()
    {
        Bat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vampire.activeSelf)
        {
            Vampire_Is_Active = true;
        }

        if (!Vampire.activeSelf)
        {
            Vampire_Is_Active = false;
        }

        if (Bat.activeSelf)
        {
            Bat_Is_Active = true;
        }

        if (!Bat.activeSelf)
        {
            Bat_Is_Active = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Vampire_Is_Active == true)
            {
                Bat.SetActive(true);

                Bat.transform.position = Vampire.transform.position;
                Bat.transform.rotation = Vampire.transform.rotation;

                Vampire.SetActive(false);
            }

            if (Bat_Is_Active == true)
            {
                Vampire.SetActive(true);

                Vampire.transform.position = Bat.transform.position;
                Vampire.transform.rotation = Bat.transform.rotation;

                Bat.SetActive(false);
            }
        }
    }
}
