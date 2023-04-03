using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayObstacle : MonoBehaviour
{
    [SerializeField] EndGame endgameptr;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            endgameptr.OnEndGame("You may not go here without passing the questionaire.");
        }
      
    }
}
