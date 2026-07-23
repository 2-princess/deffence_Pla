using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterStatus characterStatus;
    public TileInfo currentTile;
    public Transform target;
    private float currentTime = 0;
    private float attackSpeed = 0;
    [SerializeField] private BaseSkill skill;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        characterStatus = GetComponent<CharacterStatus>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        // 공격속도
        if (target != null && currentTime >= attackSpeed)
        {
            skill.UseSkill(transform, target);
            // BulletController bullet = BulletPools.Instance.GetBullet(transform, characterStatus.attackType);
            // bullet.Target(target, characterStatus.attack, characterStatus.bulletSpeed);
            currentTime = 0;
        }
    }

    // Range에서 받은 적 좌표로 보내기위해
    public void Aim(Transform enermy)
    {
        target = enermy;
        attackSpeed = characterStatus.attackSpeed;
    }

}
