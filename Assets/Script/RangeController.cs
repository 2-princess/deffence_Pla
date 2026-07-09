using UnityEngine;

public class RangeController : MonoBehaviour
{
    public CharacterController characterController;

    void Awake()
    {
        // 케릭터컨트롤러의 AttackStart 사용위해
        characterController = GetComponentInParent<CharacterController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enermy"))
        {
            characterController.Aim(collision.transform);
            // Debug.Log(transform.parent.gameObject.name + " : 적이 들어옴");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enermy"))
        {
            characterController.AttackEnd();
            // Debug.Log("적이 나감");
        }
    }
}
