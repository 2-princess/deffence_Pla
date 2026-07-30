using UnityEngine;

public class HelSkill : BaseSkill
{
    public HellArea hellArea;
    private float collTime = 5;
    private float skillTime = 0;
    private float skillDamage = 3;
    
    public override void UseSkill(Transform owner, Transform target)
    {
        hellArea.gameObject.transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        skillTime += Time.deltaTime;
        if (skillTime > collTime)
        {
            hellArea.gameObject.SetActive(true);
            hellArea.AreaDamage(skillDamage);
        }

    }
}
