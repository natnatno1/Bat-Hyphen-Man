using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float playerSpeed;
    public float sprintSpeed = 4f;
    public float walkSpeed = 2f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 3f;
    private bool isMoving = false;
    private bool isSprinting = false;
    private float yRot;

    public bool Pushing;

    public float AttackCooldown;

    public Animator Anim;

    public Game_Manager GM;

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<Game_Manager>();
        playerSpeed = walkSpeed;
        rigidBody = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GM.IsBat == false)
        {
            yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);

            isMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
                rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * playerSpeed;
                isMoving = true;
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
                rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * playerSpeed;
                isMoving = true;
            }

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    transform.Translate(Vector3.up * jumpHeight);
            //}

            // if (Input.GetAxisRaw("Sprint") > 0f)
            //{
            //     playerSpeed = sprintSpeed;
            //     isSprinting = true;
            // }
            // else if (Input.GetAxisRaw("Sprint") < 1f)
            // {
            //     playerSpeed = walkSpeed;
            //     isSprinting = false;
            // }

            if (GM.Health < 0)
            {
                GM.Health = 0;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Anim.GetBool("Attack?") == false)
                {
                    Anim.SetBool("Attack?", true);

                    AttackCooldown = 0.5f;
                }
            }

            if (Anim.GetBool("Attack?") == true)
            {
                AttackCooldown -= Time.deltaTime;

                if (AttackCooldown < 0)
                {
                    Anim.SetBool("Attack?", false);
                }
            }
        }

        else if (GM.IsBat == true)
        {
            gameObject.transform.rotation = GM.PlayerRot.rotation;

            yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);

            isMoving = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
                rigidBody.velocity += transform.right * Input.GetAxisRaw("Horizontal") * (playerSpeed / 3);
                isMoving = true;
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
                rigidBody.velocity += transform.forward * Input.GetAxisRaw("Vertical") * (playerSpeed / 3);
                isMoving = true;
            }

            if (GM.Health < 0)
            {
                GM.Health = 0;
            }

            if (Input.GetMouseButtonDown(0))
            {
                rigidBody.velocity += transform.up * (playerSpeed);
                isMoving = true;
            }

            else if (Input.GetMouseButtonDown(1))
            {
                rigidBody.velocity -= transform.up * (playerSpeed);
                isMoving = true;
            }

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon")
        {
            GM.Health -= 1;
        }

        if (other.gameObject.tag == "Item/Health")
        {
            GM.Health += 25;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pushable")
        {
            Pushing = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Pushable")
        {
            Pushing = false;
        }
    }

}
