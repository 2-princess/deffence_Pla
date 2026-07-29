using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaldurRaser : MonoBehaviour
{
    private HashSet<EnermyController> targets = new HashSet<EnermyController>();
    public int stack = 0;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("other : " + other.name);
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponentInParent<EnermyController>();
            targets.Add(enermy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            targets.Remove(enermy);
        }
    }

    // 레이저,적죽이면스텍쌓기
    public void RaserDamage(float damage)
    {
        // Debug.Log(targets.Count);
        foreach (EnermyController enermy in targets)
        {
            if (!enermy.gameObject.activeInHierarchy) return;
            enermy.TakeDamage(damage);
            if (enermy.currentHp < 0)
            {
                stackUp(10);
            }

        }
    }

    void OnDisable()
    {
        targets.Clear();
    }
    public void stackUp(int x)
    {
        stack += x;
    }
}
