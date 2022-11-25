using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;
    [SerializeField] Vector3 movementVec;
    float movementFac;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) {return;}
        float cycles = Time.time / period; //continually growing over time

        const float tau =Mathf.PI * 2; //constant value of 6.283...
        float rawSinWave =Mathf.Sin(tau * cycles); //going from -1 to 1

        movementFac = (rawSinWave + 1f)/ 2f; //recalculated to go from 0 to 1 so its cleaner

        Vector3 offset = movementVec * movementFac;
        transform.position = startingPos + offset;
    }
}
