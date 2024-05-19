using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;
    public GameObject Boss;
    private void Awake() {
        if(Instance==null)
        Instance=this;
        else
        Destroy(gameObject);
    }
    private void Start() {
        Refresh();
    }
    public void Refresh()
    {
        if(PlayerPrefs.GetString("Boss")=="1")
        Boss.SetActive(true);
    }
    public void ResetGame()
    {
      PlayerPrefs.DeleteAll();

    }
}
