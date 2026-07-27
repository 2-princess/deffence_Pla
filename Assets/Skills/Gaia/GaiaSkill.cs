using UnityEngine;

public class GaiaSkill : BaseSkill
{
    public GameObject area1;
    public GameObject area2;
    public float skillTime = 0;
    public int skillStep = 0;
    public float speedSlow = 0.2f;
    public float armorDown = 10f;

    public override void UseSkill(Transform owner, Transform target)
    {
    }
    void Start()
    {
        OnArea1();
    }

    // Update is called once per frame
    void Update()
    {
        skillTime += Time.deltaTime;
        if (skillTime < 3) return;
        skillStep++;
        skillTime = 0f;
        switch (skillStep)
        {
            case 1:
                OffArea();
                break;
            case 2:
                OnArea2();
                break;
            case 3:
                OffArea();
                break;
            case 4:
                OnArea1();
                skillStep = 0;
                break;
        }
    }
    void OnArea1()
    {
        area1.SetActive(true);
        area2.SetActive(false);
    }

    void OnArea2()
    {
        area2.SetActive(true);
        area1.SetActive(false);
    }
    void OffArea()
    {
        area1.SetActive(false);
        area2.SetActive(false);
    }
}
