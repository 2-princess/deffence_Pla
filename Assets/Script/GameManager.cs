using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float count = 10;
    private int stage = 1;
    private int killPoint;
    public int money = 300;
    public float userHp = 2000;
    public Text stageCount;
    public Text gold;
    public Text hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Life();
        Gold();
        StageCount();
    }

    // Update is called once per frame
    void Update()
    {
        Window();
    }


    void Window()
    {
        count -= Time.deltaTime;
        if (count < 1)
        {
            stage++;
            StageCount();
            count = 10;
        }
    }

    public void Life()
    {
        hp.text = "HP : " + userHp.ToString();
    }
    public void Gold()
    {
        gold.text = "GOLD: " + money.ToString();
    }
    public void StageCount()
    {
        stageCount.text = stage.ToString();
    }
}
