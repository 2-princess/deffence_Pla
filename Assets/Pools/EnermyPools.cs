using System.Collections.Generic;
using UnityEngine;

public class EnermyPools : MonoBehaviour
{
    public static EnermyPools Instance;
    public GameObject enermy;
    public List<GameObject> enermyPool = new List<GameObject>();
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            enermy = Instantiate(enermy, transform.position, Quaternion.identity, transform);
            enermyPool.Add(enermy);
            enermyPool[i].SetActive(false);
        }
    }
    public GameObject SpawnEnermy()
    {
        for (int i = 0; i < enermyPool.Count; i++)
        {
            if (!enermyPool[i].activeInHierarchy)
            {
                enermyPool[i].SetActive(true);
                return enermyPool[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
