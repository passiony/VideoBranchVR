using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchPanel : MonoBehaviour
{
    public Button startBtn;
    public Button mapBtn;

    public GameObject mapPanel;

    private void Start()
    {
        startBtn.onClick.AddListener(() =>
        {
            MapPanel.ClearMap();
            SceneManager.LoadScene(1);
        });
        mapBtn.onClick.AddListener(() => { mapPanel.SetActive(true); });
        
        // 请求麦克风权限
        Permission.RequestUserPermission(Permission.Microphone);
    }
    
}