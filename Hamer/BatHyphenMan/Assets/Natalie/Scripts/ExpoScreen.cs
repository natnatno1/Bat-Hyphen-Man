using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpoScreen : MonoBehaviour
{
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AS.isPlaying)
        {
            SceneManager.LoadScene(1);
        }
    }
}
