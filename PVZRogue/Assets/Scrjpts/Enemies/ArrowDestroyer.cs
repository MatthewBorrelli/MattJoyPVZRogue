using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name: Matthew Borrelli
/// Date: 12/11/24
/// Purpose: Destroys arrows after they go off screen
/// </summary>
public class ArrowDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent <Arrow>())
        {
            Destroy(other.gameObject);
        }
    }
}
