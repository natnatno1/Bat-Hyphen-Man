using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompts : MonoBehaviour
{
    public GameObject Player;
    public bool HasCollided;
    public string TheTextPrompt = "";
    public int BoxWidth;
    public int BoxHeight;
    private bool StopGlitching;
    public float DelayTime = 0.5f;
    public Color Colour;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("HumanForm");

        HasCollided = false;
        StopGlitching = false;
    }

    void Update()
    {
        if (Player.activeSelf == false)
        {
            HasCollided = false;
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (HasCollided == true)
        {
            GUI.skin.box.fontSize = 30;
            GUI.contentColor = Colour;

            GUIStyle boxStyle = "box";
            boxStyle.wordWrap = true;

            GUI.Box(new Rect(140, 200, BoxWidth, BoxHeight), TheTextPrompt);

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            StopGlitching = true;
            HasCollided = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            StopGlitching = false;
            Invoke("StillShowPrompt", DelayTime);
        }
    }

    void StillShowPrompt()
    {
        if (StopGlitching == false)
        {
            HasCollided = false;
        }
    }
}

//GUI.Box(Rect(140,Screen.height-50,Screen.width-300,120),(labelText));

//GUI.Box(new Rect(140, 200, BoxWidth, 100), TheTextPrompt);