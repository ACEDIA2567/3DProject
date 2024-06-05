using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildViewerObject : MonoBehaviour
{
    private MeshRenderer MeshRenderer;

    void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        MeshRenderer.material.color = Color.green;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Resource"))
        {
            MeshRenderer.material.color = Color.red;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Resource"))
        {
            MeshRenderer.material.color = Color.green;
        }
    }
}
