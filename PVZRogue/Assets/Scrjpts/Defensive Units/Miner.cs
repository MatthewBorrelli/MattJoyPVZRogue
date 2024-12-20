//Joy Schulze
//December 11th
//Lets the miner unit periodically spawn gold. Gold is randomly double value.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    //instantiate variables
    public GameObject gold;

    // Call invoke reapeating
    void Start()
    {
        InvokeRepeating("SpawnGold", 10f, 10f);
    }
    ///Spawns gold on itself, has a 10% chance to spawn a big piece  of gold
    private void SpawnGold(){
        int rand = Random.Range(1, 10);

        if(rand < 10)
            gold.GetComponent<Gold>().SetValueAndFallTime(50, 0.2f);
        else
            gold.GetComponent<Gold>().SetValueAndFallTime(100, 0.2f);
        
        Instantiate(gold, transform.position + (Vector3.back * 2), transform.rotation);
        gold.GetComponent<Gold>().SetValueAndFallTime(50, 0.2f);
    }
}
