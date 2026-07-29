using System.Collections.Generic;
using UnityEngine;

public class ApollonSkill : BaseSkill
{
    public List<CharacterController> aliveCha = new List<CharacterController>();
    public float criticalPer = 10;
    public float criticalDamage = 10;

    public override void UseSkill(Transform owner, Transform target)
    {
        // throw new System.NotImplementedException();
    }
    void OnEnable()
    {
        aliveCha = BuildManger.Instance.aliveCha;
        BuffManger.Instance.ApollonAdd(this);

        foreach (CharacterController cha in aliveCha)
        {
            CriticalUp(cha);
            CriticalDamageUp(cha);
        }
    }

    void OnDisable()
    {
        BuffManger.Instance.ApollonRemove(this);
        foreach (CharacterController cha in aliveCha)
        {
            CriticalReset(cha);
            CriticalDamageReset(cha);
        }
    }

    // 캐릭하나 버프
    public void ApollonBuff(CharacterController cha)
    {
        CriticalUp(cha);
        CriticalDamageUp(cha);
    }
    // 캐릭하나 버프없애기
    public void ApollonBuffOff(CharacterController cha)
    {
        CriticalReset(cha);
        CriticalDamageReset(cha);
    }

    // 크리확률 증가
    void CriticalUp(CharacterController cha)
    {
        cha.characterStatus.criticalPer += criticalPer;
    }
    // 크리확률 리셋
    void CriticalReset(CharacterController cha)
    {
        cha.characterStatus.criticalPer -= criticalPer;
    }
    // 크리 데미지 증가
    void CriticalDamageUp(CharacterController cha)
    {
        cha.characterStatus.criticalDamage += criticalDamage;
    }
    // 크리 데미지 리셋
    void CriticalDamageReset(CharacterController cha)
    {
        cha.characterStatus.criticalDamage -= criticalDamage;
    }
}
