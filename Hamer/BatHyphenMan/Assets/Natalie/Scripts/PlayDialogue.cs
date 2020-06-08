using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialogue : MonoBehaviour
{
    public bool DialogueTriggered;
    public AudioSource AS;
    public AudioClip Line;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AS.clip = Line;

        if (!AS.isPlaying && DialogueTriggered == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && DialogueTriggered == false)
        {
            AS.Play();
            DialogueTriggered = true;
        }
    }
}
