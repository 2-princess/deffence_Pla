using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
    protected CharacterStatus status;

    protected virtual void Awake()
    {
        status = GetComponent<CharacterStatus>();
    }
    public abstract void UseSkill(
        Transform owner,
        Transform target
    );
}
