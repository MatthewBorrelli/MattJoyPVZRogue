using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Last Updated: 12/5/24
/// Function: Handles Zombie Stats 
/// </summary>

public class Zombie : MonoBehaviour
{
    public int zombieHealth = 100;

    public void takeDamage(int damage)
  // Makes zombie dissappear when health reaches 0
    {
        zombieHealth -= damage; 
        if (zombieHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
