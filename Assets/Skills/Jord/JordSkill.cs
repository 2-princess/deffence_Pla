using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JordSkill : BaseSkill
{
    public List<GameObject> rockSkill = new List<GameObject>();
    public JordStone jordStone;
    public float skillTime = 0;
    public float skill2Time = 0;
    public float skillCoolTime = 3;
    public float skill2CoolTime = 5;
    public float stoneSpeed = 3;
    private Transform currentOwner;
    private Transform currentTarget;

    public override void UseSkill(Transform owner, Transform target)
    {
        if (target == null)
        {
            Debug.Log("JordSkill Target No");
            return;
        }
        currentOwner = owner;
        currentTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        skillTime += Time.deltaTime;
        skill2Time += Time.deltaTime;
        if (skillTime > skillCoolTime && currentTarget != null)
        {
            StartCoroutine(RockSkillOn());
            skillTime = 0;
        }
        if (skill2Time > skill2CoolTime)
        {
            StoneOn();
            skill2Time = 0;
        }

    }

    IEnumerator RockSkillOn()
    {
        Vector3 direction = currentTarget.position - currentOwner.position;
        direction.y = 0f;
        direction.Normalize(); // 거리로 계산하려고

        for (int i = 0; i < rockSkill.Count; i++)
        {
            Vector3 rockPosition = currentOwner.position + direction * (i + 1);
            rockSkill[i].transform.position = rockPosition;
            JordRock rock = rockSkill[i].GetComponent<JordRock>();
            rock.Attack();
            rockSkill[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);
        RockOff();
    }

    void RockOff()
    {
        foreach (GameObject rock in rockSkill)
        {
            rock.SetActive(false);
        }
    }

    void StoneOn()
    {
        jordStone.StoneSpeed(stoneSpeed);
        jordStone.gameObject.SetActive(true);
    }
}
