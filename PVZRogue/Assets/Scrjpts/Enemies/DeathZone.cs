using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent <Zombie>())
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
