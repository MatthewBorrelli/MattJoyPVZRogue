//Joy Schulze
//December 3rd
//The base script with a defensive unit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUnit : MonoBehaviour
{
    public int health = 100;
    public int cost = 10;

    public Sprite iconSprite;

    public GridSpace gridSpace;

    void Start(){
        gridSpace.empty = false;
    }

    void Update(){
        if(health <= 0){
            gridSpace.empty = true;
            Destroy(gameObject);
        }
    }
}
