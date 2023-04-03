using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [SerializeField] DoorOpenClose _myDoor;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Teacher")
        {
            Debug.Log("Opening Door Trigger Enter");
            _myDoor.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Teacher")
        {
            Debug.Log("Closing...");
            _myDoor.CloseDoor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Teacher")
        {
            Debug.Log("Opening Door Collision Enter");
            _myDoor.OpenDoor();
        }

    }
}
