using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    Rigidbody rb; // reference of Rigidbody
    AudioSource audioSource; // reference of AudioSource

    [SerializeField] float Thrust = 100f;
    [SerializeField] float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0, 1 * Thrust * Time.deltaTime, 0); //same as (Vector3.up)
            
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }


    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate, not letting physics change it for example when bumping into obstacle.
        transform.Rotate(0, 0, 1 *  rotationThisFrame * Time.deltaTime); // same as (Vector3.forward)
        rb.freezeRotation = false;
    }

    
}
