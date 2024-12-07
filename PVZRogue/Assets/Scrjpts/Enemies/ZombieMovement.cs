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
        if (other.gameObject.GetComponent<DefenseUnit>() && !isAttacking)
        {
            isAttacking = true;
            StartCoroutine(AttackingPlant(other.gameObject.GetComponent<DefenseUnit>())); 
        }
    }


    //Allows the zombie to move 
    private void zombieMove()
    {
        if (!isAttacking)
        {
            transform.position += Vector3.left * zombieSpeed * Time.deltaTime;
        }
    }


    public IEnumerator AttackingPlant(DefenseUnit plant)
        //Allows the zombie to attack the plant in intervals so the kill isn't instantanious
    {
        isAttacking = true; 
        while (isAttacking)
        {
            plant.health =- zombieDamage;
            if (plant != null)
            {
                yield return new WaitForSeconds(attackSpeed);
            }
            else
                isAttacking = false;
        }
    }
}
