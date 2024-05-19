using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
   public int count;
   [SerializeField]private TextMeshProUGUI countText;
   public void ResetCell()
   {
       countText.text=count.ToString();
   }
}
