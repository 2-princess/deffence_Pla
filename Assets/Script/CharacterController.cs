using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterStatus characterStatus;
    private Transform target;
    private GameObject bullet;

    private float currentTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        characterStatus = GetComponent<CharacterStatus>();
    }

    void Start()
    {

    }
    void Update()
    {
        currentTime += Time.deltaTime;
        if (target != null && currentTime >= characterStatus.attackSpeed)
        {
            bullet = BulletPools.Instance.GetBullet();
            Attack();
        }

    }

    // Range에서 받은 적 좌표로 보내기위해
    public void Aim(Transform enermy)
    {
        target = enermy;
        currentTime = characterStatus.attackSpeed;
    }
    // 불렛컨에게 전달
    void Attack()
    {
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.Target(target, characterStatus.attack, characterStatus.bulletSpeed);
        currentTime = 0;
    }
    public void AttackEnd()
    {
        target = null;
    }


}
