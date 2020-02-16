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

    public bool Attacking;

    public bool IsBat;

    public GameObject Player;

    public Transform PlayerRot;

    //public static Game_Manager instance;

   // private void Awake()
    //{
     //   DontDestroyOnLoad(this.gameObject);

     //   if (instance == null)
      //  {
      //      instance = this;
      ///  }
      //  else
      //  {
      //      Destroy(this.gameObject);
          //  return;
       // }
   // }

    // Start is called before the first frame update
    void Start()
    {
        StatusReport = GameObject.Find("Status_Report").GetComponent<Text>();
        StatusReport.text = "";
        HealthStatus = GameObject.Find("Health").GetComponent<Text>();
        Daytime = false;
        IsBat = false;

        Player = GameObject.Find("Vampire");

        PlayerRot = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByBuildIndex(1) == SceneManager.GetActiveScene())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (IsBat == true)
            {
                IsBat = false;
            }

            else if (IsBat == false)
            {
                IsBat = true;
            }
        }

        PlayerRot = Player.transform;

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
