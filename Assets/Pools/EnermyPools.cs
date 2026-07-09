using System.Collections.Generic;
using UnityEngine;

public class EnermyPools : MonoBehaviour
{
    public static EnermyPools Instance;
    public GameObject enermy;
    public GameObject enermyLv2;
    public List<EnermyController> enermyPool = new List<EnermyController>();
    public List<EnermyController> enermyPoolLv2 = new List<EnermyController>();
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject enermy1 = Instantiate(enermy, transform.position, Quaternion.identity, transform);
            GameObject enermy2 = Instantiate(enermyLv2, transform.position, Quaternion.identity, transform);

            EnermyController controller = enermy1.GetComponent<EnermyController>();
            EnermyController controllerLv2 = enermy2.GetComponent<EnermyController>();

            enermyPool.Add(controller);
            enermyPoolLv2.Add(controllerLv2);

            enermyPool[i].gameObject.SetActive(false);
            enermyPoolLv2[i].gameObject.SetActive(false);
        }
    }
    public EnermyController GetEnermy(int lv)
    {
        List<EnermyController> enermyList;
        if (lv > 1)
        {
            enermyList = enermyPoolLv2;
        }
        else
        {
            enermyList = enermyPool;
        }
        for (int i = 0; i < enermyList.Count; i++)
        {
            if (!enermyList[i].gameObject.activeInHierarchy)
            {
                enermyList[i].gameObject.SetActive(true);
                return enermyList[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
