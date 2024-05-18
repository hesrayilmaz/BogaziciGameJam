using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]private float speed,horSpace,verSpace,zoomValue,zoomSpeed;
    private float currentFar;
    [HideInInspector]public bool zoomActive=false;
    public static CameraMovement Instance;
    private void Awake() {
        if (Instance==null)
         Instance=this;
        else
        Destroy(gameObject);

    }
    private void Start() {
        currentFar=GetComponent<Camera>().orthographicSize;
    }
    private void Update() {
        Move();

        if (zoomActive)
        Zoom();
        else
        ResetZoom();

    }
    void Move()
    {
         Vector3 desiredPosition = Vector3.Lerp(transform.position,
            new Vector3(
            GameManager.Instance.PlayerRef.transform.position.x+horSpace,
            GameManager.Instance.PlayerRef.transform.position.y+verSpace,
            transform.position.z
           
           ), Time.deltaTime * speed);
            transform.position = desiredPosition;
    }
    public void Zoom()
    {
       float newZoom=Mathf.Lerp(GetComponent<Camera>().orthographicSize,zoomValue,Time.deltaTime*zoomSpeed);
       GetComponent<Camera>().orthographicSize=newZoom;
       GameManager.Instance.PlayerRef.GetComponent<CharacterMovement>().stop=true;

    }
    public void ResetZoom()
    {
        if( GetComponent<Camera>().orthographicSize==currentFar)
        return;

        float newZoom=Mathf.Lerp(GetComponent<Camera>().orthographicSize,currentFar,Time.deltaTime*zoomSpeed);
       GetComponent<Camera>().orthographicSize=newZoom;
         GameManager.Instance.PlayerRef.GetComponent<CharacterMovement>().stop=false;
    }
}
