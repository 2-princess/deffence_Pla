using UnityEngine;

public class HadesSkill : BaseSkill
{
    public HadesStack hadesStack;
    float currentTime = 0;
    float currentStackTime = 0.3f;
    public override void UseSkill(Transform owner, Transform target)
    {
        // throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > currentStackTime)
        {
            hadesStack.StackPlus();
            currentTime = 0;
        }
    }
}
