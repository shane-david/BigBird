using UnityEngine;
using System.Collections; 
using UnityEngine.UI; 

public class CameraManager : MonoBehaviour
{
    public Camera mainCam; 
    public float zoomSize = 2f; 
    public float smoothSpeed = 5f;

    private float defaultSize;
    private Vector3 defaultPosition;
    private float targetSize;
    private Vector3 targetPosition;

    void Start() {
        defaultSize = mainCam.orthographicSize;
        defaultPosition = mainCam.transform.position;
        targetSize = defaultSize;
        targetPosition = defaultPosition;
    }

    void Update() {
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, targetSize, Time.deltaTime * smoothSpeed);
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, targetPosition, Time.deltaTime * smoothSpeed);
    }

   
    public void ZoomToTarget(Transform target) {
        targetSize = zoomSize;
        targetPosition = new Vector3(target.position.x, target.position.y, defaultPosition.z);
    }

    
    public void ResetZoom() {
        targetSize = defaultSize;
        targetPosition = defaultPosition;
    }
}