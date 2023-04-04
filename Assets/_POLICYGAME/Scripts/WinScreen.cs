using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] Canvas WinCanvas;
    // Start is called before the first frame update
    public void EnableCanvas()
    {
        WinCanvas.enabled = true;
    }
}
