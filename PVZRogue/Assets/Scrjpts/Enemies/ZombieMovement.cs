using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name: Matthew Borrelli
/// Last Updated: 12/11/24
/// Function: Handles Zombie movement
/// </summary>
public class ZombieMovement : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;


    public float zombieSpeed = 0.5f; //Defines zombies moving speed
    public float zombieDefaultSpeed = 0.5f; //Defines zombies default moving speed
    public float attackSpeed = 1; //Defines the attack speed of the  zombie
    public float rightSpeed = 0.5f; // Defines the speed of the zombie moving right (aka delaying an attack)
    public int zombieDamage = 25; //Dictates damage delt to plants 
    public bool isAttacking = false; //Dictates whether or not the zombie is attacking
    public bool movingLeft = true; //Dictates whether or not the zombie is moving left


    private void Start()
    {
        zombieDefaultSpeed = zombieSpeed;
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
        if (other.gameObject.GetComponent<DefenseUnit>() && !isAttacking)
        {
            movingLeft = false;
            other.gameObject.GetComponent<DefenseUnit>().health -= zombieDamage;
            StartCoroutine(AttackingPlant(other.gameObject.GetComponent<DefenseUnit>()));
        }
    }


    //Allows the zombie to move 
    private void zombieMove()
    {
        if (movingLeft)
        {
            transform.position += Vector3.left * zombieSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * rightSpeed * Time.deltaTime;
        }
    }


    
    public IEnumerator AttackingPlant(DefenseUnit plant)
        //Allows the zombie to attack the plant in intervals so the kill isn't instantanious
    {
        yield return new WaitForSeconds(attackSpeed);
                isAttacking = false;
                movingLeft = true;
    }
}
