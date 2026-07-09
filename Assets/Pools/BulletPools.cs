using System.Collections.Generic;

using UnityEngine;

public class BulletPools : MonoBehaviour
{
    public static BulletPools Instance;
    public List<BulletController> bullets = new List<BulletController>();
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
            bullet = Instantiate(bullet, transform.position, Quaternion.identity, transform);
            BulletController controller = bullet.GetComponent<BulletController>();
            bullets.Add(controller);
            bullets[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public BulletController GetBullet(Transform chaTransform)
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (!bullets[i].gameObject.activeInHierarchy)
            {
                bullets[i].transform.position = chaTransform.position;
                bullets[i].gameObject.SetActive(true);
                return bullets[i];
            }
        }
        return null;
    }
}
