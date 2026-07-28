using UnityEngine;

public class JordStone : MonoBehaviour
{
    [SerializeField] private Transform wayPoints;
    private Vector3 targetPosition;
    public float currentSpeed = 3;
    private int current = 0;

    void OnEnable()
    {
        current = 0;
        Vector3 position = wayPoints.GetChild(0).position;
        transform.position = new Vector3(position.x, transform.position.y, position.z);
    }
    // Update is called once per frame
    void Update()
    {
        if (wayPoints == null) return;
        GoStone();
    }

    public void GoStone()
    {
        if (current < wayPoints.childCount)
        {
            Vector3 point = wayPoints.GetChild(current).position;
            targetPosition = new Vector3(point.x, transform.position.y, point.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                current++;
            }
            if (current >= wayPoints.childCount)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void StoneSpeed(float speed)
    {
        currentSpeed = speed;

    }
}
