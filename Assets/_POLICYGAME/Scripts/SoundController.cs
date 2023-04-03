using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource backgroundmusic;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
