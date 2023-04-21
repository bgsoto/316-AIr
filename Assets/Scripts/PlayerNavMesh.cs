using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;




public class PlayerNavMesh : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;


    private NavMeshAgent agent1;
    private void Awake()
    {
       
       agent1 = GetComponent <NavMeshAgent>();

    }

    private void Update()
    {
        agent1.destination = movePositionTransform.position;
    }

}
