using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using RenderHeads.Media.AVProVideo;
using UnityEngine.Events;

public class Processing : MonoBehaviour
{
    public string m_Title = "";
    public string m_Content = "";
    public string[] m_Menus;
    public string[] m_Scenes;
    public bool Mute = true;
    public string Archive = "";
    
    public UnityEvent OnTrigger1;
    public UnityEvent OnTrigger2;
    public UnityEvent OnTrigger3;

    private MediaPlayer m_MediaPlayer;

    private void Awake()
    {
        m_MediaPlayer = FindObjectOfType<MediaPlayer>();
        m_MediaPlayer.Loop = false;
        m_MediaPlayer.Events.AddListener(OnMediaEvent);
    }

    IEnumerator Start()
    {
        if (Mute)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForEndOfFrame();
                m_MediaPlayer.AudioMuted = true;
            }
        }
    }

    private void OnMediaEvent(MediaPlayer arg, MediaPlayerEvent.EventType arg1, ErrorCode arg2)
    {
        if (arg1 == MediaPlayerEvent.EventType.FinishedPlaying)
        {
            Debug.Log("播放完毕");
            ShowDialog();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowDialog();
        }
    }

    void ShowDialog()
    {
        if (m_Menus.Length == 0)
        {
            UIManager.ShowArchive(Archive);
        }

        UIManager.ShowDialog(m_Title, m_Content, m_Menus, new Action[]
        {
            () =>
            {
                Debug.Log("跳转到场景：" + m_Scenes[0]);
                OnTrigger1?.Invoke();
                if (m_Scenes[0] == "Launch")
                    SceneManager.LoadScene(m_Scenes[0]);
                else
                    SceneManager.LoadScene("Game" + m_Scenes[0]);
                MapPanel.LoadedMap(m_Scenes[0]);
            },
            () =>
            {
                Debug.Log("跳转到场景：" + m_Scenes[1]);
                OnTrigger2?.Invoke();
                SceneManager.LoadScene("Game" + m_Scenes[1]);
                MapPanel.LoadedMap(m_Scenes[1]);
            },
            () =>
            {
                Debug.Log("跳转到场景：" + m_Scenes[2]);
                OnTrigger3?.Invoke();
                SceneManager.LoadScene("Game" + m_Scenes[2]);
                MapPanel.LoadedMap(m_Scenes[2]);
            }
        });
    }
}