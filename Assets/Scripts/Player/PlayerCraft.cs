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
    bool creaftMode = false;
    Camera camera;

    private void Start()
    {
        data = null;
        camera = Camera.main;
    }

    public void GetData(ItemData data)
    {
        // ũ����Ʈ ����� ��� ������ ���� ���ϰ� ��
        if (this.data != null) return;
        PreviwerObject = Instantiate(data.ViewObject);
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
                if (creaftMode)
                {
                    Instantiate(data.dropPrefab, hitInfo.point, Quaternion.identity);
                    data = null;
                    PreviwerObject = null;
                }
            }
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
