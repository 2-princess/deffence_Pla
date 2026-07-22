using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int addGoldAmount = 1000;
    [SerializeField] private int testWave = 1;
    [SerializeField] private int lv = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoneyPlus();
        Wave();

    }

    void MoneyPlus()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GameManager.Instance.Gold(addGoldAmount);
        }
    }

    void Wave()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.StageCount(testWave);
            ClearEnemy();
            WaveManger.Instance.SetWave(testWave, lv);
        }
    }
    public void ClearEnemy()
    {
        EnermyController[] enemies = FindObjectsByType<EnermyController>(FindObjectsSortMode.None);

        foreach (EnermyController enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

}
