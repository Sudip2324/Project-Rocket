using UnityEngine;
using UnityEngine.SceneManagement; 

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource; // reference of AudioSource
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField]float delay = 1f;

    bool isTransitioning = false;

    void Start() 
    {    
        audioSource = GetComponent<AudioSource>();     
    }
    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning) { return; }

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
                StartFinishSequence();
                break;

            default:
                Debug.Log("Collided!!");
                StartCrashSequence();
                break;       
        }   

    }

    void StartFinishSequence()
    {
        isTransitioning = true;
        if(isTransitioning == true)
        {
            GetComponent<Movement>().enabled = false;  
            Invoke("NextLevel", delay);
        }
        if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(success);
            }
        
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(crash);
            }
        if(isTransitioning == true)
        {
            GetComponent<Movement>().enabled = false;
        }    
          Invoke("ReloadLevel", delay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;        
        }
         SceneManager.LoadScene(nextSceneIndex);
    }
}
