using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedKey : MonoBehaviour, IA_Interactable
{ 
    [SerializeField]private GameObject CellarlockeScreen,BackButton;
    [SerializeField]private List<Cell> cells=new List<Cell>();
    [SerializeField]private string Password;
    [SerializeField]private Teleporter.TeleportType teleportType;

    public void Interact()
    {
        CellarlockeScreen.SetActive(true);
        BackButton.SetActive(true);

        CameraMovement.Instance.zoomActive=true;
    }
    public void IncreaseInput(Cell getCell)
    {
        if (getCell.count>=9)
        {
            getCell.count=0;
        }
        else
        {
            getCell.count++;
        }
        getCell.ResetCell();
    }
    public void GetInput()
    {
       string getpasw="";
       foreach (Cell item in cells)
       {
         getpasw+=item.count.ToString();
         item.count=0;
         item.ResetCell();
       }
       Debug.Log(getpasw);
       if(getpasw==Password)
       {
        AudioManager.Instance.PlaySFX("correct");
          SceneManager.LoadScene(teleportType.ToString());
       }
       else
       {
          AudioManager.Instance.PlaySFX("wrong");
       }
    }
}
