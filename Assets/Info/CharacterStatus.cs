using UnityEngine;

[System.Serializable]
public class CharacterStatus : MonoBehaviour
{
    public int level;
    public float attack;
    public float attackSpeed; // 공속
    public float bulletSpeed; // 투사체속도
    public float criticalPer; // 크리확률
    public float criticalDamage; // 크리추가데미지
}
