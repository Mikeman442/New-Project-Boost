using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This is a friendly");
                break;
            
            case "Finish":
                Debug.Log("This is the finish");
                break;

            case "Fuel":
                Debug.Log("This is fuel");
                break;

            default:
                Debug.Log("This will make you explode");
                break;
        }
    }
}
