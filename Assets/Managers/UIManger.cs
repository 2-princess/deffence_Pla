using Unity.VisualScripting;
using UnityEngine;
// 클릭하고 어떤걸 보여줄지 나눌려고
public class UIManger : MonoBehaviour
{
    public GameObject plusBtn;
    public RectTransform plusButton;
    public static UIManger Instance;

    public void OnButtonClick()
    {
        Debug.Log("클릭됨");
    }

    void Awake()
    {
        Instance = this;
        plusBtn.SetActive(false);
    }

    // 합성버튼
    public void OnPlus(Transform tr,GameObject gameObject)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(tr.position);
        screenPosition.y += 150f;
        plusButton.position = screenPosition;
        plusBtn.SetActive(true);
        Debug.Log(gameObject.name);
    }

    public void UIClear()
    {
        plusBtn.SetActive(false);
    }
}
