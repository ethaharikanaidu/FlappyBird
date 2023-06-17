using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour

{
    /* Default functions for unity
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
            
    }
    */
  
    public GameObject pipeprefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightoffset;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;

        }
        else
        {
            spawnPipe();
            timer = 0;
        }
        
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightoffset;
        float highestPoint = transform.position.y + heightoffset;


       GameObject clone = Instantiate(pipeprefab,new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0),transform.rotation);
        clone.name = "childpipe";

    }
    /* update is called two per frame
    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        
    }
    */

}
 