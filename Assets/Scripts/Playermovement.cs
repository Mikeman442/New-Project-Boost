using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotateSpeed = 100;
    [SerializeField] AudioClip mainEngineSound;
    [SerializeField] ParticleSystem mainBoing;
    [SerializeField] ParticleSystem moveLeft;
    [SerializeField] ParticleSystem moveRight;


    Rigidbody rb;
    AudioSource audioSource;
    CollisionHandler collisionHandlerRef;



    // Start is called before the first frame update

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandlerRef = GetComponent<CollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
        SkipLevelButton();
    }


    void ProcessThrust()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartThrusting();
        }
// Note: This code would be required for Input.GetKey method but is not required for Input.GetKeyDown        
/*        else
        {
            audioSource.Stop();
            mainBoing.Stop();
        }
*/
    }

    void StartThrusting()
    {
        audioSource.PlayOneShot(mainEngineSound);
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        mainBoing.Play();
    }

    void ProcessRotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    void RotateLeft()
    {
        ApplyRotation(rotateSpeed);
        moveLeft.Play();
    }

    void RotateRight()
    {
        ApplyRotation(-rotateSpeed);
        moveRight.Play();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so physics doesnt bugger things up.
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so physics can resume. 
    }

    void SkipLevelButton()
    {
        if (Input.GetKey(KeyCode.L))
        {
            collisionHandlerRef.NextLevel();
        }
    }

} 