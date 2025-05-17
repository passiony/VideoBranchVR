using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioJump : MonoBehaviour
{
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (audioSource.time >= audioSource.clip.length - 0.01f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
