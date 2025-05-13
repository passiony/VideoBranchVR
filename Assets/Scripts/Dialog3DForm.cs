using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog3DForm : MonoBehaviour
{
    private TextMeshProUGUI m_Title;
    private TextMeshProUGUI m_Content;
    private Button[] m_Buttons;
    private CanvasGroup m_CanvasGroup;

    void Awake()
    {
        m_Title = transform.Find("Root/Title").GetComponent<TextMeshProUGUI>();
        m_Content = transform.Find("Root/Content").GetComponent<TextMeshProUGUI>(); // 修正为查找"Content"对象
        m_Buttons = new Button[3];
        for (int i = 0; i < 3; i++)
        {
            m_Buttons[i] = transform.Find($"Root/Bottom/Menu{i + 1}").GetComponent<Button>();
        }
        m_CanvasGroup = gameObject.GetComponent<CanvasGroup>();
        m_CanvasGroup.alpha = 0;
    }

    void Start()
    {
        // EventSystem.current.SetSelectedGameObject(m_Buttons[0].gameObject);
        m_CanvasGroup.DOFade(1, 1);
    }

    public void ShowDialog(string title, string content, string yes, Action callback)
    {
        m_Title.text = title;
        m_Content.text = content;
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].gameObject.SetActive(false);
        }

        m_Buttons[0].gameObject.SetActive(true);
        m_Buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = yes;
        m_Buttons[0].onClick.RemoveAllListeners();
        m_Buttons[0].onClick.AddListener(() => callback?.Invoke());
    }

    public void ShowDialog(string title, string content, string yes, string no, Action yesCallback, Action noCancel)
    {
        m_Title.text = title;
        m_Content.text = content;
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].gameObject.SetActive(false);
            m_Buttons[i].onClick.RemoveAllListeners();
        }

        m_Buttons[0].gameObject.SetActive(true);
        m_Buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = yes;
        m_Buttons[0].onClick.AddListener(() => yesCallback?.Invoke());

        m_Buttons[1].gameObject.SetActive(true);
        m_Buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = no;
        m_Buttons[1].onClick.AddListener(() => noCancel?.Invoke());
    }

    public void ShowDialog(string title, string content, string menu1, string menu2, string menu3, Action callback1,
        Action callback2, Action callback3)
    {
        m_Title.text = title;
        m_Content.text = content;
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].gameObject.SetActive(false);
            m_Buttons[i].onClick.RemoveAllListeners();
        }

        m_Buttons[0].gameObject.SetActive(true);
        m_Buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = menu1;
        m_Buttons[0].onClick.AddListener(() => callback1?.Invoke());

        m_Buttons[1].gameObject.SetActive(true);
        m_Buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = menu2;
        m_Buttons[1].onClick.AddListener(() => callback2?.Invoke());

        m_Buttons[2].gameObject.SetActive(true);
        m_Buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = menu3;
        m_Buttons[2].onClick.AddListener(() => callback3?.Invoke());
    }

    public void ShowDialog(string title, string content, string[] menes, Action[] callbacks)
    {
        m_Title.text = title;
        m_Content.text = content;
        for (int i = 0; i < m_Buttons.Length; i++)
        {
            m_Buttons[i].gameObject.SetActive(false);
            m_Buttons[i].onClick.RemoveAllListeners();
        }

        for (int i = 0; i < menes.Length; i++)
        {
            var menu = menes[i];
            var callback = callbacks[i];
            m_Buttons[i].gameObject.SetActive(true);
            m_Buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = menu;
            m_Buttons[i].onClick.AddListener(() => callback?.Invoke());
        }
    }
}