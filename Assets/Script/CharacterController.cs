using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public TileInfo currentTile;
    public Transform target;
    private float currentTime = 0;
    public BaseSkill skill;
    public CharacterStatus characterStatus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        BuffManger.Instance.ApplyApollonBuff(this);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        // 공격속도
        if (target != null && currentTime >= characterStatus.attackSpeed)
        {
            // Debug.Log("캐릭 어택스피드 : " + characterStatus.attackSpeed);
            skill.UseSkill(transform, target);
            currentTime = 0;
        }
    }

    // Range에서 받은 적 좌표로 보내기위해
    public void Aim(Transform enermy)
    {
        target = enermy;
    }

}
