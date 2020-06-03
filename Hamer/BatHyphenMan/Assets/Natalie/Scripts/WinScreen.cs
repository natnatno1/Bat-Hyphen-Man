﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Image PlayAgainButton;
    public Image QuitButton;
    public Image Arrow;
    public bool IsOnPlayAgain;

    // Start is called before the first frame update
    void Start()
    {
        PlayAgainButton = transform.Find("Background").transform.Find("PlayAgainButtonImage").GetComponent<Image>();
        QuitButton = transform.Find("Background").transform.Find("QuitButtonImage").GetComponent<Image>();
        Arrow = transform.Find("Background").transform.Find("ArrowImage").GetComponent<Image>();
        IsOnPlayAgain = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnPlayAgain == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Arrow.rectTransform.anchoredPosition = new Vector3(960, 450, 0);
                IsOnPlayAgain = false;
            }

            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }
        }

        else if (IsOnPlayAgain == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Arrow.rectTransform.anchoredPosition = new Vector3(960, 540, 0);
                IsOnPlayAgain = true;
            }

            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                Application.Quit();
            }
        }
    }
}