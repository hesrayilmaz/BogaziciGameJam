using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactionObject;

    private void Start()
    {
        interactionObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactionObject.SetActive(true);
        }
    }
}
