using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollision : MonoBehaviour
{
    public LightHit LH;
    public GameObject LightOrigin;

    private void Start()
    {
        LH = LightOrigin.GetComponent<LightHit>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LH.CheckforPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LH.CheckforPlayer = false;
        }
    }

}
