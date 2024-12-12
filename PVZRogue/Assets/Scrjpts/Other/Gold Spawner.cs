//Joy Schulze
//December 10th
// Controls the spawning of the gold. BEARS NO RESEMBLANCE TO HARVESTER!!!!!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    //Instantiate variables
    public GameObject gold;
    public GameObject rightBounds;
    public GameObject leftBounds;

    public float rightX;
    public float leftX;

    public float spawnerSpeed = 10;

    public float timer;
    public float fallTime;
    public int GOLDVALUE = 50;

    ///Sets the bounds of the gold spawner and then starts the invoke repeating
    void Start()
    {
        rightX = rightBounds.transform.position.x;
        leftX = leftBounds.transform.position.x;

        timer = Random.Range(5f, 9f);
        fallTime = Random.Range(1f, 3f);
        InvokeRepeating("SpawnGold", 0f, timer);
    }
    ///Moves the gold spawner in between it's 2 bounds
    void FixedUpdate(){
        transform.position += Vector3.left * spawnerSpeed * Time.deltaTime;
        if(transform.position.x > rightX || transform.position.x < leftX)
            spawnerSpeed *= -1;
    }
    ///Randomizes how far down the gold will fall and then spawns it
    public void SpawnGold(){
        gold.GetComponent<Gold>().fallTime = fallTime;

        timer = Random.Range(4f, 7f);
        fallTime = Random.Range(1f, 3f);

        Instantiate(gold, transform.position, transform.rotation);
    }
}
