using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartCollision : MonoBehaviour
{
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if ((collision.collider.gameObject.name != "ParkingLot01") || collision.collider.gameObject.name != "ParkingLot01 (1)" || collision.collider.gameObject.name != "Player" ||
            collision.collider.gameObject.name != "default") 
        {
            Debug.Log("hello");
            particles.Play();
        }
    }
}
