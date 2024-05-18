using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookController : MonoBehaviour
{
    [SerializeField] private GameObject notebook;

    [SerializeField] Transform startPointPrefab;
    [SerializeField] Transform endPointPrefab;
    [SerializeField] Transform startPointParent;
    [SerializeField] Transform endPointParent;
    //private LineRenderer lineRenderer;

    [SerializeField] int numberOfLines = 5;

    private List<Transform> startPoints = new List<Transform>(); // Baþlangýç noktalarý listesi
    private List<Transform> endPoints = new List<Transform>();   // Bitiþ noktalarý listesi

    void Start()
    {
        CreateStartAndEndPoints();
        CreateLines();
    }


    void CreateStartAndEndPoints()
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            Transform startPoint = Instantiate(startPointPrefab, startPointParent);
            startPoints.Add(startPoint);
        }

        for (int i = 0; i < numberOfLines; i++)
        {
            Transform endPoint = Instantiate(endPointPrefab, endPointParent);
            endPoints.Add(endPoint);
        }

        // Shuffle end points to create random connections
        Shuffle(endPoints);
    }

    void CreateLines()
    {
        for (int i = 0; i < numberOfLines; i++)
        {
            Debug.Log("Start Point: " + startPoints[i].position);
            Debug.Log("End Point: " + endPoints[i].position);
            LineRenderer lineRenderer = startPoints[i].GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startPoints[i].position);
            lineRenderer.SetPosition(1, endPoints[i].position);
        }
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void OpenNotebook()
    {
        notebook.SetActive(true);
    }

    public void CloseNotebook()
    {
        notebook.SetActive(false);
    }
}
