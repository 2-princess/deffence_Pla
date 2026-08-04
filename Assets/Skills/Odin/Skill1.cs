using Unity.VisualScripting;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public OdinSkill odinSkill;
    public Transform startPoint;
    public Transform endPoint;
    private float moveSpeed = 15f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermy.TakeDamage(odinSkill.skillDamge);
        }
    }
    void OnEnable()
    {
        transform.position = startPoint.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, moveSpeed * Time.deltaTime);
        if (transform.position == endPoint.position)
        {
            odinSkill.returnSkill();
        }
    }
}
