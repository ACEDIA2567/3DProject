using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private Player player;
    public  Player Player
    {
        get { return player; }
        set { player = value; }
    }

    // ���� Ŭ���� Ȯ��
    public bool fireCheck = false;
    public bool stoneSOS = false;
    public DayNightCycle dayNightCycle;
    public SpawnManger spawnManger;


    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public void EndingCheck()
    {
        // ��ںҰ� SOS���� ��� ��ġ �ߴٸ�
        if(fireCheck && stoneSOS)
        { 
            dayNightCycle.EndingStart();
        }
    }
}
