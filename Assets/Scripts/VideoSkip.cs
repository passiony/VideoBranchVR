using System.Collections;
using System.Collections.Generic;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.UI;

public class VideoSkip : MonoBehaviour
{
    public MediaPlayer m_MediaPlayer;
    public AudioSource m_AudioSource;

    public Button m_SkipBtn;
    public float m_SkipTime = 5f;
    
    void Start()
    {
        m_SkipBtn.onClick.AddListener(OnSkipClick);
    }

    private void OnSkipClick()
    {
        m_MediaPlayer.Control.Seek(m_SkipTime);
        m_AudioSource.time = m_SkipTime;
    }

}
