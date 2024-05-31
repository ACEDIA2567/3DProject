using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public ItemData data;
    public Image icon;
    public Image delayIcon;
    public TextMeshProUGUI itemCount;
    public int index;
    public int slotQuantity;
    public float delayTime;

    PlayerCondition condition;
    PlayerController controller;

    private void Start()
    {
        condition = GameManager.Instance.Player.condition;
        controller = GameManager.Instance.Player.controller;
    }

    public void Set()
    {
        if (data == null)
        {
            Clear();
            return;
        }
        icon.gameObject.SetActive(true);
        delayIcon.gameObject.SetActive(true);
        icon.sprite = data.icon;
        delayIcon.sprite = icon.sprite;
        itemCount.text = slotQuantity.ToString();
    }

    public void Clear()
    {
        data = null;
        icon.gameObject.SetActive(false);
        delayIcon.gameObject.SetActive(false);
        itemCount.text = string.Empty;
        slotQuantity = 0;
    }

    public void Use()
    {
        if (data.type == ItemType.Consumable)
        {
            UseConsumable();
        }
        else if (data.type == ItemType.Equipment)
        {
            Debug.Log("��� ���� ����");
        }
    }

    IEnumerator TImePlus()
    {
        delayIcon.fillAmount = 0;
        while (delayIcon.fillAmount < 1.0f)
        {
            delayTime += Time.deltaTime;

            if (data != null)
            {
                delayIcon.fillAmount = delayTime / data.delayTime;
            }
            yield return null;
        }
    }

    private void UseConsumable()
    {
        if (delayIcon.fillAmount != 1) return; 

        foreach (ConsumableData consumable in data.consumableData)
        {
            switch (consumable.consumableType)
            {
                case ConsumableType.Hp:
                    condition.Heal(consumable.value);
                    break;
                case ConsumableType.Sp:
                    condition.Restore(consumable.value);
                    break;
                case ConsumableType.SpeedUp:
                    controller.StartCoroutine(controller.AbilityUp(consumable.value, true));
                    break;
                case ConsumableType.JumpUp:
                    controller.StartCoroutine(controller.AbilityUp(consumable.value, false));
                    break;
            }

        }
        slotQuantity--;
        if (slotQuantity <= 0)
        {
            Clear();
        }
        else
        {
            delayTime = 0;
            GameManager.Instance.Player.StartCo(TImePlus());
            Set();
        }
    }

    // ������Ʈ�� ��Ŭ�� �� Use()�޼��� ����
    public void OnPointerClick(PointerEventData eventData)
    {
        if (data == null) return;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Use();
        }
        else if(eventData.button == PointerEventData.InputButton.Middle)
        {
            UICursor uiCursor = GameManager.Instance.Player.ItemInfoObject;
            uiCursor.transform.position = eventData.position;
            uiCursor.UIUpdate(data);
        }
    }

    // �巡�� ����
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ����");
        // ������ ���� �÷��̾����� ����
        GameManager.Instance.Player.currentData = this.data;
        GameManager.Instance.Player.dataQuantity = slotQuantity;
    }

    // �巡�� ������ ��
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("�巡�� ��");
        this.data = GameManager.Instance.Player.currentData;
        this.slotQuantity = GameManager.Instance.Player.dataQuantity;
        Set();
    }

    // �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        // �ش� ������ �������� ��ġ�� ���콺 ��ġ�� �����ϰ�

    }

    // �̵��� ������ ����
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("������ ���");
        // �÷��̾��� currentData�� �ִ��� Ȯ��
        if (GameManager.Instance.Player.currentData == null) return;

        // �������� ������ ������ Ȯ�� 
        if (GameManager.Instance.Player.currentData == this.data)
        {
            // �� ���� Ȯ��
            if (GameManager.Instance.Player.dataQuantity + this.slotQuantity < this.data.maxCount)
            {
                // ������ �߰��� �� ������ ���� �߰�
                this.slotQuantity += GameManager.Instance.Player.dataQuantity;
                GameManager.Instance.Player.currentData = null;
                GameManager.Instance.Player.dataQuantity = 0;
            }
        }
        // ����� ��ҿ� �����Ͱ� ���ٸ�
        else if (data == null)
        {
            data = GameManager.Instance.Player.currentData;
            slotQuantity = GameManager.Instance.Player.dataQuantity;
            GameManager.Instance.Player.currentData = null;
            GameManager.Instance.Player.dataQuantity = 0;
        }
        // �������� ������ �ٸ��� ��ġ ����
        else
        {
            ItemData cloneData = data;
            int cloneInt = slotQuantity;
            data = GameManager.Instance.Player.currentData;
            slotQuantity = GameManager.Instance.Player.dataQuantity;

            GameManager.Instance.Player.currentData = cloneData;
            GameManager.Instance.Player.dataQuantity = cloneInt;
        }
        Set();
    }
}
