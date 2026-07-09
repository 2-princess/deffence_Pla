using UnityEngine;

public class WaveManger : MonoBehaviour
{
    public static WaveManger Instance;
    public int sponCount = 0; // 적이 몇마리 생성되었는지
    public int wave = 1; // 현웨이브
    private float currentTime = 0;
    private float sponDelay = 0;
    private bool isSpon = true;

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
            EnermyManger.Instance.SponMonster(wave);
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
        }
    }

}
