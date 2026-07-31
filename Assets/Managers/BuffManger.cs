using System.Collections.Generic;
using UnityEngine;

public class BuffManger : MonoBehaviour
{
    public static BuffManger Instance;
    private List<ApollonSkill> apollons = new List<ApollonSkill>();
    private List<AeolusSkill> aeoluss = new List<AeolusSkill>();

    void Awake()
    {
        Instance = this;
    }

    public void ApplyBuff(CharacterController cha)
    {
        if (apollons.Count > 0)
        {
            foreach (ApollonSkill apollon in apollons)
            {
                apollon.ApollonBuff(cha);
            }
        }
        if (aeoluss.Count > 0)
        {
            foreach (AeolusSkill aeolus in aeoluss)
            {
                aeolus.OnAttackSpeed(cha);
            }
        }
    }
    
    //! 아폴론
    public void ApollonAdd(ApollonSkill apollonSkill)
    {
        apollons.Add(apollonSkill);
    }
    public void ApollonRemove(ApollonSkill apollonSkill)
    {
        apollons.Remove(apollonSkill);
    }

    //! 아이올로스
    public void AeolusAdd(AeolusSkill aeolusSkill)
    {
        aeoluss.Add(aeolusSkill);
    }
    public void AeolusRemove(AeolusSkill aeolusSkill)
    {
        aeoluss.Remove(aeolusSkill);
    }

}
