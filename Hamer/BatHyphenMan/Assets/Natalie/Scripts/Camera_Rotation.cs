using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    //Here I declare the speed of rotation
    public float RotSpeed = 6f;
    //rotation on y
    float rotY;
    //Clamping Angle
    public float ClampAngle = 10f;
    

    // Update is called once per frame
    void Update()
    {
        rotY += Input.GetAxis("Mouse Y") * RotSpeed;
        rotY = Mathf.Clamp(rotY, -ClampAngle, ClampAngle);
        transform.localRotation = Quaternion.Euler(-rotY, 0f, 0f);

    }

}
