using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected CharacterStatus status;

    protected virtual void Awake()
    {
        status = GetComponentInParent<CharacterStatus>();
    }
    public abstract void UseSkill(
        Transform owner,
        Transform target
    );
}
