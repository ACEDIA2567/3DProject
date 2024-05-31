using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData currentData;
    public int dataQuantity = 0;
    public float dataDelayTime = 0;
    public Action AddItem;

    public UICursor ItemInfoObject;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
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
