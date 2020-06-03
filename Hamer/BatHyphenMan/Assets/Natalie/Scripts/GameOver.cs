using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image RetryButton;
    public Image QuitButton;
    public Image Arrow;
    public bool IsOnRetry;
    public AudioSource AS;
    public AudioClip ButtonScrollSound;
    public AudioClip ButtonSelectSound;

    // Start is called before the first frame update
    void Start()
    {
        RetryButton = transform.Find("Background").transform.Find("RetryButtonImage").GetComponent<Image>();
        QuitButton = transform.Find("Background").transform.Find("QuitButtonImage").GetComponent<Image>();
        Arrow = transform.Find("Background").transform.Find("ArrowImage").GetComponent<Image>();
        IsOnRetry = true;
        AS = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnRetry == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Arrow.rectTransform.anchoredPosition = new Vector3(960, -95, 0);
                IsOnRetry = false;
                AS.clip = ButtonScrollSound;
                AS.Play();
            }

            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                AS.clip = ButtonSelectSound;
                AS.Play();
                SceneManager.LoadScene(1);
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Arrow.rectTransform.anchoredPosition = new Vector3(960, 0, 0);
                IsOnRetry = true;
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
