using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public Transform[] spawnPoint; // 스폰 위치
    public GameObject bear; // 스폰 객체
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


        // 스폰 위치를 4 중에 1개를 선택해서 그 위치에 스폰해야함
        Instantiate(bear, spawnPoint[Random.Range(0, spawnPoint.Length)].position, Quaternion.identity);

        

    }
}

