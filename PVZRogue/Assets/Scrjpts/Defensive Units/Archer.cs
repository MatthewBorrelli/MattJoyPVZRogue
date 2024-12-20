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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 3f, 3f);
    }
    ///Shoots an arrow if a zombie is in it's lane
    public void Shoot()
    {
        if(Physics.Raycast(transform.position + (Vector3.back * 0.1f), Vector3.right, out hit)){
            if(hit.collider.GetComponent<Zombie>())
                Instantiate(arrow, transform.position + (Vector3.back * 0.1f), transform.rotation);
        }
    }  
}
