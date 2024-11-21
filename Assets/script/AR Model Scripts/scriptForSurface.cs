using System.Collections;               // Allows using collections (not needed in this script)
using System.Collections.Generic;  // Allows using lists
using UnityEngine;// Main Unity functions
using UnityEngine.XR.ARFoundation;              // AR Foundation functions (for AR features)
using UnityEngine.XR.ARSubsystems;              // AR-specific types like TrackableType (used for plane detection)

public class scriptforsurface : MonoBehaviour
{
    public ARRaycastManager raycastManager; // Handles detecting surfaces (planes)
    public GameObject objectToPlace; // The 3D object to place on the AR surface
    public Camera arCamera;     // The camera used for AR view

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();  // Stores where the ray hits the AR plane

    private void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);    // Cast a ray from the camera to the point where the mouse is clicked

     // If the left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
            {  
                // Check if the ray hits an AR plane
                Pose hitPose = hits[0].pose;// Get the position of where the plane was hit

                // Calculate the adjusted position for the object  // Set the object's position to where the ray hit the plane
                Vector3 adjustedPosition = hitPose.position;

                // Instantiate the object with the adjusted position and rotation
                Quaternion rotation = Quaternion.Euler(0, 90, 0); // Rotate by 90 degrees around the Y-axis//Quaternion: Used to handle smooth rotations in Unity.
                GameObject instantiatedObject = Instantiate(objectToPlace, adjustedPosition, rotation * hitPose.rotation);

                // Optionally, you can further adjust the position if needed:
                // instantiatedObject.transform.Translate(0, /*Adjustment value*/, 0, Space.World);
            }
        }
    }
}
