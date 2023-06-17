using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BirdController : MonoBehaviour
{
    // Creating variable and giving it a name 
    public Rigidbody2D myrigidbody;
    public LogicScript logic;
    public bool birdIsAlive = true;
    //
    public InputField Speed, gravity;
    public int Ystrength = 10 ;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    private void OnEnable()
    {
        // parse converting string to float.
        Ystrength = int.Parse(Speed.text);
        // 
        Physics2D.gravity = new Vector2(0, float.Parse(gravity.text)); 
    }

    // Update is called once per frame
    void Update()
    {
        // To tell the system if I press Space apply the body statement
        // && means both conditions should be true.
        // || means any of conidtions is true it will work.
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            //New Vector2(0,1);
            myrigidbody.velocity = Vector2.up * Ystrength;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
