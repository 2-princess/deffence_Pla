using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManger : MonoBehaviour
{
    public static BuildManger Instance;
    public List<GameObject> currentTower;
    public List<GameObject> currentTower_Lv2;
    [SerializeField] private LayerMask clickLayer;
    public List<CharacterController> aliveCha = new List<CharacterController>();

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        ClickBtn();
    }

    // 합성
    public void MergeCha(CharacterController selectCha)
    {
        CharacterStatus chaStatus = selectCha.GetComponent<CharacterStatus>();
        for (int i = 0; i < aliveCha.Count; i++)
        {
            if (selectCha == aliveCha[i]) continue; // 자기랑 같으면 패스,
            if (selectCha.name == aliveCha[i].name) // 먼저 이름같은지검사
            {
                CharacterStatus aliveStatus = aliveCha[i].GetComponent<CharacterStatus>();
                if (aliveStatus.chaName == chaStatus.chaName) // 안의 스테이터스 검사
                {
                    int rand = Random.Range(0, currentTower.Count);
                    Transform pos = selectCha.transform;
                    Destroy(aliveCha[i].gameObject);
                    Destroy(selectCha.gameObject);
                    GameObject chaCon = Instantiate(currentTower_Lv2[rand], pos.position, Quaternion.identity); // 캐릭생성
                    aliveCha.Add(chaCon.GetComponent<CharacterController>()); // 컨형태로 저장

                    UIManger.Instance.UIClear();
                    aliveCha.Remove(aliveCha[i]);
                }
            }
        }
    }

    void ClickBtn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Onclick();
        }
    }

    // 플레이어케릭생성
    void Onclick()
    {
        // 마우스 클릭
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // UI겹치는거 방지
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Physics.Raycast(ray, out hit, 100f, clickLayer))
        {
            UIManger.Instance.UIClear(); // UI지우고
            // Debug.Log("클릭한 오브젝트 : " + hit.collider.name);

            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
            // 생성 타일을 클릭햇을경우
            if (hit.collider.CompareTag("Create") && tileInfo.isBuild != true && GameManager.Instance.money >= 30)
            {
                Vector3 buildPos = hit.collider.transform.position;
                buildPos.y = 1;
                int rand = Random.Range(0, currentTower.Count);
                GameObject chaCon = Instantiate(currentTower[rand], buildPos, Quaternion.identity); // 캐릭생성
                aliveCha.Add(chaCon.GetComponent<CharacterController>()); // 현재 생성되있는걸 컨트롤러형태로 저장
                tileInfo.isBuild = true; // 타일 중복소환방지
                GameManager.Instance.Gold(-30); // 캐릭생성 가격
            }
            // 플레이어 클릭
            if (hit.collider.CompareTag("Player"))
            {
                UIManger.Instance.OnPlus(hit.collider.transform, hit.collider.gameObject);
                // Debug.Log(hit.collider.gameObject);
            }
        }
    }

}
