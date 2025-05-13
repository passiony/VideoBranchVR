using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowMap : MonoBehaviour
{
    [SerializeField]
    InputActionProperty m_ButtonAction = new(new InputAction("Activate", type: InputActionType.Button));
    private void OnEnable()
    {
        m_ButtonAction.action.performed += OnPerformed;
    }

    private void OnDisable()
    {
        m_ButtonAction.action.performed -= OnPerformed;
    }
    private void OnPerformed(InputAction.CallbackContext obj)
    {
        UIManager.ShowGamePanel();
    }
}
