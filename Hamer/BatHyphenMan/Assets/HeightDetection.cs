using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightDetection : MonoBehaviour
{
    public Game_Manager GM;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            GM.TooLow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Floor")
        {
            GM.TooLow = false;
        }
    }
}
