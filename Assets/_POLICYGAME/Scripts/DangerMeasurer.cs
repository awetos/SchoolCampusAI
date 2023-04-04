using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerMeasurer : MonoBehaviour
{
    // Start is called before the first frame update

    int currentDangerLevel;

    private void Start()
    {
        PrintDanger();
    }
    public void IncreaseDanger()
    {
        currentDangerLevel++;
        PrintDanger();

    }
    [SerializeField] TMPro.TMP_Text displaytext;
    void PrintDanger()
    {
        string threat = "";
        switch (currentDangerLevel)
        {
            case 0: threat = "NONE";
                break;
            case 1: threat = "MILD";
                break;
            case 2: threat = "MEDIUM";
                break;
            case 3: threat = "HIGH";
                break;
            default:
                break;
        }
        if(currentDangerLevel != 0)
        {
            displaytext.color = Color.red;
        }
        displaytext.text = "CURRENT THREAT LEVEL: " + threat;
    }

   
}
