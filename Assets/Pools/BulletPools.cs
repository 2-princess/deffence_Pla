using System.Collections.Generic;

using UnityEngine;
public enum attackType
{
    lv1,
    lv2,
    lv3,
    lv4
}
public enum specialAttackType // 레벨4부터는 다른특수공격 넣을려고
{ }

public class BulletPools : MonoBehaviour
{
    public static BulletPools Instance;
    public List<Queue<BulletController>> bulletHam = new List<Queue<BulletController>>();
    public List<GameObject> bulletType = new List<GameObject>();


    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 총알 풀링 
        for (int i = 0; i < bulletType.Count; i++)
        {
            Queue<BulletController> currentBullet = new Queue<BulletController>();
            for (int j = 0; j < 5; j++)
            {
                GameObject bullet = Instantiate(bulletType[i], transform.position, Quaternion.identity, transform);
                BulletController controller = bullet.GetComponent<BulletController>();
                bullet.SetActive(false);
                currentBullet.Enqueue(controller);

            }
            bulletHam.Add(currentBullet); // 함에 넣기
        }
    }

    public BulletController GetBullet(Transform chaTransform, attackType attackType)
    {
        int type = (int)attackType;
        if (bulletHam[type].Count > 0)
        {
            BulletController bullet = bulletHam[type].Dequeue();
            bullet.transform.position = chaTransform.position;
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(bulletType[type], transform.position, Quaternion.identity, transform);
            BulletController controller = bullet.GetComponent<BulletController>();
            bullet.SetActive(true);
            bullet.transform.position = chaTransform.position;
            return controller;
        }
    }

    public void ReturnBullet(BulletController bullet)
    {
        int lv = bullet.lv;
        bullet.gameObject.SetActive(false);
        bulletHam[lv].Enqueue(bullet);
    }
}
