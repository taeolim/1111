using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{ 

    public Text timer;
    public float time;
    private void Awake()
    {
    }

    private void Update() { 
        if (time > 0)
            time -= Time.deltaTime;

        if (time < 0)
         Destroy(timer);
   


        timer.text = Mathf.Ceil(time).ToString();


    }



    }
