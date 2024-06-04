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
        produces = new Produce[ProduceTransform.childCount];
        for (int i = 0; i < produces.Length; i++)
        {
            produces[i] = ProduceTransform.GetChild(i).GetComponent<Produce>();
        }
    }

    // ���۹� UI ��/Ȱ��ȭ ó��
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
                GameManager.Instance.Player.ViewProduce?.Invoke();
            }
        }
    }
}