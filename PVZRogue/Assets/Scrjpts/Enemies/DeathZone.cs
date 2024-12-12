using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Matthew Borrelli
/// Date: 12/11/24
/// Purpose: Gives the player a game over when a zombie reaches the deathzone.
/// </summary>
public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent <Zombie>())
        {
            //Destroys the zombie, and takes the player to the Game Over Screen
            Destroy(other.gameObject);
            SceneManager.LoadScene("Game Over");
        }
    }
}
