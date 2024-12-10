//Joy Schulze
//December 10th
//Stores the value of the gold
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int value = 50;
    public float fallTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        if(value > 50)
            transform.localScale *= 2;
    }
    void FixedUpdate(){
        if(fallTime > 0){
            transform.position += Vector3.down * 0.04f;
            fallTime -= 0.01f;
        }
    }
}
