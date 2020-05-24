using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUnitSelection : MonoBehaviour
{
    public UnitData unitData;
    

    public void OnClickButton()
    {
        QueueManager.Instance.AddUnit(unitData);
        Destroy(gameObject);
    }
}
