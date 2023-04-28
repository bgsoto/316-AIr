using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class States : MonoBehaviour
{

    
    // States
    public enum State
    {
        Idle,
        Patrol,
        Attack
    }

    // Variables
    public State currentState;
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 5.0f;
    public Transform[] patrolPoints;
    public int currentPatrolPoint = 0;
    public GameObject EnemyPos;

    void Start()
    {
        // Set initial state
        currentState = State.Idle;
    }

    void Update()
    {
        // State machine
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Patrol:
                Patrol();
                break;
            case State.Attack:
                Attack();
                break;
        }
    }

    void Idle()
    {
        // Do idle animation
        Debug.Log("Idle");

        // Check for nearby enemies
        if (/* check for enemies */ collision)
        {
            // Switch to attack state
            currentState = State.Attack;
        }
        else
        {
            // Switch to patrol state
            currentState = State.Patrol;
        }
    }

    void Patrol()
    {
        // Move towards next patrol point
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, moveSpeed * Time.deltaTime);

        // Rotate towards next patrol point
        Vector3 direction = patrolPoints[currentPatrolPoint].position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Check if at patrol point
        if (transform.position == patrolPoints[currentPatrolPoint].position)
        {
            // Move to next patrol point
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
        }

        // Check for nearby enemies
        if (/* check for enemies */)
        {
            // Switch to attack state
            currentState = State.Attack;
        }
    }

    void Attack()
    {
        // Move towards enemy
       // transform.position = Vector3.MoveTowards(transform.position, /* enemy position */EnemyPos.transform.position  , moveSpeed * Time.deltaTime);

        // Rotate towards enemy
        Vector3 direction = /* enemy position */ -transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //shoot enemy


        // Check if enemy is dead
        if (EnemyPos != null)
        {
            // Switch to idle state
            currentState = State.Idle;
        }
    }
}

