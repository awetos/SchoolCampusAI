using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

    public void OpenDoor()
    {
        StartCoroutine("OpenDoorAnimation");
    }
    public void CloseDoor()
    {

        StartCoroutine("CloseDoorAnimation");
    }
    const int MAX = 20;
    IEnumerator OpenDoorAnimation()
    {
        for(int i = 0; i < MAX; i++)
        {
            float t = (float)i / (float)MAX;
            transform.localPosition = Vector3.Lerp(ClosePosition, OpenPosition, t);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    IEnumerator CloseDoorAnimation()
    {

        for (int i = 0; i < MAX; i++)
        {
            float t = (float)i / (float)MAX;
            transform.localPosition = Vector3.Lerp(OpenPosition, ClosePosition, t);
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }
}
