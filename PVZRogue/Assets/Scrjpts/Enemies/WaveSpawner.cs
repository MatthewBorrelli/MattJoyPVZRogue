//Joy Schulze and Matthew Borrelli
//December, 11
//Controls zombie spawning, the time inbetween zombie spawning and transitioning to the next level
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public ResourceManager reMan;
    public int nextSceneIndex = 2;
    public int zombiesToKill = 20;
    public GameObject[] zombiesInLevel;
    public GameObject[] zombieSpawners;
    public int wave = 1;
    public int zombiesSpawned = 0;
    public int zombiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZombies", 10f, 7f);
    }

    void SpawnZombies(){
        if(zombiesSpawned <= zombiesToKill){
            if(zombiesKilled >= wave * 10){
                wave++;
            }
            for(int i = 0; i < wave; i++){
                int currentZombie = Random.Range(0, zombiesInLevel.Length - 1);
                int currentSpawner = Random.Range(0, zombieSpawners.Length - 1);
                float randomDistance = Random.Range(-0.3f, 0.3f);
                Instantiate(zombiesInLevel[currentZombie], zombieSpawners[currentSpawner].transform.position + (Vector3.right * randomDistance), transform.rotation);
                zombiesSpawned++;
            }
        }
    }

    void Update(){
        if(zombiesKilled == zombiesToKill){
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
