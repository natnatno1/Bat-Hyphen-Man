using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public Text StatusReport;
    public List<string> Inventory = new List<string>();
    public float StatusReportTimer;

    // Start is called before the first frame update
    void Start()
    {
        StatusReport = GetComponentInChildren<Text>();
        StatusReport.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        StatusReportTimer -= Time.deltaTime;

        if (StatusReportTimer < 0)
        {
            StatusReport.text = "";
        }
        
    }
    
}
