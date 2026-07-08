using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int stage = 1;
    private float count = 10;
    public int money = 300;
    private int killPoint;
    public Text stageCount;
    public Text gold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StageGold();
    }


    void StageGold()
    {
        count -= Time.deltaTime;
        if (count < 1)
        {
            stage++;
            count = 10;
        }
        stageCount.text = stage.ToString();
        gold.text = "GOLD: " + money.ToString();
    }
}
