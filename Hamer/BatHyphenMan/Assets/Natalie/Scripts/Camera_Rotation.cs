using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    public float CameraMoveSpeed = 120f;
    public GameObject CameraFollowObject;
    Vector3 FollowPosition;
    public float ClampAngle = 80.0f;
    public float InputSensitivity = 150.0f;
    public GameObject CameraObject;
    public GameObject PlayerObject;
    public float CamDistanceXToPlayer;
    public float CamDistanceYToPlayer;
    public float CamDistanceZToPlayer;
    public float MouseX;
    public float MouseY;
    public float FinalInputX;
    public float FinalInputZ;
    public float SmoothX;
    public float SmoothY;
    private float RotY = 0.0f;
    private float RotX = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        Vector3 Rot = transform.localRotation.eulerAngles;
        RotY = Rot.y;
        RotX = Rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //We setup the rotation of the sticks here

        float InputX = Input.GetAxis("RightStickHorizontal");
        float InputZ = Input.GetAxis("RightStickVertical");
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");


    }
}
