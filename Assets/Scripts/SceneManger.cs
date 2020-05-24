using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
public void SceneClick(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
