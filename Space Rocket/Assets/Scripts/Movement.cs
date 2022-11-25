using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust =100f;
    [SerializeField] float rotateThrust = 75f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;



    public Rigidbody rb;
    public AudioSource audSou;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audSou = GetComponent<AudioSource>();
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
           StartThrusting();
       }
       else
       {
           StopThrusting();
       }
    }
    void ProcessRotate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            RotatingRight();

        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotatingLeft();

        }
        else
        {
            StopRotating();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(0, 1, 0 * mainThrust * Time.deltaTime);
        if (!audSou.isPlaying)
        {
            audSou.PlayOneShot(mainEngine);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    private void StopThrusting()
    {
        audSou.Stop();
        mainBooster.Stop();
    }

    private void RotatingRight()
    {
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
        ApplyRotation(-rotateThrust);
    }

    private void RotatingLeft()
    {
        if (!leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
        ApplyRotation(rotateThrust);
    }


    private void StopRotating()
    {
        rightBooster.Stop();
        leftBooster.Stop();
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so physics system can take over
    }
}
