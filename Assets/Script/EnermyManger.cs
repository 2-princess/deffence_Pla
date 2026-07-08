using System.Collections.Generic;
using UnityEngine;

public class EnermyManger : MonoBehaviour
{

    public List<GameObject> enermyPool = new List<GameObject>();
    public GameObject enermy;
    public GameManager gM;
    public Transform wayPoints;
    private float responTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            enermy = Instantiate(enermy);
            enermyPool.Add(enermy);
            enermyPool[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        responTime += Time.deltaTime;
        if (responTime > 2)
        {
            SpawnEnermy();
            responTime = 0;
        }
    }

    void SpawnEnermy()
    {
        for (int i = 0; i < enermyPool.Count; i++)
        {
            if (!enermyPool[i].activeInHierarchy)
            {
                enermyPool[i].transform.position = wayPoints.GetChild(0).position;
                EnermyController enemyController = enermyPool[i].GetComponent<EnermyController>();
                enemyController.Init(wayPoints);

                enermyPool[i].SetActive(true);
                return;
            }
        }
    }


}
