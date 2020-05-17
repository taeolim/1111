using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading1 : MonoBehaviour
{
    public Scrollbar loadingBar;

    private void Start()

    {

        StartCoroutine(LoadScene());
    }



    IEnumerator LoadScene()
    {
        
        var asyncOption = SceneManager.LoadSceneAsync(2);
        asyncOption.allowSceneActivation = false;

        while (asyncOption.progress < 0.9f)
        {
            loadingBar.size = asyncOption.progress;
            yield return null;
        }
        asyncOption.allowSceneActivation = true;
    }
}
