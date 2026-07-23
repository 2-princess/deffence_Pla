using System;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int addGoldAmount = 1000;
    [SerializeField] private int testWave = 1; // 웨이브변경
    [SerializeField] private int monsterLv = 0; // 몬스터스폰 레벨
    [SerializeField] private int chaLv = 0; // 케릭 스폰 레벨
    [SerializeField] private Queue<Transform> tiles = new Queue<Transform>();   // 생성위치 타일
    [SerializeField] private int chaSpon = 5; // 한번에 몇캐릭 생성

    void Start()
    {
        GameObject create = GameObject.Find("Create");

        foreach (Transform tile in create.transform)
        {
            if (tile.CompareTag("Create"))
            {
                // Debug.Log("타일 들어옴" + tile.name);
                tiles.Enqueue(tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoneyPlus(); //! 0번키 입력시 골드추가
        Wave(); //! 1번키 입력시 웨이브이동
        ChaSpon(); //! 2번키 입력시 chaSpon만큼 레벨 캐릭터생성
    }

    void MoneyPlus()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GameManager.Instance.Gold(addGoldAmount);
        }
    }

    void Wave()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.StageCount(testWave);
            ClearEnemy();
            WaveManger.Instance.SetWave(testWave, monsterLv);
        }
    }
    void ClearEnemy()
    {
        EnermyController[] enemies = FindObjectsByType<EnermyController>(FindObjectsSortMode.None);

        foreach (EnermyController enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    void ChaSpon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < chaSpon; i++)
            {
                BuildManger.Instance.ChaCreate(tiles.Dequeue().transform, chaLv);
            }
        }
    }
}
