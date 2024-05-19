using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactionObject;
    public bool Locke=false;

    private void Start()
    {
        interactionObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Locke)
        return;

        if (collision.gameObject.CompareTag("Player"))
        {
            interactionObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(Locke)
        return;
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Locke)
        return;
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionObject.SetActive(true);
        }
    }
}
