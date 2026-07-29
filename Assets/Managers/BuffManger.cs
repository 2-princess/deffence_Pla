using System.Collections.Generic;
using UnityEngine;

public class BuffManger : MonoBehaviour
{
    public static BuffManger Instance;
    private List<ApollonSkill> apollons = new List<ApollonSkill>();

    void Awake()
    {
        Instance = this;
    }

    public void ApollonAdd(ApollonSkill apollonSkill)
    {
        apollons.Add(apollonSkill);
    }
    public void ApollonRemove(ApollonSkill apollonSkill)
    {
        apollons.Remove(apollonSkill);
    }

    public void ApplyApollonBuff(CharacterController cha)
    {
        if (apollons.Count > 0)
        {
            foreach (ApollonSkill apollon in apollons)
            {
                apollon.ApollonBuff(cha);
            }
        }
    }
}
