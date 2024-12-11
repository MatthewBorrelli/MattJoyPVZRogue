using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Last Updated: 12/11/24
/// Function: Makes the arrow arrow across the screen (how majestic)
/// </summary>
public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 5f;
    public int arrowDamage = 10;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * arrowSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){
        if(other.GetComponent<Zombie>()){
            other.GetComponent<Zombie>().takeDamage(arrowDamage);
            Destroy(gameObject);
        }   
    }
}
