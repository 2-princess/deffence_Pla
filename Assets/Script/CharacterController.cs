using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public List<GameObject> bullets = new List<GameObject>();
    public CharacterStatus characterStatus;
    private Transform target;
    private float currentTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        characterStatus = GetComponent<CharacterStatus>();
    }
    void Start()
    {
        // 총알 풀링
        for (int i = 0; i < 50; i++)
        {
            bullets.Add(Instantiate(bulletPrefab));
            bullets[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        Attack();
    }

    // Range에서 받은 적 좌표로 보내기위해
    public void AttackStart(Transform enermy)
    {
        target = enermy;
        currentTime += characterStatus.attackSpeed;
    }
    public void AttackEnd()
    {
        target = null;
    }

    // 불렛컨트롤러에 보내기위해
    void Attack()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy && currentTime > characterStatus.attackSpeed)
            {
                bullets[i].transform.position = transform.position;

                BulletController bullet = bullets[i].GetComponent<BulletController>();
                bullet.Target(target, characterStatus.attack, characterStatus.bulletSpeed);
                currentTime = 0;
                bullets[i].SetActive(true);
            }
        }
    }
}
