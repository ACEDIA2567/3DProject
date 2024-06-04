using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance;
    public LayerMask interactionLayer;
    public LayerMask tentLayer;
    public TextMeshProUGUI interactionText;
    private float rateTime = 0;
    private float checkTime = 0.1f;
    private bool sleepCheck = false;
    private Camera camera;

    private IItemInfo itemInfo;
    private GameObject interactionObject;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - rateTime > checkTime)
        {
            rateTime = Time.time;
            Interaction();
        }
    }

    private void Interaction()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayDistance, interactionLayer))
        {
            // 해당 오브젝트 UI에 나오게
            if (interactionObject == null)
            {
                interactionObject = hit.collider.gameObject;
                itemInfo = hit.collider.GetComponent<IItemInfo>();
                VoidText();
            }
        }
        else if (Physics.Raycast(ray, out hit, rayDistance, tentLayer))
        {
            // 잠 잘 것인지 여부 확인
            sleepCheck = true;
            itemInfo = hit.collider.GetComponent<IItemInfo>();
            VoidText();
        }
        else
        {
            sleepCheck = false;
            interactionObject = null;
            itemInfo = null;
            interactionText.gameObject.SetActive(false);
        }
    }

    private void VoidText()
    {
        interactionText.gameObject.SetActive(true);
        interactionText.text = itemInfo.ItemText();
    }

    public void GetItem(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if(interactionObject != null)
            {
                itemInfo.ItemAdd();
                interactionObject = null;
                itemInfo = null;
                interactionText.gameObject.SetActive(false);
            }
        }
        else if (context.phase == InputActionPhase.Started && sleepCheck)
        {
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.sleepUI.SetActive(true);
            sleepCheck = false;
            itemInfo = null;
        }
    }
}
