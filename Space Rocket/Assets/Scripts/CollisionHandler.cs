using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
   [SerializeField] float Delayer = 1f;
   [SerializeField] AudioClip SuccesAudio;
   [SerializeField] AudioClip FailureAudio;
   [SerializeField] ParticleSystem SuccesParticle;
   [SerializeField] ParticleSystem FailureParticle;

   public AudioSource audSou;
   
   bool isTransitioning = false;
   bool CollisionDisabled = false;

    void Start()
    {
        audSou = GetComponent<AudioSource>();
    }

   void Update()
    {
        DevCheats();
    }

   void DevCheats()
    {
        //cheato bois
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            CollisionDisabled = !CollisionDisabled;
        }
    }

    void OnCollisionEnter(Collision other) 
   {
      if (isTransitioning || CollisionDisabled) {return;}
   
    switch (other.gameObject.tag)
       {
        case "Friendly":
           Debug.Log("you hit friendly");
           break;
        case "Finish":
           StartLoadingSequence();
           break;
        default:
           StartCrashSequence();
           break;   

       }

   }



   void StartLoadingSequence()
   {
      isTransitioning = true;
      audSou.Stop();
      audSou.PlayOneShot(SuccesAudio);
      SuccesParticle.Play();
      GetComponent<Movement>().enabled = false;
      Invoke("LoadNextLevel", Delayer);

   }
   void StartCrashSequence()
   {
      isTransitioning = true;
      audSou.Stop();
      audSou.PlayOneShot(FailureAudio);
      FailureParticle.Play();
      GetComponent<Movement>().enabled = false;
      Invoke("ReloadLevel", Delayer);

   }
   
   void LoadNextLevel()
   {

       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex = currentSceneIndex + 1;
       if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
       {
           nextSceneIndex = 0;
       }
       SceneManager.LoadScene(nextSceneIndex);
   }

   void ReloadLevel()
   {

       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(currentSceneIndex);
   }

}