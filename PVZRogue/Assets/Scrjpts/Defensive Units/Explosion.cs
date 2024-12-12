//Joy Schulze
//December 11th
//Makes the explosion only hit 1 time
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage = 300;
    public bool hitBoxOver = false;
    public float explosionSeconds = 0.03f;

    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Zombie>() && !hitBoxOver){
            other.GetComponent<Zombie>().takeDamage(damage);
            StartCoroutine(ActiveFrames());
        }
    }

    IEnumerator ActiveFrames(){
        yield return new WaitForSeconds(explosionSeconds);
        hitBoxOver = true;
    }
}
