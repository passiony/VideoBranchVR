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
        StartCoroutine(CheckAudioComplete());
    }

    IEnumerator CheckAudioComplete()
    {
        while (audioSource.isPlaying)
            yield return null;

        SceneManager.LoadScene(0);
    }
}
