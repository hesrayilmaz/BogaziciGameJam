using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    [SerializeField] private GameObject notebook;

    public void OpenNotebook()
    {
        notebook.SetActive(true);
    }

    public void CloseNotebook()
    {
        notebook.SetActive(false);
    }
}
