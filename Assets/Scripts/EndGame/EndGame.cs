using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public static EndGame Instance;
    private void Awake() {
        if(Instance==null)
        Instance=this;
        else
        Destroy(gameObject);
    }
    public void ResetGame()
    {
      PlayerPrefs.DeleteAll();

    }
}
