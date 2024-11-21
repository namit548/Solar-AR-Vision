// iss script se ham mobile mai objects ke child component hide or unhide kar sakte hai 
//drawback isse ham or object nhi bna sakte (add kar sakte)
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class ArObjectSpawnAndHideComponent : MonoBehaviour// the name of this script in (project - ar core experimental is  ARPlaceAndToggleParts)
{
    public GameObject[] ArModels;////// /////////////////////////////////////
    public TMP_Dropdown ChangeModel;//////////////////////////////////

    /// <summary>
    ///    public GameObject arObjectToSpawn; // The object prefab to spawn
    /// </summary>
    public GameObject placementIndicator; // The indicator for object placement
    public Button toggleButton; // Button to toggle parts visibility(solar panels)
    public Button SunToggleButton; // Button to toggle parts visibility(for sun visiblity)

    private GameObject spawnedObject; // To reference the spawned object
    private Pose placementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;
    private bool partsVisible = true; // To track visibility of "cubebb"

    void Start()
    {
        // Initialize AR Raycast Manager
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();

        // Set up the button listener for toggling specific parts after spawning
        SunToggleButton.onClick.AddListener(SunToggleVisiblilty);
        toggleButton.onClick.AddListener(TogglePartsVisibility);

        ChangeModel.onValueChanged.AddListener(delegate { ARPlaceObject(); });// agar ham delegate nhi use kregai toh dropdownchanged()main(int value karna pdega or parameter dena pdega i.e dropdown.value ki jgh value ==1;)


    }

    void Update()
    {
        // Handle AR-specific object placement using touch input
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }
    }

    void UpdatePlacementPose()
    {
        // Raycast from the center of the screen to detect AR planes
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }


    void ARPlaceObject()
    {
        // Destroy the previous object if it's already spawned
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        // Instantiate based on the dropdown selection
        if (ChangeModel.value == 0)
        {
            spawnedObject = Instantiate(ArModels[0], placementPose.position, placementPose.rotation);
            Debug.Log("Object spawned in AR: " + spawnedObject.name);
        }
        else if (ChangeModel.value == 1)
        {
            spawnedObject = Instantiate(ArModels[1], placementPose.position, placementPose.rotation);
            Debug.Log("Object spawned in AR: " + spawnedObject.name);
        }

    }


    //void ARPlaceObject()
    //{
    //    // Spawn the object at the placement pose
    //    spawnedObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
    //    Debug.Log("Object spawned in AR: " + spawnedObject.name);
    //}

    void UpdatePlacementIndicator()
    {
        // Show the placement indicator only when a valid placement pose is found
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
    /// or hide and unhide components

    void SunToggleVisiblilty()
    {
        if (spawnedObject != null)
        {
            Transform sun = spawnedObject.transform.Find("sun light");
            if (sun != null)
            {
                sun.gameObject.SetActive(partsVisible);

            }
            partsVisible = !partsVisible;
        }
    }

    void TogglePartsVisibility()
    {
        if (spawnedObject != null)
        {
            // Find the child object "cubebb" in the spawned object
            // Transform sun = spawnedObject.transform.Find("sun light");
            Transform panel = spawnedObject.transform.Find("panel");
            Transform panel1 = spawnedObject.transform.Find("panel.001");
            Transform panel2 = spawnedObject.transform.Find("panel2");
            Transform panel3 = spawnedObject.transform.Find("panel2.001");
            Transform panel4 = spawnedObject.transform.Find("panel3");
            Transform panel5 = spawnedObject.transform.Find("panel3.001");
            Transform panel6 = spawnedObject.transform.Find("panel4");
            Transform panel7 = spawnedObject.transform.Find("panel4.001");
            Transform panel8 = spawnedObject.transform.Find("panel5");
            Transform panel9 = spawnedObject.transform.Find("panel5.001");
            Transform panel10 = spawnedObject.transform.Find("panel6");
            Transform panel11 = spawnedObject.transform.Find("panel6.001");


            if (panel != null)
            {
                // Toggle the visibility of the child object "cubebb"

                panel.gameObject.SetActive(partsVisible);
                panel1.gameObject.SetActive(partsVisible);
                panel2.gameObject.SetActive(partsVisible);
                panel3.gameObject.SetActive(partsVisible);
                panel4.gameObject.SetActive(partsVisible);
                panel5.gameObject.SetActive(partsVisible);
                panel6.gameObject.SetActive(partsVisible);
                panel7.gameObject.SetActive(partsVisible);
                panel8.gameObject.SetActive(partsVisible);
                panel9.gameObject.SetActive(partsVisible);
                panel10.gameObject.SetActive(partsVisible);
                panel11.gameObject.SetActive(partsVisible);

                ///Debug.Log("Toggling visibility of: " + cubebb.name + " to " + partsVisible);
            }
            else
            {
                Debug.Log("Child object 'cubebb' not found.");
            }

            // Toggle the state for next press
            partsVisible = !partsVisible;
        }
        else
        {
            Debug.Log("No object spawned yet.");
        }
    }

}













// this script is for pc editor unity use only **need ar model[] to change in code

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.UI;

//public class ARPlaceAndToggleParts : MonoBehaviour
//{
//    public GameObject arObjectToSpawn; // The object prefab to spawn
//    public GameObject placementIndicator; // The indicator for object placement
//    public Button toggleButton; // Button to toggle parts visibility

//    private GameObject spawnedObject; // To reference the spawned object
//    private Pose placementPose;
//    private ARRaycastManager aRRaycastManager;
//    private bool placementPoseIsValid = false;
//    private bool partsVisible = true; // To track visibility of "cubebb"

//    void Start()
//    {
//        // AR-specific setup
//#if UNITY_EDITOR
//        // PC Editor does not need ARRaycastManager
//#else
//        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
//#endif

//        // Set up the button listener for toggling specific parts after spawning
//        toggleButton.onClick.AddListener(TogglePartsVisibility);
//    }

//    void Update()
//    {
//        // For mobile AR use AR raycasting, for PC Editor use mouse click
//#if UNITY_EDITOR
//        HandleEditorPlacement();
//#else
//        HandleARPlacement();
//#endif
//    }

//#if UNITY_EDITOR
//    void HandleEditorPlacement()
//    {
//        // In the editor, simulate AR placement using the mouse
//        UpdatePlacementPoseEditor();

//        if (spawnedObject == null && placementPoseIsValid && Input.GetMouseButtonDown(0))
//        {
//            PlaceObjectEditor();
//        }
//    }

//    void UpdatePlacementPoseEditor()
//    {
//        // Raycast from camera to world point, similar to AR raycast
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;

//        if (Physics.Raycast(ray, out hit))
//        {
//            placementPoseIsValid = true;
//            placementPose = new Pose(hit.point, Quaternion.LookRotation(hit.normal));
//            UpdatePlacementIndicator();
//        }
//        else
//        {
//            placementPoseIsValid = false;
//        }
//    }

//    void PlaceObjectEditor()
//    {
//        // Spawn the object at the placement pose
//        spawnedObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
//        Debug.Log("Object spawned in Editor: " + spawnedObject.name);
//    }
//#endif

//#if !UNITY_EDITOR
//    void HandleARPlacement()
//    {
//        // AR-specific object placement using touch input
//        UpdatePlacementPoseAR();
//        UpdatePlacementIndicator();

//        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            ARPlaceObject();
//        }
//    }

//    void UpdatePlacementPoseAR()
//    {
//        // Raycast from the center of the screen to detect AR planes
//        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
//        var hits = new List<ARRaycastHit>();
//        aRRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

//        placementPoseIsValid = hits.Count > 0;
//        if (placementPoseIsValid)
//        {
//            placementPose = hits[0].pose;
//        }
//    }

//    void ARPlaceObject()
//    {
//        // Spawn the object at the placement pose
//        spawnedObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
//        Debug.Log("Object spawned in AR: " + spawnedObject.name);
//    }
//#endif

//    void UpdatePlacementIndicator()
//    {
//        // Show the placement indicator only when a valid placement pose is found
//        if (spawnedObject == null && placementPoseIsValid)
//        {
//            placementIndicator.SetActive(true);
//            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
//        }
//        else
//        {
//            placementIndicator.SetActive(false);
//        }
//    }

//    void TogglePartsVisibility()
//    {
//        if (spawnedObject != null)
//        {
//            // Find the child object "cubebb" in the spawned object
//            Transform cubebb = spawnedObject.transform.Find("cubebb");

//            if (cubebb != null)
//            {
//                // Toggle the visibility of the child object "cubebb"
//                cubebb.gameObject.SetActive(partsVisible);
//                Debug.Log("Toggling visibility of: " + cubebb.name + " to " + partsVisible);
//            }
//            else
//            {
//                Debug.Log("Child object 'cubebb' not found.");
//            }

//            // Toggle the state for next press
//            partsVisible = !partsVisible;
//        }
//        else
//        {
//            Debug.Log("No object spawned yet.");
//        }
//    }
//}

