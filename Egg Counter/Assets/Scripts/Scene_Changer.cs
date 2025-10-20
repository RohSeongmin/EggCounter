using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    [Header("Target Scene")]
    public string SceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
