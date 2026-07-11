using UnityEngine;
// 클릭하고 어떤걸 보여줄지 나눌려고
public class UIManger : MonoBehaviour
{
    public GameObject plusBtn;
    public RectTransform plusButton;

    public static UIManger Instance;

    void Awake()
    {
        Instance = this;
        plusBtn.SetActive(false);
    }

    // 합성버튼
    public void OnPlus(Transform tr)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(tr.position);
        screenPosition.y += 150f;
        plusButton.position = screenPosition;
        plusBtn.SetActive(true);
    }

    public void UIClear()
    {
        plusBtn.SetActive(false);
    }
}
