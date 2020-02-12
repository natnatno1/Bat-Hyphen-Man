using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIntoBat : MonoBehaviour
{
    public Game_Manager GM;
    public GameObject VampireBat;
    public GameObject VampireHuman;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        VampireBat = GameObject.Find("Vampire/BatForm");
        VampireHuman = GameObject.Find("Vampire/HumanForm");
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.IsBat == false)
        {
            MainCamera.transform.parent = VampireHuman.transform;
            VampireHuman.SetActive(true);
            VampireBat.transform.position = VampireHuman.transform.position;
            VampireBat.transform.rotation = VampireHuman.transform.rotation;
            VampireBat.SetActive(false);
        }
        
        else if (GM.IsBat == true)
        {
            MainCamera.transform.parent = VampireBat.transform;
            VampireBat.SetActive(true);
            VampireHuman.transform.position = VampireBat.transform.position;
            VampireHuman.transform.rotation = VampireBat.transform.rotation;
            VampireHuman.SetActive(false);
        }

    }
}
