using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunlight : MonoBehaviour
{
    public GameObject Player;
    public Transform playerTrans;
    public Game_Manager GM;

    public RaycastHit hit;
    public Ray PlayerPos;

    public Transform target;

    public GameObject Centre;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        playerTrans = Player.transform;
    }

    void Update()
    {
        PlayerPos = new Ray(transform.position, transform.forward);
        Debug.DrawRay(PlayerPos.origin, PlayerPos.direction * 1000, Color.red);
        
        transform.LookAt(playerTrans);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1000))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
              //  if (GM.Daytime == true)
             //   {
               //     Debug.LogFormat("PLAYAAA");
              //  }
            }

        }
    }
}
