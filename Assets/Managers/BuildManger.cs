using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManger : MonoBehaviour
{
    public static BuildManger Instance;
    [SerializeField] private LayerMask clickLayer;
    [SerializeField] private GameObject rangeView;
    public List<TowerList> currentTowers;
    public List<CharacterController> aliveCha = new List<CharacterController>();

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        ClickBtn();
    }

    // 클래스를 보여주기위해
    [System.Serializable]
    public class TowerList
    {
        public List<GameObject> towers;
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
                    int rand = Random.Range(0, currentTowers[1].towers.Count);
                    Transform pos = selectCha.transform;
                    aliveCha[i].currentTile.isBuild = false; // 원래있던 타일 활성화
                    GameObject targetCha = aliveCha[i].gameObject;
                    aliveCha.Remove(aliveCha[i]); // 살아있던 케릭리스트제거
                    aliveCha.Remove(selectCha); // 선택케릭리스트제거
                    Destroy(targetCha); // 살아있던 오브젝트 제거
                    Destroy(selectCha.gameObject);  // 선택 케릭제거
                    GameObject chaCon = Instantiate(currentTowers[1].towers[rand], pos.position, Quaternion.identity); // 레벨2 캐릭생성
                    UIManger.Instance.UIClear();

                    aliveCha.Add(chaCon.GetComponent<CharacterController>()); // 컨형태로 저장
                    return;
                }
                else Debug.Log("같은게 없음");
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
        UIManger.Instance.UIClear(); // UI지우고
        rangeView.SetActive(false); // 사거리끄고
        if (Physics.Raycast(ray, out hit, 100f, clickLayer))
        {
            // Debug.Log("클릭한 오브젝트 : " + hit.collider.name);
            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
            // 생성 타일을 클릭햇을경우
            if (hit.collider.CompareTag("Create") && tileInfo.isBuild != true && GameManager.Instance.money >= 30)
            {
                Vector3 buildPos = hit.collider.transform.position;
                buildPos.y = 1;
                int rand = Random.Range(0, currentTowers[0].towers.Count);
                tileInfo.isBuild = true; // 타일 중복소환방지
                GameObject cha = Instantiate(currentTowers[0].towers[rand], buildPos, Quaternion.identity); // 캐릭생성
                CharacterController chaCon = cha.GetComponent<CharacterController>(); // 캐릭의 컨트롤러
                chaCon.currentTile = tileInfo;
                aliveCha.Add(chaCon); // 현재 생성되있는걸 컨트롤러형태로 저장
                GameManager.Instance.Gold(-30); // 캐릭생성 가격
            }
            // 플레이어 클릭
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("클릭됨");
                CharacterController controller = hit.collider.gameObject.GetComponent<CharacterController>();
                ShowRange(controller);
                UIManger.Instance.OnPlus(hit.collider.transform, hit.collider.gameObject);
                UIManger.Instance.StatusOn(hit.collider.gameObject);
                // Debug.Log(hit.collider.gameObject);
            }
        }
    }

    // 사거리 표시
    void ShowRange(CharacterController character)
    {
        RangeController rangeController = character.GetComponentInChildren<RangeController>();
        Debug.Log(rangeController);
        float radius = rangeController.GetRange();
        float diameter = radius * 2;
        rangeView.transform.position = character.transform.position;
        rangeView.transform.localScale = new Vector3(diameter, diameter, 1f);
        rangeView.SetActive(true);
    }

    // 테스트용에서 생성
    public void ChaCreate(Transform transform, int lv)
    {
        Vector3 buildPos = transform.position;
        buildPos.y = 1;
        int rand = Random.Range(0, currentTowers[lv].towers.Count);
        GameObject cha = Instantiate(currentTowers[lv].towers[rand], buildPos, Quaternion.identity); // 캐릭생성
        CharacterController chaCon = cha.GetComponent<CharacterController>(); // 캐릭의 컨트롤러
        aliveCha.Add(chaCon); // 현재 생성되있는걸 컨트롤러형태로 저장
    }

}
