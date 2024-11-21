//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShowAndHide : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public GameObject panelOff;
//    private bool isActive = true;

//    public void Toggle()
//    {
//        if(isActive) {  
//            panelOff.SetActive(false);
//        isActive = false;
//        }
//        else
//        {
//            panelOff.SetActive(true);
//            isActive = true;
//        }
//    }

//}





using UnityEngine;

public class ShowAndHide : MonoBehaviour
{
    public GameObject panelOff;  // This should be the object you want to toggle
    private bool isActive = true;

    public void Toggle()
    {
        // Debug to ensure the correct object is being referenced
        if (panelOff != null)
        {
            Debug.Log("Toggling visibility for: " + panelOff.name);

            if (isActive)
            {
                panelOff.SetActive(false);
                isActive = false;
            }
            else
            {
                panelOff.SetActive(true);
                isActive = true;
            }
        }
        else
        {
            Debug.LogError("panelOff is null, cannot toggle visibility.");
        }
    }
}
