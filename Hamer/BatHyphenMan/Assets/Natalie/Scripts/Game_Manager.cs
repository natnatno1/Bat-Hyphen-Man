using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public Text StatusReport;
    public Text HealthStatus;
    public int Health;
    public List<string> Inventory = new List<string>();
    public float StatusReportTimer;
    public bool Daytime;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StatusReport = GameObject.Find("Status_Report").GetComponent<Text>();
        StatusReport.text = "";
        HealthStatus = GameObject.Find("Health").GetComponent<Text>();
        Daytime = false;
    }

    // Update is called once per frame
    void Update()
    {
        StatusReportTimer -= Time.deltaTime;

        if (StatusReportTimer < 0)
        {
            StatusReport.text = "";
        }

        HealthStatus.text = ("Health: " + Health);

        if (Health <= 0)
        {
            SceneManager.LoadScene(1);
            Health = 10;
        }
    }
    
}
