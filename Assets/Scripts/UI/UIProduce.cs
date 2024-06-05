using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIProduce : MonoBehaviour
{
    public GameObject ProduceObject;
    public Transform ProduceTransform;

    Produce[] produces;

    void Start()
    {
        ProduceObject.SetActive(false);
    }

    // ���۹� UI ��/Ȱ��ȭ ó��
    public void OnProduce(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (ProduceObject.activeInHierarchy)
            {
                GameManager.Instance.Player.cursor.craftCursor = true;
                GameManager.Instance.Player.cursor.CursorCheck();
                ProduceObject.SetActive(false);
            }
            else
            {
                GameManager.Instance.Player.cursor.craftCursor = false;
                GameManager.Instance.Player.cursor.CursorCheck();
                ProduceObject.SetActive(true);
                GameManager.Instance.Player.ViewProduce?.Invoke();
            }
        }
    }
}
