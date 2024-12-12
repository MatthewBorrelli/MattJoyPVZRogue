using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Last Updated: 12/11/24
/// Function: Makes the archer shoot his arrows
/// </summary>

public class Archer : MonoBehaviour
{
    public GameObject arrow;
    
    RaycastHit hit;
    public float rayLength = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 4f, 4f);
    }

    public void Shoot()
    {
        if(Physics.Raycast(transform.position + (Vector3.back * 0.1f), Vector3.right, out hit, rayLength)){
            if(hit.collider.GetComponent<Zombie>())
                Instantiate(arrow, transform.position + (Vector3.back * 0.1f), transform.rotation);
        }
    }  
}
