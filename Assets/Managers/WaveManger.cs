using UnityEngine;

public class WaveManger : MonoBehaviour
{
    public static WaveManger Instance;
    public int sponCount = 0; // 적이 몇마리 생성되었는지
    private int wave = 1; // 현웨이브
    private float currentTime = 0;
    private bool isSpon = true;


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
        currentTime += Time.deltaTime;
        Spon();
        Wave();
    }

    void Spon()
    {
        if (currentTime > 2)
        {
            EnermyManger.Instance.SponMonster(sponCount);
            currentTime = 0;
        }
    }
    void Wave()
    {
        if (sponCount > 10)
        {
            wave++;
            GameManager.Instance.StageCount(wave);
            sponCount = 0;
        }
    }

}
