using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        AudioSource crashSource = GetComponents<AudioSource>()[1];
        if (collision.rigidbody && !crashSource.isPlaying) {
            crashSource.Play();
        }
        
    }
}
