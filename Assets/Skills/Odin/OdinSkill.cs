using UnityEngine;

public class OdinSkill : BaseSkill
{
    public Skill1 skill1;
    public float skillDamge = 2000;
    public float skillTime = 0;
    public float skillCoolTime = 4;

    public override void UseSkill(Transform owner, Transform target)
    {

    }

    // Update is called once per frame
    void Update()
    {
        skillTime += Time.deltaTime;
        if (skillTime > skillCoolTime && !skill1.gameObject.activeInHierarchy)
        {
            AttackSkill();
            skillTime = 0;
        }
    }

    void AttackSkill()
    {
        skill1.gameObject.SetActive(true);
    }
    public void returnSkill()
    {
        skill1.gameObject.SetActive(false);
    }
}
