using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspect : MonoBehaviour
{
    public Game_Manager GM;
    public bool Interactable;
    public string ItemDescription;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Interactable == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.LogFormat("" + ItemDescription);
                GM.StatusReportTimer = 5;
                GM.StatusReport.text = ("" + ItemDescription);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Interactable = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Interactable = false;
        }
    }
}
