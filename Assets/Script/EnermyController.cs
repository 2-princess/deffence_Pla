using System.Collections.Generic;
using UnityEngine;

public class EnermyController : MonoBehaviour
{
    // public List<GameObject> enermys; < 적종류추가
    public GameObject enermy;
    public EnermyStatus enermyStatus;
    int current = 0;
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
    }
    void GoWay()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints.GetChild(current).position, enermyStatus.speed * Time.deltaTime);
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
        enermyStatus.hp -= damage;
        if (enermyStatus.hp < 0)
        {
            enermy.SetActive(false);
        }
    }
}
