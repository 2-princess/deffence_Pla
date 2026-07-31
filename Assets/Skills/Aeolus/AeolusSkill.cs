using System.Collections.Generic;
using UnityEngine;

public class AeolusSkill : BaseSkill
{
    public List<CharacterController> aliveCha = new List<CharacterController>();
    public float attackSpeedUP = 10;
    public float slowEnermy = 10;

    void Start()
    {
        aliveCha = BuildManger.Instance.aliveCha;
        BuffManger.Instance.AeolusAdd(this);
        foreach (CharacterController cha in aliveCha)
        {
            OnAttackSpeed(cha);
        }
    }

    void OnDisable()
    {
        BuffManger.Instance.AeolusRemove(this);
        foreach (CharacterController cha in aliveCha)
        {
            OffAttackSpeed(cha);
        }
    }

    public override void UseSkill(Transform owner, Transform target)
    {
        aliveCha = BuildManger.Instance.aliveCha;
    }

    // 공속증가
    public void OnAttackSpeed(CharacterController cha)
    {
        cha.characterStatus.attackSpeed /= (attackSpeedUP + 100) / 100;
    }
    // 공속복구
    public void OffAttackSpeed(CharacterController cha)
    {
        cha.characterStatus.attackSpeed *= (attackSpeedUP + 100) / 100;
    }

}
