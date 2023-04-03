using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE : MonoBehaviour
{
    [SerializeField] bool CanPressE;
    [SerializeField] Answers answersptr;
    [SerializeField] GameObject MyQuad;
    [SerializeField] FirstPersonMovement myFPM;
    [SerializeField] FirstPersonLook myFPL;
    // Start is called before the first frame update
    void Start()
    {
        CanPressE = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("You may start the questionnaire.");
            CanPressE=true;
            MyQuad.SetActive(true);
        }
    }

    private void Update()
    {
        if(CanPressE == true && Input.GetKeyDown(KeyCode.E))
        {
            answersptr.StartQuestionnaire();
            myFPM.enabled = false;
            myFPL.enabled = false;
        }
    }
}
