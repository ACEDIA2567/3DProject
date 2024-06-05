using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCraft : MonoBehaviour
{
    ItemData data;
    GameObject PreviwerObject;

    RaycastHit hitInfo;
    public LayerMask layerMask;
    public int slotIndex;
    bool creaftMode = false;
    new Camera camera;

    private void Start()
    {
        data = null;
        camera = Camera.main;
    }

    public void GetData(ItemData data, int index)
    {
        // 크래프트 모드일 경우 데이터 받지 못하게 함
        if (this.data != null) return;
        PreviwerObject = Instantiate(data.ViewObject);
        slotIndex = index;
        this.data = data;
    }

    private void Update()
    {
        if (data != null)
        {
            ViewerItemUpdate();
        }
    }

    private void ViewerItemUpdate()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 10, layerMask))
        {
            if (hitInfo.transform != null)
            {
                PreviwerObject.transform.position = hitInfo.point;
                if (creaftMode && PreviwerObject.GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    Instantiate(data.dropPrefab, hitInfo.point, Quaternion.identity);
                    data = null;
                    Destroy(PreviwerObject);
                    // 인벤토리의 아이템 삭제
                    GameManager.Instance.Player.inventory.GetSlot(slotIndex).Clear();
                    slotIndex = -1;
                }
            }
        }
        // ESC 누르면 건축 취소
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            data = null;
            Destroy(PreviwerObject);
            slotIndex = -1;
        }
    }

    public void OnBuild(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            creaftMode = true;
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            creaftMode = false;
        }
    }
}
