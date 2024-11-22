using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    public float smooth = 0.125f;  
    public Vector3 offset; 

    // Start is called before the first frame update
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;

       
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 5, -10);  
        }
    }

   
    void LateUpdate()
    {
      
        Vector3 desiredPosition = player.position + offset;

       
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smooth * Time.deltaTime);
    }
}