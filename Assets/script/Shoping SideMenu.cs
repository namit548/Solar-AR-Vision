using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopingSideMenu : MonoBehaviour
{


    public InputField display;
    private int ItemId1, ItemId2, ItemId3, ItemId4, ItemId5, ItemId6, ItemId7, ItemId8, ItemId9, ItemId10;//of quantity
    public Text QuantityText1;//of quantity
    public Text QuantityText2;//of quantity
    public Text QuantityText3;//of quantity
    public Text QuantityText4;//of quantity
                              //public Text QuantityText5;//of quantity
                              //public Text QuantityText6;//of quantity
                              //public Text QuantityText7;//of quantity
                              //public Text QuantityText8;//of quantity
                              //public Text QuantityText9;//of quantity
                              //public Text QuantityText10;//of quantity

    //  public GameObject ShopManager;

    //private void Start()   {// is code ye dikat hai ki storedvalues 0 ho jati hai lekin screne change ke time pplayerprefs isse display se update kar deta hai
    //   //playerprefs retrive value related to unity  specific key element
    //    int storeValue = PlayerPrefs.GetInt("StoredValues", 0);  yha dikkat hai  toh hami new value use karni hai har baar
    //    display.text = storeValue.ToString();//for main display
    //    QuantityText1.text = storeValue.ToString();//reset value of quantity to 0 
    //    QuantityText2.text = storeValue.ToString();//reset value of quantity to 0 
    //    QuantityText3.text = storeValue.ToString();//reset value of quantity to 0 
    //    QuantityText4.text = storeValue.ToString();//reset value of quantity to 0    
    //}


    private void Start()
    {
        // retrieve the stored total value for the main display
        int storeValue = PlayerPrefs.GetInt("StoredValues", 0);
        display.text = storeValue.ToString(); // for main display

        // Retrieve and display each item's quantity
        int itemQuantity1 = PlayerPrefs.GetInt("NewQuantity1", 0);
        QuantityText1.text = itemQuantity1.ToString(); // display quantity of item 1

        int itemQuantity2 = PlayerPrefs.GetInt("NewQuantity2", 0);
        QuantityText2.text = itemQuantity2.ToString(); // display quantity of item 2

        int itemQuantity3 = PlayerPrefs.GetInt("NewQuantity3", 0);
        QuantityText3.text = itemQuantity3.ToString(); // display quantity of item 3

        int itemQuantity4 = PlayerPrefs.GetInt("NewQuantity4", 0);
        QuantityText4.text = itemQuantity4.ToString(); // display quantity of item 4
    }



    private void ItemID1(int Quanti)
    {
        int CurreQuanti = PlayerPrefs.GetInt("NewQuantity1", 0);
        CurreQuanti = CurreQuanti + 1;
        PlayerPrefs.SetInt("NewQuantity1", CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
        QuantityText1.text = CurreQuanti.ToString();//display Quantity


    } private void ItemID2(int Quanti)
    {
        int CurreQuanti = PlayerPrefs.GetInt("NewQuantity2", 0);
        CurreQuanti = CurreQuanti + 1;
        PlayerPrefs.SetInt("NewQuantity2", CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
        QuantityText2.text = CurreQuanti.ToString();//display Quantity


    } private void ItemID3(int Quanti)
    {
        int CurreQuanti = PlayerPrefs.GetInt("NewQuantity3", 0);
        CurreQuanti = CurreQuanti + 1;
        PlayerPrefs.SetInt("NewQuantity3", CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
        QuantityText3.text = CurreQuanti.ToString();//display Quantity


    } public void ItemID4(int Quanti)
    {
        int CurreQuanti = PlayerPrefs.GetInt("NewQuantity4", 0);
        CurreQuanti = CurreQuanti + 1;
        PlayerPrefs.SetInt("NewQuantity4", CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
        QuantityText4.text = CurreQuanti.ToString();//display Quantity


    }//public void ItemID5(int Quanti)
    //{
    //    int CurreQuanti = PlayerPrefs.GetInt("NewQuantity", 0);
    //    CurreQuanti = CurreQuanti+1;
    //    PlayerPrefs.SetInt("NewQuantity",CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
    //    QuantityText1.text = CurreQuanti.ToString();//display Quantity


    //}public void ItemID6(int Quanti)
    //{
    //    int CurreQuanti = PlayerPrefs.GetInt("NewQuantity", 0);
    //    CurreQuanti = CurreQuanti+1;
    //    PlayerPrefs.SetInt("NewQuantity",CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
    //    QuantityText1.text = CurreQuanti.ToString();//display Quantity


    //}public void ItemID7(int Quanti)
    //{
    //    int CurreQuanti = PlayerPrefs.GetInt("NewQuantity", 0);
    //    CurreQuanti = CurreQuanti+1;
    //    PlayerPrefs.SetInt("NewQuantity",CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
    //    QuantityText1.text = CurreQuanti.ToString();//display Quantity


    //}public void ItemID8(int Quanti)
    //{
    //    int CurreQuanti = PlayerPrefs.GetInt("NewQuantity", 0);
    //    CurreQuanti = CurreQuanti+1;
    //    PlayerPrefs.SetInt("NewQuantity",CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
    //    QuantityText1.text = CurreQuanti.ToString();//display Quantity


    //}public void ItemID9(int Quanti)
    //{
    //    int CurreQuanti = PlayerPrefs.GetInt("NewQuantity", 0);
    //    CurreQuanti = CurreQuanti+1;
    //    PlayerPrefs.SetInt("NewQuantity",CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
    //    QuantityText1.text = CurreQuanti.ToString();//display Quantity


    //}public void ItemID10(int Quanti)
    //{
    //    int CurreQuanti = PlayerPrefs.GetInt("NewQuantity", 0);
    //    CurreQuanti = CurreQuanti+1;
    //    PlayerPrefs.SetInt("NewQuantity",CurreQuanti);//store the vlaue after i press button i.e 1 for 1 and send to curreQuanti=1 so 2 = 1+1
    //    QuantityText1.text = CurreQuanti.ToString();//display Quantity


    //}


    public void Store(int value)
    {
        int currentValue = PlayerPrefs.GetInt("StoredValues", 0);
        currentValue = currentValue + value;
        PlayerPrefs.SetInt("StoredValues", currentValue);
        display.text = currentValue.ToString();

    }

    //***** remove the quantity  and display the subtracted amaount
    
    public void ResetQuantityItem1()
    {
        // Step 1: Retrieve the current total from the display
        int currentTotal = PlayerPrefs.GetInt("StoredValues", 0);

        // Step 2: Retrieve the quantity of Item 1
        int quantity1 = PlayerPrefs.GetInt("NewQuantity1", 0);

        // Step 3: Subtract Item 1's quantity from the total
        currentTotal = currentTotal - quantity1 * 19999;

        // Step 4: Store the updated total and reset Item 1's quantity
        PlayerPrefs.SetInt("StoredValues", currentTotal);
        PlayerPrefs.SetInt("NewQuantity1", 0);

        // Step 5: Update the display and reset Item 1's quantity text
        display.text = currentTotal.ToString();
        QuantityText1.text = "Quantity : 0";
    }
    public void ResetQuantityItem2() 
    {
        // Step 1: Retrieve the current total from the display
        int currentTotal = PlayerPrefs.GetInt("StoredValues", 0);

        // Step 2: Retrieve the quantity of Item 1
        int quantity2 = PlayerPrefs.GetInt("NewQuantity2", 0);

        // Step 3: Subtract Item 1's quantity from the total
        currentTotal = currentTotal - quantity2 * 13999;

        // Step 4: Store the updated total and reset Item 1's quantity
        PlayerPrefs.SetInt("StoredValues", currentTotal);
        PlayerPrefs.SetInt("NewQuantity2", 0);

        // Step 5: Update the display and reset Item 1's quantity text
        display.text = currentTotal.ToString();
        QuantityText2.text = "Quantity : 0";
    }
    public void ResetQuantityItem3()
    {
        // Step 1: Retrieve the current total from the display
        int currentTotal = PlayerPrefs.GetInt("StoredValues", 0);

        // Step 2: Retrieve the quantity of Item 1
        int quantity3 = PlayerPrefs.GetInt("NewQuantity3", 0);

        // Step 3: Subtract Item 1's quantity from the total
        currentTotal = currentTotal - quantity3 * 23999;

        // Step 4: Store the updated total and reset Item 1's quantity
        PlayerPrefs.SetInt("StoredValues", currentTotal);
        PlayerPrefs.SetInt("NewQuantity3", 0);

        // Step 5: Update the display and reset Item 1's quantity text
        display.text = currentTotal.ToString();
        QuantityText3.text = "Quantity : 0";
    }
    public void ResetQuantityItem4()
    {
        // Step 1: Retrieve the current total from the display
        int currentTotal = PlayerPrefs.GetInt("StoredValues", 0);

        // Step 2: Retrieve the quantity of Item 1
        int quantity4 = PlayerPrefs.GetInt("NewQuantity4", 0);

        // Step 3: Subtract Item 1's quantity from the total
        currentTotal = currentTotal - quantity4 * 27999;

        // Step 4: Store the updated total and reset Item 1's quantity
        PlayerPrefs.SetInt("StoredValues", currentTotal);
        PlayerPrefs.SetInt("NewQuantity4", 0);

        // Step 5: Update the display and reset Item 1's quantity text
        display.text = currentTotal.ToString();
        QuantityText4.text = "Quantity : 0";
    }


    //******remove the quantity  and display the subtracted amaount


    ///hamnai OnApllicationPause isliye use kiya kyoki ye mobile mai help karta hai reset karnai mai program
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // App is being paused (minimized/suspended)
            ResetPlayerPrefs();
        }
    }

    private void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("StoredValues", 0);
        PlayerPrefs.SetInt("NewQuantity1", 0);
        PlayerPrefs.SetInt("NewQuantity2", 0);
        PlayerPrefs.SetInt("NewQuantity3", 0);
        PlayerPrefs.SetInt("NewQuantity4", 0);
    }
    //yha tak hai ye pura funcion application pause ka


    //OnApllicationQuit se ham computer mai reset kar sakte hai
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("StoredValues", 0);

        PlayerPrefs.SetInt("NewQuantity1", 0);
        PlayerPrefs.SetInt("NewQuantity2", 0);
        PlayerPrefs.SetInt("NewQuantity3", 0);
        PlayerPrefs.SetInt("NewQuantity4", 0);
    }
    //Onapplication yha tak hai
}
