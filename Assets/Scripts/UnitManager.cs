using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance
    {
        get
        {
            if (_Instance == null)
                _Instance = FindObjectOfType<UnitManager>();
            return _Instance;
        }
    }
    private static UnitManager _Instance;




    public List<UnitData> units;


}
