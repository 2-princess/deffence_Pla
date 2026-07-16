using TMPro;
using UnityEngine;
using UnityEngine.UI;
// 클릭하고 어떤걸 보여줄지 나눌려고
public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    public GameObject plusBtn;
    public GameObject status;
    public TMP_Text statusText;
    public RectTransform plusButton;

    [SerializeField] private RectTransform gmUI;
    private GameObject cha;

    public void OnButtonClick()
    {
        // Debug.Log(cha.name);
        CharacterController selectCha = cha.GetComponent<CharacterController>();
        BuildManger.Instance.MergeCha(selectCha);
    }

    void Awake()
    {
        Instance = this;
        plusBtn.SetActive(false);
    }

    // 합성버튼
    public void OnPlus(Transform tr, GameObject gameObject)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(tr.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gmUI, screenPosition, Camera.main, out Vector2 localPosition);
        plusButton.anchoredPosition = localPosition + new Vector2(0f, 80f);
        plusButton.gameObject.SetActive(true);
        cha = gameObject;
        // Debug.Log(gameObject.name);

    }

    // 케릭 상태창
    public void StatusOn(GameObject gameObject)
    {
        CharacterController chaCon = gameObject.GetComponent<CharacterController>();
        status.SetActive(true);
        statusText.text =
        "Lv : " + chaCon.characterStatus.level + "\n" +
        "Name : " + chaCon.characterStatus.chaName + "\n" +
        "Attack : " + chaCon.characterStatus.attack + "\n" +
        "Attack_Speed : " + chaCon.characterStatus.attackSpeed;
    }

    public void UIClear()
    {
        status.SetActive(false);
        plusBtn.SetActive(false);
    }
}
