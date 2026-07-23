using UnityEngine;

public class NonSkill : BaseSkill
{
    private CharacterStatus status;

    void Awake()
    {
        status = GetComponent<CharacterStatus>();
    }

    public override void UseSkill(Transform owner, Transform target)
    {
        BulletController bullet = BulletPools.Instance.GetBullet(transform, status.attackType);
        bullet.Target(target, status.attack, status.bulletSpeed);
    }
}