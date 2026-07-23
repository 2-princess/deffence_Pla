using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    public abstract void UseSkill(
        Transform owner,
        Transform target
    );
}
