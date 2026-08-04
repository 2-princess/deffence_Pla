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
                GameObject cha = Instantiate(currentTowers[0].towers[rand], buildPos, Quaternion.identity, transform); // 캐릭생성
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
