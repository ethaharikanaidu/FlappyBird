 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Creating variable and giving it a name 
    public Rigidbody2D myrigidbody;
    //  
    public float Ystrength = 10 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // To tell the system if I press Space apply the body statement
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            //New Vector2(0,1);
            myrigidbody.velocity = Vector2.up * Ystrength;
        }
    }
}
