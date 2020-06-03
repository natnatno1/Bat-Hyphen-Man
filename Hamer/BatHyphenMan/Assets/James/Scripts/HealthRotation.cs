using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, 60f * Time.deltaTime);
    }
}
