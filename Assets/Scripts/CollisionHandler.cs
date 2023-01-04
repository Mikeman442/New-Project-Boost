using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 3;
    [SerializeField] AudioClip splosion;
    [SerializeField] AudioClip finish;

    AudioSource audioSource;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is a friendly");
                break;
            
            case "Finish":
                StartFinishSequence();
                break;

            case "Fuel":
                Debug.Log("This is fuel");
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    { 
        // add Particle effect
        GetComponent<Playermovement>().enabled = false;
        audioSource.PlayOneShot(splosion);
        Invoke("ReloadLevel", delay);
    }

    void StartFinishSequence()
    {
        // add SFX
        // add Particle effect
        GetComponent<Playermovement>().enabled = false;
        audioSource.PlayOneShot(finish);
        Invoke("NextLevel", delay);
    }

    void ReloadLevel()
    {
        int getSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(getSceneIndex);
    }

    void NextLevel()
    {
        int getSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = getSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}
