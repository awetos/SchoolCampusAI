using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class LouisNPC : MonoBehaviour
{
    [SerializeField] NavMeshAgent _myAgent;
    [SerializeField] Animator _animator;
    [SerializeField] Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        StartWalkingAnimation();
        _myAgent.SetDestination(destination);   
    }

    private void Update()
    {
        if (CheckDistance() == true)
        {
         
            StopWalking();
        }
    }

    [SerializeField] const float arrived = 0.5f;
    bool CheckDistance()
    {
        if(Vector3.Distance(transform.position, destination) < arrived * 2)
        {
            _animator.SetBool("IsWalking", false); //stop the walking animation when you are close.
        }
        if(Vector3.Distance(transform.position, destination) < arrived)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void StartWalkingAnimation()
    {
        _animator.SetBool("IsWalking", true);
    }
    void StopWalking()
    {
       
        _myAgent.speed = 0;
        _myAgent.velocity = Vector3.zero;
        _myAgent.angularSpeed = 0;
        transform.LookAt(new Vector3(31.4108734f, 0, -6.55000019f));
    }
}
