using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class surfaceDetectionAndRotation : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objectToPlace;
    public Camera arCamera;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject placedObject; // Reference to the instantiated object
    private bool isObjectPlaced = false; // Flag to track if the object is already placed

    private void Update()
    {
        // If object is already placed, handle drag and move
        if (isObjectPlaced && Input.GetMouseButton(0))
        {
            // Get mouse position in screen space
            Vector3 mousePosition = Input.mousePosition;

            // Convert screen space to world space
            Ray ray = arCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // If ray hits the object, move the object to the hit point
                placedObject.transform.position = hit.point;
            }
        }
        else // Otherwise, handle object placement
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButton(0))
            {
                if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    // Rotate the instantiated object by 90 degrees around the Y-axis
                    Quaternion rotation = Quaternion.Euler(0, 90, 0);

                    // Instantiate the object with the rotated pose
                    placedObject = Instantiate(objectToPlace, hitPose.position, rotation * hitPose.rotation);
                    isObjectPlaced = true; // Set the flag to true
                }
            }
        }
    }
}