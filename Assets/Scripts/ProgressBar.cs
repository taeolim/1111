using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour


{

    public Scrollbar loadingBar;





    // Update is called once per frame
    void Update()
    {
        
        loadingBar.size += Time.deltaTime * 0.1f;





        if (loadingBar.size == 1) 
        {
            SceneManager.LoadScene(2);
        }

    }


}
