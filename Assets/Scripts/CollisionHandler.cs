using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Fuel":
                 Debug.Log("Fuel Added");
                 break;

            case "Friendly":
                 Debug.Log("Friendly!!!");
                 break;

            case "Finish":
                Debug.Log("Landed Safely");
                break;

            default:
                Debug.Log("Collided!!");
                break;       
        }   

    }
}
