using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public Transform[] spawnPoint; // ���� ��ġ
    public GameObject bear; // ���� ��ü
    public GameObject helicopter;
    public Transform[] helicopterSpawnPos;
    public int bearCount = 0;


    void Start()
    {
        GameManager.Instance.spawnManger = this;
      
    }

    public void SpawnHelicopter()
    {
        Transform transform = helicopterSpawnPos[Random.Range(0, helicopterSpawnPos.Length)];
        Instantiate(helicopter, transform.position, Quaternion.identity);
    }
    public void SpawnBear()
    {


        // ���� ��ġ�� 4 �߿� 1���� �����ؼ� �� ��ġ�� �����ؾ���
        Instantiate(bear, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);

        

    }
}
