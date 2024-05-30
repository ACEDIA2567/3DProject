using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICursor : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemDec;

    ItemData data;

    void Start()
    {
        GameManager.Instance.Player.ItemInfoObject = this;
        gameObject.SetActive(false);
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
