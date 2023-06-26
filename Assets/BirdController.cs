using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BirdController : MonoBehaviour
{
    // Creating variable and giving it a name 
    public Rigidbody2D myrigidbody;
    private LogicScript Logic;
   

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Logic._isGameStart) return;
        /// To tell the system if I press Space apply the body statement
        // && means both conditions should be true.
        // || means any of conidtions is true it will work.
        if (Logic.birdIsAlive == true)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) == true || Input.GetKeyDown(KeyCode.Mouse0) == true)
            {
                myrigidbody.velocity = Vector2.up * Logic.Ystrength;

            }


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Logic.gameOver();
        Logic.birdIsAlive = false;
        Logic._isGameStart = false;
        birdPhysics(false);
    }


    public void Gamestart()
    {
        if (!Logic._isGameStart) return;

        if (Logic.Speed.text.Length > 0)
        {
            Logic.Ystrength = int.Parse( Logic.Speed.text);
            // 
            Physics2D.gravity = new Vector2(0, float.Parse(Logic.gravity.text));

        }
        else
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
        birdPhysics(true);

    }

    public void birdPhysics(bool _isstart)
    {
        if (!_isstart)
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }

}
