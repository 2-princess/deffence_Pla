using UnityEngine;

public class KeepGroundY : MonoBehaviour
{
    [SerializeField] private float groundY = 0.01f;

    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.y = groundY;
        transform.position = position;
    }
}
