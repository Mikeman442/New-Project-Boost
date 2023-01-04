using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotateSpeed = 100;
    [SerializeField] AudioClip mainEngineSound;

    Rigidbody rb;
    AudioSource audioSource;


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
        ProcessRotate();
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CheckAudio();
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            audioSource.Stop();
        }
        
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotateSpeed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so physics doesnt bugger things up.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so physics can resume. 
    }

    private void CheckAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSound);
        }

    }
} 