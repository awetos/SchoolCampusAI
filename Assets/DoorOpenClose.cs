using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    [SerializeField] Vector3 OpenPosition;
    [SerializeField] Vector3 ClosePosition;
    [SerializeField] public bool isOpen;
    [SerializeField] public int DoorID;
    // Start is called before the first frame update
    void Start()
    {
        CloseDoor();
    }

    void OpenDoor()
    {
        transform.localPosition = Vector3.Lerp(ClosePosition,OpenPosition, 1f);
    }
    void CloseDoor()
    {
        transform.localPosition = Vector3.Lerp(OpenPosition, ClosePosition, 1f);
    }

}
