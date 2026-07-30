using System.Collections.Generic;
using UnityEngine;

public class ZeusSkill : BaseSkill
{
    [SerializeField] private RangeController rangeController;
    private Queue<ThenderSkill> thenderQue = new Queue<ThenderSkill>();
    public ThenderSkill thenderSkill;
    public int ThenderCount = 2;
    public float thenderDamage = 300;

    public override void UseSkill(Transform owner, Transform target)
    {
        if (thenderQue.Count == 0 || rangeController.targets.Count == 0)
        {
            return;
        }
        // 랜덤의 적을 때리기위해
        int randInt = Random.Range(0, rangeController.targets.Count);
        Transform enermy = rangeController.targets[randInt].transform;

        // 적이 활성화되있으면
        if (enermy.gameObject.activeInHierarchy)
        {
            ThenderSkill thender = thenderQue.Dequeue(); // 번개갯수를 제한하기위해
            thender.SetTarget(enermy, thenderDamage);
            Transform pos = enermy.transform;
            thender.transform.position = new Vector3(pos.position.x, pos.position.y + 2.5f, pos.position.z);
            thender.gameObject.SetActive(true);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < ThenderCount; i++)
        {
            ThenderSkill thender = Instantiate(thenderSkill, transform);
            thender.gameObject.SetActive(false);
            thenderQue.Enqueue(thender);
        }
    }

    // 번개회수
    public void ThenderReturn(ThenderSkill thenderSkill)
    {
        thenderSkill.gameObject.SetActive(false);
        thenderQue.Enqueue(thenderSkill);
    }
}
