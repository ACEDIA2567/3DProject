using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public Equipment equip;
    

    public ItemData currentData;
    public int dataQuantity = 0;
    public float dataDelayTime = 0;
    public Action AddItem;

    public UICursor cursor;
    public UIInventory inventory;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        equip = GetComponent<Equipment>();
    }

    public void CursorSet()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    public void StartCo(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public void EndCo(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
    }

    public void ItemClear()
    {
        currentData = null;
        dataQuantity = 0;
        dataDelayTime = 0;
    }
}
