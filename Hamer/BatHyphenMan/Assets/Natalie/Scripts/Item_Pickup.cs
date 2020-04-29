using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    public string ItemName;
    public Game_Manager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            //GM.Inventory[GM.Inventory.Length + 1] = ItemName;
            GM.Inventory.Add("" + ItemName);
            GM.StatusReportTimer = 5;
            GM.StatusReport.text = ("You picked up " + ItemName + "...");
        }
    }
}
