using UnityEngine;

public class ThorSkill : BaseSkill
{
    public HamerShoot hamerShoot;
    public GorundSkill groundSkill;

    private Transform enermy;
    private float hammerSpeed = 8;
    private bool hammerOn = true;
    public HammerState hammerState;
    public enum HammerState
    {
        MoveToEnemy,
        Stop,
        Return
    }
    public float groundDamage = 600;
    public float hammerDamage = 3000;

    public override void UseSkill(Transform owner, Transform target)
    {
        if (!hammerOn) return;
        enermy = target;
        hammerState = HammerState.MoveToEnemy;
        hamerShoot.StartHammer();
        hammerOn = false;
        Debug.Log("UseSKill : " + target);
    }

    // Update is called once per frame
    void Update()
    {
        // 타겟을 맞추고 돌아올때
        if (hammerState == HammerState.Return)
        {
            hamerShoot.transform.position = Vector3.MoveTowards(hamerShoot.transform.position, transform.position, hammerSpeed * Time.deltaTime);
            if (Vector3.Distance(hamerShoot.transform.position, transform.position) < 0.01f)
            {
                Debug.Log("해머 회수");
                hammerOn = true;
                hammerState = HammerState.Stop;
                enermy = null;
                hamerShoot.StartHammer();
            }
        }
        if (enermy == null) return;

        // 적이 죽었을경우
        if (!enermy.gameObject.activeInHierarchy)
        {
            Debug.Log("ThorSkill : targetNull -> ReturnHamer");
            hammerState = HammerState.Return;
            enermy = null;
        }

        // 타겟 공격상태일경우
        if (hammerState == HammerState.MoveToEnemy)
        {
            hamerShoot.transform.position = Vector3.MoveTowards(hamerShoot.transform.position, enermy.position, hammerSpeed * Time.deltaTime);
            if (Vector3.Distance(hamerShoot.transform.position, enermy.position) < 0.01f)
            {
                Debug.Log("해머스톱실행");
                StopHammer();
            }
        }

    }

    public void StartHammer()
    {
        hammerOn = true;
        hammerState = HammerState.MoveToEnemy;
    }

    private void StopHammer()
    {
        hammerOn = false;
        hammerState = HammerState.Stop;
        hamerShoot.StopHammer();

        Instantiate(groundSkill.gameObject, hamerShoot.transform.position, Quaternion.Euler(45f, 0f, 0f), transform);
        hammerState = HammerState.Return;
        enermy = null;
    }

}
