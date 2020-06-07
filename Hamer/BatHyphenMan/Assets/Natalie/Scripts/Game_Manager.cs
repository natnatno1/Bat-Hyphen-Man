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
    public bool Blocking;
    public bool EnemyAttacking;
    public bool Attack1;
    public bool Attack2;
    public bool Attack3;

    public bool IsBat;

    public GameObject Player;

    public Transform PlayerRot;

    public GameObject RespawnPoint;
    public int RespawnHealth;
    public GameObject CurrentForm;

    public bool GameOver;

    public int Lives;

    public bool TooLow;

    public Image HealthBar;

    public bool IsHurt;

    public Text LivesText;


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
        HealthBar = GameObject.Find("HealthBarFull").GetComponent<Image>();
        StatusReport = GameObject.Find("Status_Report").GetComponent<Text>();
        StatusReport.text = "";
        Daytime = false;
        IsBat = false;

        Player = GameObject.Find("Vampire");

        PlayerRot = Player.transform;

        Lives = 5;

        Inventory.Add("");

        LivesText = GameObject.Find("Lives").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        HealthBar.rectTransform.sizeDelta = new Vector2((15 * Health), 15.6f);

        CurrentForm = Camera.main.transform.parent.gameObject;

        LivesText.text = ("Lives: " + Lives);

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

        if (Health <= 0)
        {
            if (Lives <= 0)
            {
                GameOver = true;
            }

            else if (Lives > 0)
            {
                Health = 10;
                Lives = Lives - 1;
                CurrentForm.transform.position = RespawnPoint.transform.position;
            }
        }

        if (GameOver == true)
        {
            SceneManager.LoadScene(2);
            Health = 10;
        }
        
    }
    
}
