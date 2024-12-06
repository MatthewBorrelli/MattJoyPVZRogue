using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Last Updated: 12/5/24
/// Function: Handles Zombie movement
/// </summary>
public class ZombieMovement : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;


    public float zombieSpeed = 0.5f;
    public float attackSpeed = 1;
    public int zombieDamage = 25;
    public bool isAttacking = false;


    private void Start()
    {
        leftPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        zombieMove();
    }


    //Stops the Zombie and deals damage to the plant it is colliding with
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DefenseUnit>())
        {
            zombieSpeed = 0;
            isAttacking = true;
            //call the attacking plant coroutine here
        }
    }


    //Allows the zombie to move 
    private void zombieMove()
    {
        transform.position += Vector3.left * zombieSpeed * Time.deltaTime;
    }


    public IEnumerator AttackingPlant()
        //Allows the zombie to attack the plant in intervals so the kill isn't instantanious
    {
        isAttacking = true; 
        for (float i = 0; i < attackSpeed; )
        {
            GetComponent<DefenseUnit>().health =- zombieDamage;
            yield return new WaitForSeconds(attackSpeed);
        }
        //after for loop is over, make sure to let the zombie move again
    }
        
}
