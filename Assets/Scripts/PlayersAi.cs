using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class PlayersAI : MonoBehaviour
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
    public GameObject bulletPrefab;
    [SerializeField] private bool detected;
    [SerializeField] private GameObject NxtGoal;
    private NavMeshAgent agent1;


    // The force to apply to the bullet
    public float bulletForce = 1000f;

    // The rate at which to shoot bullets (in seconds)
    public float fireRate = 1f;

    void Start()
    {
        // Set initial state
        currentState = State.Idle;
        detected = false;
        agent1 = GetComponent<NavMeshAgent>();
        // InvokeRepeating("Shoot", 0f, fireRate);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            
            detected = true;

        }

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
        Debug.Log(currentState);
    }

    void Idle()
    {
        // Do idle animation
        Debug.Log("Idle");

        // Check for nearby enemies
        

            if (detected == true)
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
        agent1.destination = NxtGoal.transform.position;

        

        // Check for nearby enemies
        if (detected == true)
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
        Vector3 direction = EnemyPos.transform.position = /* enemy position */EnemyPos.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //shoot enemy
        InvokeRepeating("Shoot", 0f, fireRate);

        // Check if enemy is dead
        if (EnemyPos != null)
        {
            detected = false;
            currentState = State.Idle;
        }
    }
    // Method to shoot a bullet
    void Shoot()
    {
        // Instantiate a new bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Get the rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Add a force to the bullet
        rb.AddForce(transform.forward * bulletForce);
    }

   
}


