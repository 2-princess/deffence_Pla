using System.Collections.Generic;
using UnityEngine;

public class EnermyManger : MonoBehaviour
{
    public static EnermyManger Instance;
    public Transform movePoint;
    public List<GameObject> bossList;

    void Awake()
    {
        Instance = this;
    }

    public void SponMonster(int lv)
    {
        EnermyController enermy = EnermyPools.Instance.GetEnermy(lv);
        enermy.transform.position = movePoint.GetChild(0).transform.position;
        enermy.Init(movePoint);
    }
    public void BossSpon(int level)
    {
        GameObject boss = Instantiate(bossList[level]);
        EnermyController controller = boss.GetComponent<EnermyController>();
        controller.Init(movePoint);
    }
}
