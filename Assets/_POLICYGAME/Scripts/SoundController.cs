using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource backgroundmusic;
    public static SoundController Instance { get; private set; }
  
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;

    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
