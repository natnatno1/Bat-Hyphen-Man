using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIntoBat : MonoBehaviour
{
    public Game_Manager GM;
    public GameObject VampireBat;
    public GameObject VampireHuman;
    public Camera MainCamera;
    public GameObject YDist;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        VampireBat = GameObject.Find("Vampire/BatForm");
        VampireHuman = GameObject.Find("Vampire/HumanForm");
        MainCamera = Camera.main;
        YDist = GameObject.Find("Vampire/BatForm/Y-Collider").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.IsBat == false)
        {
            MainCamera.transform.parent = VampireHuman.transform;
            VampireHuman.SetActive(true);
            VampireBat.SetActive(false);
            VampireBat.transform.position = VampireHuman.transform.position;
            VampireBat.transform.rotation = VampireHuman.transform.rotation;

    
        }
        
        else if (GM.IsBat == true)
        {
            MainCamera.transform.parent = VampireBat.transform;
            VampireBat.SetActive(true);
           
            VampireHuman.SetActive(false);

            if (GM.TooLow == false)
            {
                VampireHuman.transform.position = VampireBat.transform.position;
                VampireHuman.transform.rotation = VampireBat.transform.rotation;
            }

            else if (GM.TooLow == true)
            {
                VampireHuman.transform.position = new Vector3(VampireBat.transform.position.x, (VampireBat.transform.position.y + 1.25f), VampireBat.transform.position.z);
                VampireHuman.transform.rotation = VampireBat.transform.rotation;
            }
        }

    }
}
