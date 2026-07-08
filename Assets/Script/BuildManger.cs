using System.Collections.Generic;
using UnityEngine;

public class BuildManger : MonoBehaviour
{
    public static BuildManger Instance;
    public List<GameObject> currentTower;
    public EnermyStatus enermyStatus;

    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        ClickBtn();
    }

    void ClickBtn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Onclick();
        }
    }

    void Onclick()
    {
        // 마우스 클릭
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Debug.Log("클릭한 오브젝트 : " + hit.collider.name);
            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
            if (hit.collider.CompareTag("BuildTile") && tileInfo.isBuild != true)
            {
                Vector3 buildPos = hit.collider.transform.position;
                buildPos.y = 1;
                int rand = Random.Range(0, currentTower.Count);
                Instantiate(currentTower[rand], buildPos, Quaternion.identity);
                tileInfo.isBuild = true;
            }
        }
    }

}
