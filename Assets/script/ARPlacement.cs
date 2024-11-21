using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{

    public GameObject UIArrows;

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;//store rotation and postion of object where it is placed in real world
    private ARRaycastManager aRRaycastManager;//help in detecting plane by casting rays from camera

    private bool placementPoseIsValid = false;//placemenrpose is valid is used for checking if the surface is good for placing the object or not

    public GameObject[] arModels;//hold multiple ar model object
    int modelIndex = 0;//keep track of ar model slected for placement

    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();//FIndObjectofType se ham ar raycast manager find karte hai in the scene
        UIArrows.SetActive(false);//disable ui arrow intially

    }

    // need to update placement indicator, placement pose and spawn
    void Update()
    ///<summary>
    //ye spwaned object == null check karega ki model/object spawned hua nhi kya
    ///placemertPoseIsValid check krega ki place valid hai ya nhi placement ke liye
    ///Input.touchCount and  Input.GetTouch(0) check krega ki input touch hua ya nhi
    //</summary>
    {
        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//touch(0) means 1 finger touch the screen and can increase them by touch(2,1,3,4)
        {
            ARPlaceObject(modelIndex);// if all true then ar object method is called
            UIArrows.SetActive(true);//ui mai button bhi aa jayegai
        }


        UpdatePlacementPose();//use to update constanstly placemnt and pose
        UpdatePlacementIndicator();//same


    }
    void UpdatePlacementIndicator()
    {
        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {//<Summary>
     // / screenCenter     isse hame pta chlata hai ki center screen raycasting hai or assum karte hai ki user point kar rha hai straight camera
     // / aRRaycastManager.Raycast: This shoots a ray from the screen's center into the real world to detect planes or surfaces.
     // /
     // /</ Summary >
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
       // var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid && spawnedObject == null)
        {
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject(int id)// index of model is id
    {
        for (int i = 0; i < arModels.Length; i++)
        {
            if (i == id)
            {
                GameObject clearUp = GameObject.FindGameObjectWithTag("ARMultiModel");
                Destroy(clearUp);
                spawnedObject = Instantiate(arModels[i], PlacementPose.position, PlacementPose.rotation);//create an new model of ar object
            }
        }


    }

    public void ModelChangeRight()
    {
        if (modelIndex < arModels.Length - 1)
            modelIndex++;
        else
            modelIndex = 0;

        ARPlaceObject(modelIndex);
    }
    public void ModelChangeLeft()
    {
        if (modelIndex > 0)
            modelIndex--;
        else
            modelIndex = arModels.Length - 1;

        ARPlaceObject(modelIndex);
    }

}







//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.XR.ARFoundation;                                             for only sapwn ar onject in screen
//using UnityEngine.XR.ARSubsystems;

//public class ARPlacement : MonoBehaviour
//{

//    public GameObject arObjectToSpawn;
//    public GameObject placementIndicator;
//    private GameObject spawnedObject;
//    private Pose PlacementPose;
//    private ARRaycastManager aRRaycastManager;
//    private bool placementPoseIsValid = false;

//    void Start()
//    {
//        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
//    }

//    // need to update placement indicator, placement pose and spawn 
//    void Update()
//    {
//        if (spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//        {
//            ARPlaceObject();
//        }


//        UpdatePlacementPose();
//        UpdatePlacementIndicator();


//    }
//    void UpdatePlacementIndicator()
//    {
//        if (spawnedObject == null && placementPoseIsValid)
//        {
//            placementIndicator.SetActive(true);
//            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
//        }
//        else
//        {
//            placementIndicator.SetActive(false);
//        }
//    }

//    void UpdatePlacementPose()
//    {
//        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
//        var hits = new List<ARRaycastHit>();
//        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

//        placementPoseIsValid = hits.Count > 0;
//        if (placementPoseIsValid)
//        {
//            PlacementPose = hits[0].pose;
//        }
//    }

//    void ARPlaceObject()
//    {
//        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
//    }


//}








