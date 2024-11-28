using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class turtlePlatform : MonoBehaviour
{
    public Transform platform;
    public Transform[] posAtual;
    private int IdPos;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        //platform = transform.parent;
        /*foreach (var ponto in posAtual)
        {
            ponto.parent = null;
        }*/
        platform.position = posAtual[0].position;
        IdPos = 1;
        
       
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, posAtual[IdPos].position, speed * Time.deltaTime);

        if (Vector3.Distance(platform.position, posAtual[IdPos].position)<0.01f)
        {
            IdPos += 1;
        }

        if (IdPos == posAtual.Length)
        {
            IdPos = 0;
        }
        
        
        
       
    }
    
    
}
