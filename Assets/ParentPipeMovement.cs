using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPipeMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    LogicScript Logic;
    // Start is called before the first frame update
    void Start()
    {
        Logic = FindObjectOfType<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Logic._isGameStart) return;

        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted" + gameObject.name);
            Destroy(gameObject);
        }
    }

}
