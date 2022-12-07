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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag != "ParticleIgnore")
        {
            particles.Emit(20);
        }
    }
}
