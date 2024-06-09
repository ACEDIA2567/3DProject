using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public GameObject applePrefab;
    public int quantityPerHit = 1;
    public int capacy;
    public Gather type;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal, Gather type)
    {
        if (this.type != type) return;

        for(int i = 0; i < quantityPerHit; i++)
        {
            if (capacy <= 0)
            {
                Destroy(gameObject);
                break;
            }
            capacy -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }
    }

    private void OnMouseDown()
    {
        DropApple();
    }
    void DropApple()
    {
        Vector3 applePosition = transform.position + new Vector3(0, 1, 0);
        Instantiate(applePrefab, applePosition, Quaternion.identity);
    }
}
