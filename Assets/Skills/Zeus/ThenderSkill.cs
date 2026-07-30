using System.Collections.Generic;
using UnityEngine;

public class ThenderSkill : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ZeusSkill zeusSkill;
    private EnermyController enermy;
    private float damage;


    private void OnEnable()
    {
        animator.Play("ZeusThunder", 0, 0);
    }

    public void SetTarget(Transform target, float skillDamage)
    {
        enermy = target.GetComponent<EnermyController>();
        damage = skillDamage;
    }

    public void TargetDamage()
    {
        if (enermy != null && enermy.gameObject.activeInHierarchy)
        {
            enermy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("ZeusSkill : 적이 없음");
        }
        zeusSkill.StackPlus();
        zeusSkill.ThenderReturn(this);
    }
}
