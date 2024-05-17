using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
   public static Functions Instance;
   private void Awake() {
    if (Instance==null)
    {
        Instance=this;
    }
   }


   public Collider2D CheckCircle(Transform checkPosition,float range,LayerMask checkLayer)
   {
       Collider2D[] hit=Physics2D.OverlapCircleAll(checkPosition.position,range,checkLayer);
       foreach (Collider2D item in hit)
       {
     
         return item;
       }
       return null;
   }
}
