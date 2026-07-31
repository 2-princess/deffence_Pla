using System.Collections.Generic;
using UnityEngine;

public class GorundSkill : MonoBehaviour
{
    private HashSet<EnermyController> targets = new HashSet<EnermyController>();
    private float currentTime = 0;
    private float damageCollTime = 0.2f;
    private float duration = 0;
    private float durationTime = 3;
    public ThorSkill thorSkill;

    void Start()
    {
        thorSkill = GetComponentInParent<ThorSkill>();
        transform.localRotation = Quaternion.Euler(45, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController target = other.GetComponent<EnermyController>();
            targets.Add(target);
        }
    }
    void Update()
    {
        currentTime += Time.deltaTime;
        duration += Time.deltaTime;
        if (currentTime > damageCollTime)
        {
            foreach (EnermyController target in targets)
            {
                GroundDamage(target);
            }
            currentTime = 0;
        }
        if (duration > durationTime)
        {
            Destroy(gameObject);
        }

    }

    void GroundDamage(EnermyController target)
    {
        target.TakeDamage(thorSkill.groundDamage);
    }
}
