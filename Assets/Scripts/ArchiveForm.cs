using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArchiveForm : MonoBehaviour
{
    public TextMeshProUGUI m_Content;
    public float Delay = 2;
    private CanvasGroup m_CanvasGroup;
    
    IEnumerator Start()
    {
        m_CanvasGroup = gameObject.GetComponent<CanvasGroup>();
        yield return new WaitForSeconds(Delay);
        UIManager.ShowDialog("", "", new[] { "返回首页" }, new Action[]
        {
            () =>
            {
                Debug.Log("返回首页");
                SceneManager.LoadScene(0);
            }
        });
        m_CanvasGroup.DOFade(0, 1).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
    
    public void ShowArchive(string name)
    {
        m_Content.text = name;
    }
}