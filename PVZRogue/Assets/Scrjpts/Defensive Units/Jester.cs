//Joy Schulze
//December 15th
//Makes the jester 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    //Instanitate variables
    public bool primed = false;
    public float timer = 15f;

    public SpriteRenderer spriteRend;
    public DefenseUnit defU;

    ///At the very beginning, the jester will call a coroutine to start it's timer, once that's over it will be able to explode
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        defU = GetComponent<DefenseUnit>();
        StartCoroutine(ActivationWait());
    }
    ///If the jester is primed, then he will exlode all over the zombies
    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Zombie>() && primed)
            StartCoroutine(ExplodeAndDespawn());
    }
    ///Waits however long the time variable is to prime the explosive
    IEnumerator ActivationWait(){
        yield return new WaitForSeconds(timer);
        primed = true;
        StartCoroutine(Flashing());
    }
    ///Once the jester is primed, it will flash red
    IEnumerator Flashing(){
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(1);
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(1);
        StartCoroutine(Flashing());
    }
    ///Activatess the explosion hitbox, empties it's grit space, and destroys itself.
    IEnumerator ExplodeAndDespawn(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        defU.gridSpace.empty = true;
        Destroy(gameObject);
    }
}
