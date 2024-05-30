using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float currentValue;
    public float maxValue;
    public float recoveryValue;
    public float decayValue;
    public Image amountImage;

    private void Start()
    {
        currentValue = maxValue / 2;
    }

    private void Update()
    {
        amountImage.fillAmount = currentValue / maxValue;
        Recovery();
    }

    private void Recovery()
    {
        if (currentValue < maxValue)
        {
            currentValue += recoveryValue * Time.deltaTime;
        }
        else
        {
            currentValue = maxValue;
        }
    }

    public void Up(float value)
    {
        currentValue = Mathf.Min(currentValue + value, maxValue);
    }

    public void Down(float value)
    {
        currentValue = Mathf.Max(0, currentValue - value);
    }
}
