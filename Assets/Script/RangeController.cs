using UnityEngine;

public class RangeController : MonoBehaviour
{
    public CharacterController characterController;

    void Awake()
    {
        // 케릭터컨트롤러의 AttackStart 사용위해
        characterController = GetComponentInParent<CharacterController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            characterController.Aim(other.transform);
            // Debug.Log(transform.parent.gameObject.name + " : 적이 들어옴");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            characterController.AttackEnd();
            // Debug.Log("적이 나감");
        }
    }

}
