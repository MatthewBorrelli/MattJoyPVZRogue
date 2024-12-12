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

    ///When the explosion hits the zombies, it will call a coroutine to make sure it doesn't hit the zombies on every frame of existence
    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Zombie>() && !hitBoxOver){
            other.GetComponent<Zombie>().takeDamage(damage);
            StartCoroutine(ActiveFrames());
        }
    }
    ///The coroutine that deactivates the explosion's damage after about a frame
    IEnumerator ActiveFrames(){
        yield return new WaitForSeconds(explosionSeconds);
        hitBoxOver = true;
    }
}
