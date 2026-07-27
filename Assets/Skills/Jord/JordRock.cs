using UnityEngine;

public class JordRock : MonoBehaviour
{
    private Vector3 finalPos;
    private float speed = 6;
    private Vector3 originTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalPos, speed * Time.deltaTime);
    }

    public void Attack()
    {
        originTransform = transform.position;
        finalPos = new Vector3(transform.position.x, 1, transform.position.z);
    }
    void OnDisable()
    {
        transform.position = originTransform;
    }

}
