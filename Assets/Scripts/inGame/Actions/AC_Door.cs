using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AC_Door : ActionTemplate,IA_Interactable
{

    public override void Active()
    {
        base.Active();
    }

    public void Interact()
    {
        //base

        Active();
    }

    public override void ShowCase()
    {
      base.ShowCase();
      NodeController.Instance.SolveNode(myItem);

    }
}
