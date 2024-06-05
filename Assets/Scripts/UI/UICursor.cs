using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICursor : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemDec;

    public bool invenCursor = false;
    public bool craftCursor = false;
    public bool sleepCursor = false;

    ItemData data;

    void Start()
    {
        GameManager.Instance.Player.cursor = this;
        gameObject.SetActive(false);
    }

    public void CursorCheck()
    {
        if (invenCursor && craftCursor)
        {
            Debug.Log("커서 안 보이게");
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Debug.Log("커서 보이게");
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void UIUpdate(ItemData data)
    {
        if (this.data != data || this.data == null)
        {
            this.data = data;
            gameObject.SetActive(true);
            itemName.text = data.itemName;
            itemType.text = data.type.ToString();
            itemDec.text = data.description;
        }
        else
        {
            this.data = null;
            gameObject.SetActive(false);
        }
    }
}
