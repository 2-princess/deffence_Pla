using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    public CharacterController characterController;
    public List<Collider> targets = new List<Collider>();

    void Awake()
    {
        // 케릭터컨트롤러의 AttackStart 사용위해
        characterController = GetComponentInParent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            targets.Add(other);
            // Debug.Log(transform.parent.gameObject.name + " : 적이 들어옴");
            if (targets.Count == 1) characterController.Aim(targets[0].transform); // 타겟이 하나뿐이면 AIM실행
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            targets.Remove(other);
            // Debug.Log("적이 나감");
            if (targets.Count > 0) characterController.Aim(targets[0].transform); // 타겟이 나가도 남아있으면,
        }
    }

    public void EnermyDead(Collider collider)
    {
        Debug.Log("죽었을때 넘겨받는거" + collider);
        targets.Remove(collider);
        if (targets.Count > 0) characterController.Aim(targets[0].transform);
    }
}
