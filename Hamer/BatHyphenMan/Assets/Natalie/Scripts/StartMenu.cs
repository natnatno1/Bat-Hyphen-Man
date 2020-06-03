using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Image StartButton;
    public Image QuitButton;
    public Image Arrow;
    public bool OnStartButton;
    public AudioSource AS;
    public AudioClip ButtonScrollSound;
    public AudioClip ButtonSelectSound;

    // Start is called before the first frame update
    void Start()
    {
        StartButton = transform.Find("Background").transform.Find("StartButtonImage").GetComponent<Image>();
        QuitButton = transform.Find("Background").transform.Find("QuitButtonImage").GetComponent<Image>();
        Arrow = transform.Find("Background").transform.Find("ArrowImage").GetComponent<Image>();
        OnStartButton = true;
        AS = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnStartButton == true)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Arrow.rectTransform.anchoredPosition = new Vector3(-450, -255, 0);
                OnStartButton = false;
                AS.clip = ButtonScrollSound;
                AS.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                AS.clip = ButtonSelectSound;
                AS.Play();
                SceneManager.LoadScene(1);
;           }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Arrow.rectTransform.anchoredPosition = new Vector3(-460, -155, 0);
                OnStartButton = true;
                AS.clip = ButtonScrollSound;
                AS.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                AS.clip = ButtonSelectSound;
                AS.Play();
                Application.Quit();
            }
        }
    }
}
