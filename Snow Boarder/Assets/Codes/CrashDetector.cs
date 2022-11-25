using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadingScene = 0.5f;
    [SerializeField] ParticleSystem addParticle;
    [SerializeField] AudioClip crashSFX;
    CircleCollider2D playerHead;
    bool crashingSequence = false;
    private void Start() 
    {
        playerHead = GetComponent<CircleCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && crashingSequence == false)
        {
            crashingSequence = true;
            FindObjectOfType<PlayerController>().DisableControls();
            addParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadingScene);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
