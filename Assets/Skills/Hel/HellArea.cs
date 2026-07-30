using System.Collections.Generic;
using UnityEngine;

public class HellArea : MonoBehaviour
{
    HashSet<EnermyController> enermys = new HashSet<EnermyController>();
    public float currentTime = 0;
    public float duration = 3;

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > duration)
        {
            currentTime = 0;
            CloseArea();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermys.Add(enermy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermys.Remove(enermy);
        }
    }

    public void AreaDamage(float damage)
    {
        foreach (EnermyController enermy in enermys)
        {
            // Debug.Log("퍼딜 : " + enermy.enermyStatus.hp * damage / 100);
            enermy.TakeDamage(enermy.enermyStatus.hp * damage / 100);
        }
    }

    public void CloseArea()
    {
        gameObject.SetActive(false);
    }
}
