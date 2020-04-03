using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    public Game_Manager GM;
    public GameObject CheckpointMesh;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        CheckpointMesh = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GM.RespawnPoint == null)
            {
                Destroy(gameObject.GetComponent<SphereCollider>());
                GM.RespawnHealth = GM.Health;
                GM.RespawnPoint = gameObject;
                Destroy(CheckpointMesh.gameObject);
            }

            else if (GM.RespawnPoint != null)
            {
                Destroy(gameObject.GetComponent<SphereCollider>());
                Destroy(GM.RespawnPoint.gameObject);
                GM.RespawnHealth = GM.Health;
                GM.RespawnPoint = gameObject;
                Destroy(CheckpointMesh.gameObject);
            }
            
        }
    }

}
