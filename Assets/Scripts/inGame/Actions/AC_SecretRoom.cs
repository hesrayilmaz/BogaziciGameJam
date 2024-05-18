using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_SecretRoom : ActionTemplate
{
    [SerializeField]private float tpSpeed;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
           Invoke(nameof(ShowCase),tpSpeed);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag=="Player")
        {
             CancelInvoke(nameof(ShowCase));
        }
    }
    public override void ShowCase()
    {
        IA_Openable a_Openable=GetComponent<IA_Openable>();
        a_Openable.Open();
    }
}
