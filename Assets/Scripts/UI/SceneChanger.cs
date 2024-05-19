using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Teleporter.TeleportType newxtScene;
    public void NewScene()
    {
        SceneManager.LoadScene(newxtScene.ToString());
    }
}
