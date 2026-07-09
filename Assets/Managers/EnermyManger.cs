using UnityEngine;

public class EnermyManger : MonoBehaviour
{
    public static EnermyManger Instance;
    public Transform movePoint;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void SponMonster(int lv)
    {
        EnermyController enermy = EnermyPools.Instance.GetEnermy(lv);
        enermy.transform.position = movePoint.GetChild(0).transform.position;
        enermy.Init(movePoint);
    }
}
