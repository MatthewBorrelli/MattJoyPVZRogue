//Joy Schulze
//December 15th
//Makes the jester 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public bool primed = false;
    public float timer = 15f;

    public SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        StartCoroutine(ActivationWait());
    }

    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Zombie>() && primed)
            StartCoroutine(ExplodeAndDespawn());
    }

    IEnumerator ActivationWait(){
        yield return new WaitForSeconds(timer);
        primed = true;
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing(){
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(1);
        spriteRend.color = Color.white;
        yield return new WaitForSeconds(1);
        StartCoroutine(Flashing());
    }

    IEnumerator ExplodeAndDespawn(){
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
