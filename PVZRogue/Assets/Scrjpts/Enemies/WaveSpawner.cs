//Joy Schulze and Matthew Borrelli
//December, 11
//Controls zombie spawning, the time inbetween zombie spawning and transitioning to the next level
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    ///Instantiates variables
    public int nextSceneIndex = 2; //The next scene once all the zombies are killed
    public int zombiesToKill = 20; //The number of zombies that will show up in each level
    public GameObject[] zombiesInLevel; //An array of the different types of zombies in each level
    public GameObject[] zombieSpawners; //An array of the different spawn positions that the zombies can use
    public int wave = 1; //The wave that the player is on, as the wave number increases, the number of zombies that spawn ever 7 seconds increases
    public int zombiesSpawned = 0; //The number of zombies that have been spawned
    public int zombiesKilled = 0; //The number of zombies taht have been killed

    ///Calls the invoke repeating of the zombie spawning
    void Start()
    {
        InvokeRepeating("SpawnZombies", 10f, 7f);
    }
    ///Randomly spawns zombies 
    void SpawnZombies(){
        if(zombiesSpawned <= zombiesToKill){
            //Checks to see if the wave needs to be increased
            if(zombiesKilled >= wave * 10){
                wave++;
            }
            //Selects a random zombie, and a random zombie spawner, and then spawns them. Happens wave times every 7 seconds.
            for(int i = 0; i < wave; i++){
                int currentZombie = Random.Range(0, zombiesInLevel.Length - 1);
                int currentSpawner = Random.Range(0, zombieSpawners.Length - 1);
                float randomDistance = Random.Range(-0.3f, 0.3f);
                Instantiate(zombiesInLevel[currentZombie], zombieSpawners[currentSpawner].transform.position + (Vector3.right * randomDistance), transform.rotation);
                zombiesSpawned++;
            }
        }
    }
    ///Checks to see if the number of zombies needed to proceed to the next level has been reached
    void Update(){
        if(zombiesKilled >= zombiesToKill){
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
