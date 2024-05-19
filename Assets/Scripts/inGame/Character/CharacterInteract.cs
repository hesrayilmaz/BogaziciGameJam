using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{   



    [Header("For Check")]
    [SerializeField]private Transform characterRoot;
    [SerializeField]private float interactRange;
    [SerializeField]private LayerMask interactLayer;
    private bool coolDown;

    void FixedUpdate()
    {
        if(GetComponent<CharacterMovement>().stop==false)
       InteractArea();
    }
    void InteractArea()
    {
         if (Input.GetKey(KeyCode.E)&&coolDown==false)
        {
            Collider2D hit=Functions.Instance.CheckCircle(characterRoot,interactRange,interactLayer);
           if(hit)
           {
                 coolDown=true;
                 Invoke(nameof(ResetCoolDown),0.3f);
                AudioManager.Instance.PlaySFX("interaction1");
               IA_Interactable interactHit=hit.GetComponent<IA_Interactable>();
               interactHit.Interact();
           }
        }
    }
    void ResetCoolDown()
    {
         coolDown=false;
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(characterRoot.position,interactRange);
    }
}
