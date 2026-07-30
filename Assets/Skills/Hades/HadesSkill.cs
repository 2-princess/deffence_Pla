using UnityEngine;
using UnityEngine.UI;

public class HadesSkill : BaseSkill
{
    public HadesStack hadesStack;
    public Canvas burstButton;
    private float currentTime = 0;
    private float currentStackTime = 0.3f;
    public float skillDamage = 200;
    private int stack = 0;

    public override void UseSkill(Transform owner, Transform target)
    {
        Debug.Log(status.attack);
        BulletController bullet = BulletPools.Instance.GetBullet(transform, status.attackType);
        bullet.Target(target, skillDamage, status.bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > currentStackTime)
        {
            stack = hadesStack.StackPlus();
            currentTime = 0;
        }
    }

    public void Burst()
    {
        skillDamage = status.attack * stack / 100;
        stack = 0;
        burstButton.gameObject.SetActive(false);
        hadesStack.gameObject.SetActive(false);
        // Debug.Log(skillDamage);
    }
}
