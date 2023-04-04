using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LouisNPC : MonoBehaviour
{
    [SerializeField] NavMeshAgent _myAgent;
    [SerializeField] Animator _animator;
    [SerializeField] Vector3 destination;

    [SerializeField] Vector3 destination_doors;

    [SerializeField] int currentClass;
    [SerializeField] int nextClass;

    [SerializeField] float originalspeed;

    // Start is called before the first frame update
    void Start()
    {
        originalspeed = _myAgent.speed;
        state = State.Lecturing;
        StartWalkingAnimation();
        SetNewDestination();
    }

    [SerializeField] List<Vector3> lectureLocations;

    int GOTOCLASS;

    public enum State { 
    
    Lecturing,
    Idling
    
    }

    [SerializeField] State state;

    void GoToFirstClass()
    {
        currentClass = Random.Range(0, lectureLocations.Count);

        Debug.Log("Going to classroom" + currentClass);


        _myAgent.SetDestination(lectureLocations[currentClass]);
        destination = lectureLocations[currentClass];
        _myAgent.speed = originalspeed;

        transform.LookAt(_myAgent.velocity);

        ClassHasStarted = false;

        StartWalkingAnimation();
    }

    void SetNewDestination()
    {
        
        StopAllCoroutines(); 
       currentClass =  Random.Range(0,lectureLocations.Count);

        Debug.Log("Going to classroom" + currentClass);


        _myAgent.SetDestination(lectureLocations[currentClass]);





        destination = lectureLocations[currentClass];
        _myAgent.speed = originalspeed;

        transform.LookAt(_myAgent.velocity);

        ClassHasStarted = false;
        state = State.Lecturing;
        StartWalkingAnimation();


    }
    private void Update()
    {
        if (CheckDistance() == true)
        {
         
            StopWalking();
            if(ClassHasStarted == false && state == State.Lecturing)
            {
                StartCoroutine("StartClass");
            }

            if(state == State.Idling)
            {
                SetNewDestination();
            }
           
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
        _animator.Play("StartWalking");
    }
    void StopWalking()
    {
       
        _myAgent.speed = 0;
        _myAgent.velocity = Vector3.zero;
        _myAgent.angularSpeed = 0;
        transform.LookAt(new Vector3(31.4108734f, 0, -6.55000019f));
    }

    bool ClassHasStarted = false;
    IEnumerator StartClass()
    {
        ClassHasStarted = true;
        Debug.Log("class is starting");
        yield return new WaitForSeconds(5f);
        Debug.Log("class dismissed");
        GoToIdleArea();
        state = State.Idling;
    }

    [SerializeField] Vector3 hallwayLocation;
    void GoToIdleArea()
    {


        Debug.Log("heading to the hallway.");
        destination = hallwayLocation;
        _myAgent.speed = originalspeed;

        transform.LookAt(hallwayLocation);
        StartWalkingAnimation();
        //  StartWalkingAnimation();
        StartCoroutine("WalkToHallway");
    }

    IEnumerator WalkToHallway()
    {
        for(int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.5f);
            float t = (float)i / (float)100;
            transform.position = Vector3.Lerp(lectureLocations[0], hallwayLocation,i);
        }
        StopWalking();
        
    }
}
