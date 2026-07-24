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
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            targets.Remove(other);
            // Debug.Log("적이 나감");
        }
    }

    public void EnermyDead(Collider collider)
    {
        // Debug.Log("죽었을때 넘겨받는거" + collider);
        characterController.target = null;
        targets.Remove(collider);
    }

    void Update()
    {
        targets.RemoveAll(target => target == null || !target.gameObject.activeInHierarchy);
        if (targets.Count > 0)
        {
            characterController.Aim(targets[0].transform);
        }
    }

    // 사거리 반환
    public float GetRange()
    {
        SphereCollider rangeCollider = GetComponent<SphereCollider>();
        return rangeCollider.radius;
    }
}
