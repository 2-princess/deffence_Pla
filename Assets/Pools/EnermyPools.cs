using System.Collections.Generic;
using UnityEngine;

public class EnermyPools : MonoBehaviour
{
    public static EnermyPools Instance;
    public List<List<EnermyController>> enermies = new List<List<EnermyController>>();
    public List<GameObject> type;
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < type.Count; i++)
        {
            List<EnermyController> currentPool = new List<EnermyController>();
            for (int j = 0; j < 20; j++)
            {
                GameObject monster = Instantiate(type[i], transform.position, Quaternion.identity, transform);
                monster.SetActive(false);
                EnermyController controller = monster.GetComponent<EnermyController>();
                currentPool.Add(controller);
            }
            enermies.Add(currentPool);
        }
    }
    public EnermyController GetEnermy(int lv)
    {
        List<EnermyController> enermyList = enermies[lv];

        for (int i = 0; i < enermyList.Count; i++)
        {
            // Debug.Log(enermies.Count);
            // Debug.Log(enermies[lv].Count);
            if (!enermies[lv][i].gameObject.activeInHierarchy)
            {
                enermies[lv][i].gameObject.SetActive(true);
                return enermies[lv][i];
            }
        }
        Debug.Log("몬스터를 못찾음");
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
