using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
//*****************basic calculator script // problem on aading 100 and 100 it become 100100
//public class calculationamount : MonoBehaviour
//{
//    public InputField display;
//    public int previous = 0, current = 0, function = 0;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void Store(int value)
//    {
//        // Append digits to the display text
//        display.text = /*"Total "+*/display.text + value.ToString();
//        current = int.Parse(display.text);
//    }

//    public void Sum()
//    {
//        previous = int.Parse(display.text);
//        display.text = "";
//        function = 1;
//    }


//    public void Cal()
//    {
//        if (function == 1)
//        {
//            display.text = (previous + current).ToString();
//        }

//    }
//}
//****************************

//*****************************************// problem not storeing data when changing scene
//public class calculationamount : MonoBehaviour
//{
//    public InputField display;
//    public int previous = 0, current = 0, function = 0;

//    public void Store(int value)
//    {
//        //// Append digits to the display text
//        //display.text = /*"Total "+*/     display.text + value.ToString();

//        ////current = int.Parse(display.text);
//        ////previous = int.Parse(display.text);
//        //display.text = current.ToString();

//        {
//            // Add the pressed value to the current total
//            current = current+ value;//##20 = current 
//            //##40= 20+20
//            //##60 =40+20
//            //# Update the display with the new total
//            display.text = current.ToString();
//            //#display = 20//display=40//dipslay = 40//display=60
//            //
//        }

//    }
//}
//*****************************************





public class CalculationAmount : MonoBehaviour
{
    public InputField display;

    private void Start()
    {
        //*** isss program se reset hoke 0 ho rhi hai value satrting mai
        

        int storedValue = PlayerPrefs.GetInt("StoredValue", 0);
        display.text = storedValue.ToString(); // Display the stored value when the scene load 

    }
    //unity store method hai jo lega value button se unity ui ki help se 
    public void Store(int value)
    {
        // Get the current stored value from PlayerPrefs
        int CurrentValue = PlayerPrefs.GetInt("StoredValue", 0);//

        // Add the pressed value to the stored value
        CurrentValue= CurrentValue + value;
        //### 20 =   0+let(20)
         //##40= Now(20)+20
       //##60 =40+20

        // Save the new value back to PlayerPrefs//playerprefs retrive value related to unity  specific key element
        PlayerPrefs.SetInt("StoredValue", CurrentValue);//jo currentValue hai vo storevalue mai chli jayegi

        
        display.text = CurrentValue.ToString();// Update the display simply
    }



    ///hamnai OnApllicationPause isliye use kiya kyoki ye mobile mai help karta hai reset karnai mai program
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            ResetPlayerPrefs();
        }
    }
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("StoredValue", 0);
    }
    //yha tak hai ye pura funcion application pause ka
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("StoredValue", 0); // Reset value to 0 when the application quits
    }
}