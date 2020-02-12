using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public ChangeIntoBat CIB;
    public Game_Manager GM;
    public GameObject VampireHuman;
    public GameObject VampireBat;

    // Start is called before the first frame update
    void Start()
    {
        CIB = GameObject.Find("Vampire").GetComponent<ChangeIntoBat>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.IsBat == true)
        {
            VampireBat = GameObject.Find("Vampire/BatForm");
            transform.parent = VampireBat.transform;
        }

        else if (GM.IsBat == false)
        {
            VampireHuman = GameObject.Find("Vampire/HumanForm");
            transform.parent = VampireHuman.transform;
        }

    }
}
