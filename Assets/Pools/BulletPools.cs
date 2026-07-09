using System.Collections.Generic;
using UnityEngine;

public class BulletPools : MonoBehaviour
{
    public static BulletPools Instance;
    public List<GameObject> bullets = new List<GameObject>();
    public GameObject bullet;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 총알 풀링
        for (int i = 0; i < 50; i++)
        {
            bullets.Add(Instantiate(bullet, transform.position, Quaternion.identity, transform));
            bullets[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject GetBullet()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].transform.position = transform.position;
                bullets[i].SetActive(true);
                return bullets[i];
                // BulletController bullet = bullets[i].GetComponent<BulletController>();
                // bullet.Target(target, characterStatus.attack, characterStatus.bulletSpeed);
                // currentTime = 0;
                
            }
        }
        return null;
    }
}
