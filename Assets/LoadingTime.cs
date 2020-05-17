using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTime : MonoBehaviour
{
    private int Score = 0;
    public Text ScoreText = null;

    void Update()
    {
        ScoreText.text = "누른 횟수 : " + Score.ToString();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) Score++; // Fire1 = 좌클릭, Fire2 = 우클릭
    }
}