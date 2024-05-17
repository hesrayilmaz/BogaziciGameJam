using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AC_Book : ActionTemplate,IA_Interactable
{

    public override void Active()
    {
        base.Active();
        Debug.Log("Kitap çalıştı");
    }

    public void Interact()
    {
        //base
        Active();
    }
}
