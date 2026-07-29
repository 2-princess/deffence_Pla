using UnityEngine;

public class BaldurSkill : BaseSkill
{
    [SerializeField] private BaldurRaser laser;
    [SerializeField] public float RaserDamage = 10;
    [SerializeField] public float RaserSecond = 0.2f;
    [SerializeField] public int stack = 0; // 스텍증가에 따른 공격력증가 추가
    public float currentTime = 0;

    public override void UseSkill(Transform owner, Transform target)
    {
        AimLaser(target);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > RaserSecond)
        {
            laser.RaserDamage(10);
            currentTime = 0;
        }
    }

    public void AimLaser(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    }
}
