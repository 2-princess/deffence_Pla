using UnityEngine;

public class HamerShoot : MonoBehaviour
{
    public ThorSkill thorSkill;
    public Transform hammerImg;
    public bool rotate = true;
    private float rotateSpeed = -800f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            EnermyController enermy = other.GetComponent<EnermyController>();
            enermy.TakeDamage(thorSkill.hammerDamage);
            Debug.Log(" 토르 : 망치딜줌");
        }
    }


    // Update is called once per frame
    void Update()
    {
        RotateHammer();
    }

    // 망치 돌리기
    public void RotateHammer()
    {
        if (rotate) hammerImg.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
    // 망치가는중
    public void StartHammer()
    {
        rotate = true;
    }
    // 망치 정지
    public void StopHammer()
    {
        rotate = false;
        hammerImg.transform.rotation = Quaternion.Euler(0f, 0f, -100f);
    }
}
