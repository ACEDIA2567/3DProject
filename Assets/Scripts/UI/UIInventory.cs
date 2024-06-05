using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInventory : MonoBehaviour
{
    public Transform inventoryTransform;
    public GameObject inventoryObject;
    private Slot[] slots;

    private void Start()
    {
        GameManager.Instance.Player.AddItem += Add;
        slots = new Slot[inventoryTransform.childCount];
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = inventoryTransform.GetChild(i).GetComponent<Slot>();
            slots[i].Clear();
            slots[i].index = i;
        }
        inventoryObject.SetActive(false);
        GameManager.Instance.Player.inventory = this;
    }

    public Slot GetSlot(int index)
    {
        return slots[index];
    }

    void Add()
    {
        ItemData itemData = GameManager.Instance.Player.currentData;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == itemData &&
                slots[i].slotQuantity < slots[i].data.maxCount)
            {
                slots[i].slotQuantity++;
                GameManager.Instance.Player.currentData = null;
                UpdateUI();
                return;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == null)
            {
                slots[i].data = itemData;
                slots[i].slotQuantity = 1;
                slots[i].delayTime = itemData.delayTime;
                GameManager.Instance.Player.currentData = null;
                UpdateUI();
                return;
            }
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    public bool CheckItem(string name, int value)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == null)
            {
                continue;
            }

            // 아이템이 있다면
            if (slots[i].data.itemName == name)
            {
                // 제작 가능한 아이템보다 개수가 많다면
                if (slots[i].slotQuantity >= value)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void RemoveItem(string name, int value)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == null)
            {
                continue;
            }

            // 아이템과 같은 이름 검색
            if (slots[i].data.itemName == name)
            {
                slots[i].slotQuantity -= value;
                break;
            }
        }
        
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (inventoryObject.activeInHierarchy)
            {
                GameManager.Instance.Player.cursor.invenCursor = true;
                GameManager.Instance.Player.cursor.CursorCheck();
                inventoryObject.SetActive(false);
                GameManager.Instance.Player.cursor.gameObject.SetActive(false);
            }
            else
            {
                GameManager.Instance.Player.cursor.invenCursor = false;
                GameManager.Instance.Player.cursor.CursorCheck();
                inventoryObject.SetActive(true);
            }
        }
    }
}
