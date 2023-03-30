using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationStateSwitchTest : MonoBehaviour
{
    [SerializeField] Animator controller;
    // Start is called before the first frame update
    void Start()
    {
        controller.Play("Running Crawl");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
