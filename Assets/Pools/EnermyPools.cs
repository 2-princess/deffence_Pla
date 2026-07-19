using System.Collections.Generic;
using UnityEngine;

public class EnermyPools : MonoBehaviour
{
    public static EnermyPools Instance;
    public List<Queue<EnermyController>> enermies = new List<Queue<EnermyController>>();
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
            Queue<EnermyController> currentPool = new Queue<EnermyController>();
            for (int j = 0; j < 10; j++)
            {
                GameObject monster = Instantiate(type[i], transform.position, Quaternion.identity, transform);
                monster.SetActive(false);
                EnermyController controller = monster.GetComponent<EnermyController>();
                currentPool.Enqueue(controller);
            }
            enermies.Add(currentPool);
        }
    }
    public EnermyController GetEnermy(int lv)
    {
        if (enermies[lv].Count > 0)
        {
            EnermyController enermy = enermies[lv].Dequeue();
            enermy.gameObject.SetActive(true);
            return enermy;
        }
        else
        {
            GameObject monster = Instantiate(type[lv], transform.position, Quaternion.identity, transform);
            EnermyController enermy = monster.GetComponent<EnermyController>();
            return enermy;
        }
    }

    public void ReturnEnermy(EnermyController enermy)
    {
        int lv = enermy.lv;
        enermy.gameObject.SetActive(false);
        enermies[lv].Enqueue(enermy);
    }
}
