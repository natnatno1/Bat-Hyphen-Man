using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRot : MonoBehaviour
{
    public GameObject vamp;
    float speed = 75;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        vamp.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
    }
}
