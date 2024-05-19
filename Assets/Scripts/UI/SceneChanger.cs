using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Teleporter.TeleportType newxtScene;
    public void NewScene()
    {
        AudioManager.Instance.ChangeScene(newxtScene.ToString());
        SceneManager.LoadScene(newxtScene.ToString());
    }
}
