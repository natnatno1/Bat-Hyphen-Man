using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer_Script : MonoBehaviour
{
    private LineRenderer LR;
    public Transform Origin;
    public Game_Manager GM;

    // Start is called before the first frame update
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        LR.SetPosition(0, Origin.position);
        RaycastHit Hit;

        if (Physics.Raycast(Origin.position, transform.forward, out Hit))
        {
            if (Hit.collider)
            {
                LR.SetPosition(1, Hit.point);
                if (Hit.collider.gameObject.tag == "Player")
                {
                    GM.Health -= 100;
                }

            }

            else
            {
                LR.SetPosition(1, transform.forward * 5000);
            }
        }

    }
}
