using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHit : MonoBehaviour
{
    public GameObject Player;
    public GameObject RayOrigin;
    private Ray sight;
    public bool CheckforPlayer;
    public GameObject HumanForm;
    public GameObject BatForm;
    public Game_Manager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    private void Update()
    {
        if (GM.IsBat == true)
        {
            Player = BatForm;
        }

        else if (GM.IsBat == false)
        {
            Player = HumanForm;
        }
    }

    void FixedUpdate()
    {
        if (CheckforPlayer == true)
        {
            sight.origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            sight.direction = transform.forward;
            RaycastHit rayHit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            Quaternion rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);


            if (Physics.Raycast(sight, out rayHit, 5000))
            {
                Debug.DrawLine(sight.origin, rayHit.point, Color.red, 5000);
                if (rayHit.collider.tag == "Player")
                {
                    GM.Health -= 100;
                }

               // if (rayHit.collider.tag != "Player")
               // {
                   // Debug.LogFormat("Not");
               // }
            }
        }
        
    }
}
