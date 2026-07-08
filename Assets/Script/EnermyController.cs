using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    // public List<GameObject> enermys; < 적종류추가
    public GameObject enermy;
    public EnermyStatus enermyStatus;
    int current = 0;
    public float currentHp;
    public float currentSpeed;
    private Transform wayPoints;

    // Update is called once per frame
    void Update()
    {
        GoWay();
    }
    public void Init(Transform points)
    {
        wayPoints = points;
        current = 0;
        currentHp = enermyStatus.hp;
        currentSpeed = enermyStatus.speed;

    }
    void GoWay()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints.GetChild(current).position, currentSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPoints.GetChild(current).position) < 0.1f)
        {
            current++;
            if (current >= wayPoints.childCount)
            {
                gameObject.SetActive(false);
                return;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            enermy.SetActive(false);
        }
    }
}
