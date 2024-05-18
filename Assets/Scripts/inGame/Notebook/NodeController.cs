using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    [SerializeField]private List<Node> nodes = new List<Node>();
    public static NodeController Instance;
    private void Awake() {
        if (Instance==null)
        {
            Instance=this;
        }
    }

    private void Start() {
        RefreshNode();
    }
    void RefreshNode()
    {
       foreach (Node item in nodes)
       {
          if (PlayerPrefs.GetString(item.myName)=="1")
          item.myLine.SetActive(false);
           
       }
    }
    public void SolveNode(Item getItem)
    {
       foreach (Node item in nodes)
       {
           if(getItem==item.myItem)
           {
             item.SaveSolve();
           }
       }
       RefreshNode();
    }
}
