using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float WaterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().velocity = WaterSpeed * transform.TransformDirection(Vector3.forward);

        transform.position += transform.forward * 10f * Time.deltaTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
