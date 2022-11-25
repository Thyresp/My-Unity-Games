using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    //SerializeField is an example of an atribute
    //that allows us to serialize in other words write to disc this variable
    //plus it is way easier to change in engine imo
    [SerializeField]float steerSpeed = 150;
    [SerializeField]float moveSpeed = 15;
    [SerializeField]float slowSpeed = 10;
    [SerializeField]float fastSpeed = 20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")* steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = fastSpeed;
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

}
