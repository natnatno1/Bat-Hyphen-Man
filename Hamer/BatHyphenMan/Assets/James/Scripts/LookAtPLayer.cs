using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPLayer : MonoBehaviour
{
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("HumanForm").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
    }
}
