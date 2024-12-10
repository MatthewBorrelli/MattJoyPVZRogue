//Joy Schulze
//December 10th
// Controls the spawning of the gold
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{

    public GameObject gold;
    public GameObject rightBounds;
    public GameObject leftBounds;

    public float rightX;
    public float leftX;

    public float spawnerSpeed = 10;

    public float timer;
    public float fallTime;

    // Start is called before the first frame update
    void Start()
    {
        rightX = rightBounds.transform.position.x;
        leftX = leftBounds.transform.position.x;

        timer = Random.Range(4f, 7f);
        fallTime = Random.Range(1f, 3f);
        InvokeRepeating("SpawnGold", 0f, timer);
    }

    void FixedUpdate(){
        transform.position += Vector3.left * spawnerSpeed * Time.deltaTime;
        if(transform.position.x > rightX || transform.position.x < leftX)
            spawnerSpeed *= -1;
    }

    public void SpawnGold(){
        gold.GetComponent<Gold>().fallTime = fallTime;

        timer = Random.Range(4f, 7f);
        fallTime = Random.Range(1f, 3f);

        Instantiate(gold, transform.position, transform.rotation);
    }
}
