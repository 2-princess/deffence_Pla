
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bullet;
    private Transform target;
    private float damage;
    private float bulletSpeed; // 투사체속도

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enermy"))
        {
            // 데미지주기위해 EnermyController호출
            EnermyController enermyController = collision.GetComponent<EnermyController>();
            enermyController.TakeDamage(damage);
            bullet.SetActive(false);
            // Debug.Log(collision.name);
        }
    }

    public void Target(Transform targetTing, float damage, float bulletSpeed)
    {
        target = targetTing;
        this.damage = damage;
        this.bulletSpeed = bulletSpeed;
    }

    public void MoveShoot()
    {
        Vector3 targetPos = target.position;
        // 적 y좌표랑 케릭터y좌표가 달라서 고민중
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bulletSpeed * Time.deltaTime);
        // Debug.Log(Vector3.Distance(transform.position, target.position));
    }

    void Update()
    {
        if (target != null)
        {
            MoveShoot();
        }
        // 적이 중간에 사라지면 처리
        if (target == null || !target.gameObject.activeInHierarchy) bullet.SetActive(false);
    }
}
