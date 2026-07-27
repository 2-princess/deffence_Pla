using System.Collections.Generic;
using UnityEngine;

public class GaiaArea : MonoBehaviour
{
    private GaiaSkill gaiaSkill;
    private List<EnermyController> enermyList = new List<EnermyController>();

    void Awake()
    {
        gaiaSkill = GetComponentInParent<GaiaSkill>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermyList.Add(enermy);
            enermy.SlowEnermy(gaiaSkill.speedSlow);
            enermy.ArmorDown(gaiaSkill.armorDown);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermyList.Remove(enermy);
            enermy.SlowReturn();
            enermy.ArmorReturn();
        }
    }

    // 장판이 중간에 꺼졋을때
    void OnDisable()
    {
        foreach (EnermyController enermy in enermyList)
        {
            enermy.SlowReturn();
            enermy.ArmorReturn();
        }
    }

}
