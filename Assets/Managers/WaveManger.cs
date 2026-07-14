using UnityEngine;

public class WaveManger : MonoBehaviour
{
    public static WaveManger Instance;
    public int sponCount = 0; // 적이 몇마리 생성되었는지
    private int wave = 1; // 현웨이브
    private float currentTime = 0;
    private float sponDelay = 0;
    private bool isSpon = true;
    private int level = 0; // 잇다가 단계

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpon == true) currentTime += Time.deltaTime;
        else
        {
            Delay();
            sponDelay += Time.deltaTime;
        }
        Spon();
        Wave();
    }

    void Spon()
    {
        if (currentTime > 2)
        {
            sponCount++;
            EnermyManger.Instance.SponMonster(0); // 일단 0레벨 몬스터
            currentTime = 0;
        }
    }
    void Wave()
    {
        if (sponCount >= 10)
        {
            isSpon = false;
            sponCount = 0;
        }
    }
    void Delay()
    {
        GameManager.Instance.TimerStart(6 - sponDelay);
        if (sponDelay > 6)
        {
            wave++;
            GameManager.Instance.StageCount(wave);
            GameManager.Instance.delayTime.text = "";
            isSpon = true;
            if (wave % 5 == 0) // 보스 소환
            {
                EnermyManger.Instance.BossSpon(0); // 보스 많아지면 List
            }

            if (wave == 2)  // 단계별 몬스터많아지면 wave%10 
            {
                level++;
            }
            sponDelay = 0;
        }
    }

}
