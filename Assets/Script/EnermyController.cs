using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    public EnermyStatus enermyStatus;
    int current;
    public float currentHp;
    public float currentSpeed;
    public float currentAttack;
    public int currentGold;
    private Transform wayPoints;

    void Awake()
    {
        enermyStatus = GetComponent<EnermyStatus>();
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
    }

    public void GoWay()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints.GetChild(current).position, currentSpeed * Time.deltaTime);
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
