using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
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
        Gold(0);
        StageCount(1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Life()
    {
        hp.text = "HP : " + userHp.ToString();
    }
    public void Gold(int x)
    {
        money += x;
        gold.text = "GOLD: " + money.ToString();
    }
    public void StageCount(int stage)
    {
        stageCount.text = stage.ToString();
    }
}
