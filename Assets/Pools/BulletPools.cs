using System.Collections.Generic;

using UnityEngine;
public enum attackType
{
    lv1,
    lv2,
    lv3
}
public enum specialAttackType // 레벨4부터는 다른특수공격 넣을려고
{ }

public class BulletPools : MonoBehaviour
{
    public static BulletPools Instance;
    public List<List<BulletController>> bulletHam = new List<List<BulletController>>();
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
            List<BulletController> currentBullet = new List<BulletController>();
            for (int j = 0; j < 50; j++)
            {
                GameObject bullet = Instantiate(bulletType[i], transform.position, Quaternion.identity, transform);
                BulletController controller = bullet.GetComponent<BulletController>();
                currentBullet.Add(controller);
                currentBullet[j].gameObject.SetActive(false);
            }
            bulletHam.Add(currentBullet); // 함에 넣기
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public BulletController GetBullet(Transform chaTransform, attackType attackType)
    {
        int type = (int)attackType;
        List<BulletController> bullets = bulletHam[type];
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
