using System.Collections;
using UnityEngine;

public enum BossSkill
{
    speedUp, // 중간 스피드 업
    hpPlus, // 체력회복
}

public class BossSkillController : MonoBehaviour
{
    float currentTime = 0;
    public BossSkill skillType;
    private EnermyController enermyController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enermyController = GetComponent<EnermyController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > 2.5)
        {
            switch (skillType)
            {
                case BossSkill.speedUp:
                    // Debug.Log("보스 스킬 발동");
                    StartCoroutine(SpeedUp(enermyController));
                    break;
                case BossSkill.hpPlus:
                    break;

            }
            currentTime = 0;
        }
    }
    IEnumerator SpeedUp(EnermyController enermyController)
    {
        float baseSpeed = enermyController.currentSpeed;
        enermyController.currentSpeed += 2f;
        yield return new WaitForSeconds(0.8f);
        enermyController.currentSpeed = baseSpeed;
    }
}
