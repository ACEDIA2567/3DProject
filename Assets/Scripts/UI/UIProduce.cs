using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIProduce : MonoBehaviour
{
    public GameObject ProduceObject;

    void Start()
    {
        ProduceObject.SetActive(false);
    }

    // 力累过 UI 厚/劝己拳 贸府
    public void OnProduce(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (ProduceObject.activeInHierarchy)
            {
                Cursor.lockState = CursorLockMode.Locked;
                ProduceObject.SetActive(false);
                GameManager.Instance.Player.ItemInfoObject.gameObject.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                ProduceObject.SetActive(true);
            }
        }
    }
}
