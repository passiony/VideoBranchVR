using System;
using System.Collections;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogListening : MonoBehaviour
{
    //2分40s,毒死许仙
    public float m_Delay = 160f;
    public bool m_IsPC;
    public float m_ListenTime = 10f;

    private MediaPlayer m_MediaPlayer;
    private VoiceTrigger m_VoiceTrigger;
    
    private void Awake()
    {
        m_MediaPlayer = FindObjectOfType<MediaPlayer>();
        m_VoiceTrigger = gameObject.GetComponent<VoiceTrigger>();
        m_VoiceTrigger.OnEndEvent.AddListener(OnSpeechEnd);
    }


    void Start()
    {
        if (m_IsPC)
        {
            StartCoroutine(PCListening());
        }
        else
        {
            StartCoroutine(VRListening());
        }
    }

    IEnumerator PCListening()
    {
        yield return new WaitForSeconds(m_Delay);
        m_MediaPlayer.Control.Pause();
        UIManager.ShowDialog("", "", new[] { "请叫\"姐夫\"" }, new Action[]
        {
            () =>
            {
                MapPanel.LoadedMap("1");
                m_MediaPlayer.Control.Play();
                StopAllCoroutines();
            }
        });
        yield return new WaitForSeconds(m_ListenTime);
        MapPanel.LoadedMap("2");
        SceneManager.LoadScene("Game403");
    }
    
    private IEnumerator VRListening()
    {
        m_VoiceTrigger.enabled = true;
        yield return new WaitForSeconds(m_ListenTime);
        m_VoiceTrigger.enabled = false;
        MapPanel.LoadedMap("2");
        SceneManager.LoadScene("Game403");
    }
    
    private void OnSpeechEnd()
    {
        MapPanel.LoadedMap("1");
        m_MediaPlayer.Control.Play();
        m_VoiceTrigger.enabled = false;
        StopAllCoroutines();
    }


}