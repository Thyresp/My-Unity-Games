using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadSeconds = 0.75f;
    [SerializeField] ParticleSystem finishParticle;
    bool hasFinished = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !hasFinished)
        {
            hasFinished = true;
            finishParticle.Play();
            GetComponent<AudioSource>().Play();
            Invoke("Reloading", loadSeconds);
        }   
    }


    private void Reloading()
    {
        SceneManager.LoadScene(0);
    }
}
