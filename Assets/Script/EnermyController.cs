using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    public EnermyStatus enermyStatus;
    private Animator animator;
    public Transform characterVisual;
    int current;
    public float currentHp;
    public float currentSpeed;
    public float currentAttack;
    public int currentGold;
    private Transform wayPoints;

    void Awake()
    {
        enermyStatus = GetComponent<EnermyStatus>();
        animator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (wayPoints == null) return;
        GoWay();
    }

    public void Init(Transform wayPosition)
    {
        wayPoints = wayPosition;
        current = 1;
        currentHp = enermyStatus.hp;
        currentSpeed = enermyStatus.speed;
        currentGold = enermyStatus.money;
        currentAttack = enermyStatus.attack;
        characterVisual.localScale = new Vector3(1, 1, 1);
    }

    public void GoWay()
    {
        Vector3 targetPosition = wayPoints.GetChild(current).position;
        Vector3 direction = targetPosition - transform.position;
        // 왼쪽오른쪽
        if (direction.x > 0) characterVisual.localScale = new Vector3(-1, 1, 1);
        else new Vector3(1, 1, 1);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
        animator.SetBool("1_Move", true);

        if (Vector3.Distance(transform.position, wayPoints.GetChild(current).position) < 0.1f)
        {
            current++;
            if (current >= wayPoints.childCount)
            {
                gameObject.SetActive(false);
                currentHp = enermyStatus.hp;
                GameManager.Instance.userHp -= currentAttack;
                GameManager.Instance.Life();
                return;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GameManager.Instance.Gold(currentGold);
            gameObject.SetActive(false);
            currentHp = enermyStatus.hp;
        }
    }
}
