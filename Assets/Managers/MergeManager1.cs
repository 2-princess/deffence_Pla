using System.Collections.Generic;
using UnityEngine;
using static BuildManger;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void MergeCha(CharacterController selectCha)
    {
        CharacterStatus chaStatus = selectCha.GetComponent<CharacterStatus>();
        List<CharacterController> aliveCha = BuildManger.Instance.aliveCha;
        for (int i = 0; i < aliveCha.Count; i++)
        {
            if (selectCha == aliveCha[i]) continue; // 자기랑 같으면 패스,
            if (selectCha.name == aliveCha[i].name) // 먼저 이름같은지검사
            {
                CharacterStatus aliveStatus = aliveCha[i].GetComponent<CharacterStatus>();
                if (aliveStatus.chaName == chaStatus.chaName) // 안의 스테이터스 검사
                {
                    List<TowerList> currentTowers = BuildManger.Instance.currentTowers;
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
}
