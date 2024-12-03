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

    public SpriteRenderer iconSprite;

    void Start(){
        iconSprite = GetComponent<SpriteRenderer>();
    }
}
