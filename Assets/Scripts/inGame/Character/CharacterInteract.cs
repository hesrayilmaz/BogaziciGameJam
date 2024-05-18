using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{   



    [Header("For Check")]
    [SerializeField]private Transform characterRoot;
    [SerializeField]private float interactRange;
    [SerializeField]private LayerMask interactLayer;

    void FixedUpdate()
    {
        if(GetComponent<CharacterMovement>().stop==false)
       InteractArea();
    }
    void InteractArea()
    {
         if (Input.GetKey(KeyCode.E))
        {
            Collider2D hit=Functions.Instance.CheckCircle(characterRoot,interactRange,interactLayer);
           if(hit)
           {
               IA_Interactable interactHit=hit.GetComponent<IA_Interactable>();
               interactHit.Interact();
           }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color=Color.blue;
        Gizmos.DrawWireSphere(characterRoot.position,interactRange);
    }
}
