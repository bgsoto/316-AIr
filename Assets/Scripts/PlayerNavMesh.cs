using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;




public class PlayerNavMesh : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private GameObject NxtGoal;
    //[SerializeField] private Transform NxtGoalLoc;


    private NavMeshAgent agent1;

    private void Awake()
    {

        agent1 = GetComponent<NavMeshAgent>();
        //NxtGoal = GameObject.FindWithTag("goal");
       // NxtGoalLoc = NxtGoal.transform;

    }

    private void Update()
    {
       // agent1.destination = movePositionTransform.position;


        // Check if the spawned goal is not null
       

            // Set this game object's transform to the spawned object's transform
            agent1.destination = NxtGoal.transform.position;

        



    }
}


