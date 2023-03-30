using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LouisNPC : MonoBehaviour
{
    [SerializeField] NavMeshAgent _myAgent;
    [SerializeField] Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        _myAgent.SetDestination(destination);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
