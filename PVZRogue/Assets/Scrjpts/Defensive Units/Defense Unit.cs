//Joy Schulze
//December 3rd
//The base script with a defensive unit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseUnit : MonoBehaviour
{
    //Instantiate variables
    public int health = 100;
    public int cost = 10;

    public Sprite iconSprite;

    public GridSpace gridSpace;

    ///Once the defense unit is spawned, it will set the grit space its on to being filled so nothing else can be placed there.
    void Start(){
        gridSpace.empty = false;
    }
    ///Once the unit runs out of health, it will empty it's grid space, and despawn.
    void Update(){
        if(health <= 0){
            gridSpace.empty = true;
            Destroy(gameObject);
        }
    }
}
