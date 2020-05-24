using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<UIManager>();
            return _Instance;
        }
    }
    private static UIManager _Instance;


    public GameObject unitAreaPos;
    public GameObject unitUIPrefab;


    // Start is called before the first frame update
    void Start()
    {
        SetUnitUI();
    }

    private void SetUnitUI()
    {
        Vector3 offset = Vector3.zero;
        Vector3 gap = Vector3.right * 10f;

        foreach(var unit in UnitManager.Instance.units)
        {
            var obj = Instantiate(unitUIPrefab, unitAreaPos.transform);
            var image = obj.GetComponent<Image>();
            image.sprite = unit.uiImage;
            obj.transform.localPosition = Vector3.zero + offset;

            var rectTransform = image.GetComponent<RectTransform>();
            offset += Vector3.right * rectTransform.rect.width + gap;

            var script = obj.GetComponent<UIUnitSelection>();
            script.unitData = unit;
        }
    }
}
