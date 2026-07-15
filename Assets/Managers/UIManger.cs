using UnityEngine;
// 클릭하고 어떤걸 보여줄지 나눌려고
public class UIManger : MonoBehaviour
{
    public GameObject plusBtn;
    public RectTransform plusButton;
    public static UIManger Instance;
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

    public void UIClear()
    {
        plusBtn.SetActive(false);
    }
}
