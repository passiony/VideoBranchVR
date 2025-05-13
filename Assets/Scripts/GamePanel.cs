using System;
using System.Collections.Generic;
using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Button mapBtn;
    public GameObject mapPanel;

    private void Awake()
    {
        FindObjectOfType<MediaPlayer>().Loop = false;
        mapBtn.onClick.AddListener(() => { mapPanel.SetActive(true); });
    }

}