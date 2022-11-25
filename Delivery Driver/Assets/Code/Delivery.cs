using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    //we store the colors we want here 
    [SerializeField]Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField]Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField]float destroyDelay = 0.5f;
    bool hasPackage;
    //define a spriterenderer here
    SpriteRenderer spriteRenderer;
    void Start() 
    {
        //and we are getting the SpriteRenderer Component here that is attached to this code
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && hasPackage == false)
        {
            Debug.Log("Package Picked!");
            hasPackage = true;
            //and assigning the color section of the SpriteRenderer to the one we defined before
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,destroyDelay);
        }
        else if(other.tag == "Person" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
