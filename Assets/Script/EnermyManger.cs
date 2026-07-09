using UnityEngine;

public class EnermyManger : MonoBehaviour
{
    public static EnermyManger Instance;
    private float responTime = 0;
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
        responTime += Time.deltaTime;
        if (responTime > 2)
        {
            GameObject enermy = EnermyPools.Instance.SpawnEnermy();
            EnermyController enermyController = enermy.GetComponent<EnermyController>();
            enermy.transform.position = movePoint.GetChild(0).transform.position;
            enermyController.Init(movePoint);
            responTime = 0;
        }
    }




}
