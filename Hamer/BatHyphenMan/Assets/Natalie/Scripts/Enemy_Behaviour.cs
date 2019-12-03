using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    public GameObject Player;
    public Transform PlayerPosition;
    public float speed;
    public float step;
    public float DistanceToPlayer;
    public float DangerZone;
    public Animator Anim;
    public Vector3 OldEularAngles;
    public Game_Manager GMScript;
    public SpriteRenderer Splat;
    public int EnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newRotation = Quaternion.LookRotation(transform.position - Player.transform.position, Vector3.forward);
        newRotation.x = 0;
        newRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 8);
        step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerPosition.position, step);

        if (EnemyHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            EnemyHealth -= 1;
        }
    }

}
