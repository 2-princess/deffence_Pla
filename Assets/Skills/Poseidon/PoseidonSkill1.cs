using System.Collections.Generic;
using UnityEngine;

public class PoseidonSkill1 : MonoBehaviour
{
    public PoseidonSkill poseidonSkill;
    private List<EnermyController> enermys = new List<EnermyController>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermy.SlowEnermy(poseidonSkill.skill1Slow);
            enermys.Add(enermy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermy.SlowReturn();
            enermys.Remove(enermy);
        }
    }
    void OnEnable()
    {
        Vector3 pos = transform.position;
        pos.y = 0.01f;
        transform.position = pos;
    }
    void OnDisable()
    {
        foreach (EnermyController enermy in enermys)
        {
            enermy.SlowReturn();
        }
    }

}
