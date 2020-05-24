using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QueueManager : MonoBehaviour
{
    public GameObject SelectFBX;


    public static QueueManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<QueueManager>();
            return _Instance;
        }
    }
    private static QueueManager _Instance;

    public static UnitQueueData SelectedQueue;

    public List<UnitQueueData> unitQueueDatas;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

            if (hit.collider != null && hit.collider.gameObject != this.gameObject
                && hit.collider.gameObject.layer == LayerMask.NameToLayer("QueueTile"))
            {
                if(SelectedQueue != null)
                {
                    SelectedQueue.OnDeselect();
                }
                var targetScript = hit.collider.GetComponent<QueueTile>();
                if (targetScript.data == SelectedQueue)
                {
                    SelectedQueue = null;
                    return;
                }
                SelectedQueue = targetScript.data;
                SelectedQueue.OnSelect();
            }
        }
    }


    public bool AddUnit(UnitData data)
    {

        var targetTile = unitQueueDatas.FirstOrDefault(t => t.isExist == false);

        if (targetTile == null)
            return false;

        targetTile.unit = data;
        targetTile.isExist = true;
        var obj = Instantiate(data.prefab, targetTile.tile.transform);
        obj.transform.localPosition = Vector3.zero;

        var script = targetTile.tile.GetComponent<QueueTile>();
        script.data = targetTile;
        return true;
    }
}

[System.Serializable]
public class UnitQueueData
{
    public bool isExist;
    public int index;
    [HideInInspector]
    public UnitData unit;
    public GameObject tile;


    public void OnSelect()
    {
        if (index == 0)
            return;

        QueueManager.Instance.SelectFBX.SetActive(true);
        QueueManager.Instance.SelectFBX.transform.position = tile.transform.position;
        Debug.Log($"선택 됨 - 인덱스 : {index}");
    }
    public void OnDeselect()
    {
        if (index == 0)
            return;

        QueueManager.Instance.SelectFBX.SetActive(false);
        Debug.Log($"선택 해제 됨 - 인덱스 : {index}");
    }
}
