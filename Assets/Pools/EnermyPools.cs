using System.Collections.Generic;
using UnityEngine;

public class EnermyPools : MonoBehaviour
{
    public static EnermyPools Instance;
    public GameObject enermy;
    public List<EnermyController> enermyPool = new List<EnermyController>();
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            // 에너미를 컨트롤러로 사용하기위해
            enermy = Instantiate(enermy, transform.position, Quaternion.identity, transform);
            EnermyController controller = enermy.AddComponent<EnermyController>();
            enermyPool.Add(controller);
            enermyPool[i].gameObject.SetActive(false);
        }
    }
    public EnermyController SpawnEnermy()
    {
        for (int i = 0; i < enermyPool.Count; i++)
        {
            if (!enermyPool[i].gameObject.activeInHierarchy)
            {
                enermyPool[i].gameObject.SetActive(true);
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
