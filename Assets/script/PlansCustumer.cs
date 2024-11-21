using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
public class PlansCustumer : MonoBehaviour
{
    //for watts
    public TMP_Text fanWatt;
    public TMP_Text tvWatt;
    public TMP_Text bulbWatt;
    public TMP_Text refrigeratorWatt;
    public TMP_Text acWatt;

    public TMP_Text fanNumber;
    public TMP_Text tvNumber;
    public TMP_Text bulbNumber;
    public TMP_Text refrigeratorNumber;
    public TMP_Text acNumber;

    public TMP_Dropdown dropdown;


    //for ongrid panel
    public GameObject showPanel1KW;
    public GameObject showPanel2KW;
    public GameObject showPanel3KW;
    public GameObject showPanel4KW;
    public GameObject showPanel5KW;
    public GameObject showPanel6KW;
    public GameObject showPanel7KW;
    public GameObject showPanel8KW;
    public GameObject showPanel9KW;



    //for off grid panels
    public GameObject showPanelOFFGrid1KW;
    public GameObject showPanelOFFGrid2KW;
    public GameObject showPanelOFFGrid3KW;
    public GameObject showPanelOFFGrid4KW;
    public GameObject showPanelOFFGrid5KW;
    public GameObject showPanelOFFGrid6KW;
    public GameObject showPanelOFFGrid7KW;
    public GameObject showPanelOFFGrid8KW;
    public GameObject showPanelOFFGrid9KW;




    private void Start()
    {

        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(); });// agar ham delegate nhi use kregai toh dropdownchanged()main(int value karna pdega or parameter dena pdega i.e dropdown.value ki jgh value ==1;)
    }

    public void DropdownValueChanged()
    {
        if (dropdown.value == 1)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "100";

            fanWatt.text = "70";
            fanNumber.text = "14";

            tvWatt.text = "100";
            tvNumber.text = "10";
           
            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "5";

            acWatt.text = "1500";
            acNumber.text = "0";

        }
        else if (dropdown.value == 2)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "200";

            fanWatt.text = "70";
            fanNumber.text = "28";

            tvWatt.text = "100";
            tvNumber.text = "20";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "10";

            acWatt.text = "1500";
            acNumber.text = "1";
        }
        else if (dropdown.value == 3)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "300";

            fanWatt.text = "70";
            fanNumber.text = "42";

            tvWatt.text = "100";
            tvNumber.text = "30";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "15";

            acWatt.text = "1500";
            acNumber.text = "2";


        }
        else if(dropdown.value == 4)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "400";

            fanWatt.text = "70";
            fanNumber.text = "56";

            tvWatt.text = "100";
            tvNumber.text = "40";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "20";

            acWatt.text = "1500";
            acNumber.text = "2";
        }
        else if(dropdown.value == 5)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "500";

            fanWatt.text = "70";
            fanNumber.text = "70";

            tvWatt.text = "100";
            tvNumber.text = "50";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "25";

            acWatt.text = "1500";
            acNumber.text = "3";

        }
        else if(dropdown.value == 6)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "600";

            fanWatt.text = "70";
            fanNumber.text = "84";

            tvWatt.text = "100";
            tvNumber.text = "60";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "30";

            acWatt.text = "1500";
            acNumber.text = "4";

        } 
        else if(dropdown.value == 7)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "700";

            fanWatt.text = "70";
            fanNumber.text = "98";

            tvWatt.text = "100";
            tvNumber.text = "70";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "35";

            acWatt.text = "1500";
            acNumber.text = "4";

        }  
        else if(dropdown.value == 8)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "800";

            fanWatt.text = "70";
            fanNumber.text = "112";

            tvWatt.text = "100";
            tvNumber.text = "80";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "40";

            acWatt.text = "1500";
            acNumber.text = "5";

        }
        else if(dropdown.value == 9)
        {
            bulbWatt.text = "10";
            bulbNumber.text = "900";

            fanWatt.text = "70";
            fanNumber.text = "126";

            tvWatt.text = "100";
            tvNumber.text = "90";

            refrigeratorWatt.text = "200";
            refrigeratorNumber.text = "45";

            acWatt.text = "1500";
            acNumber.text = "6";

        }
        else if(dropdown.value == 0)
        {
            bulbWatt.text = "-";
            bulbNumber.text = "-";

            fanWatt.text = "-";
            fanNumber.text = "-";

            tvWatt.text = "-";
            tvNumber.text = "-";

            refrigeratorWatt.text = "-";
            refrigeratorNumber.text = "-";

            acWatt.text = "-";
            acNumber.text = "-";

        }
    }


// to open panels
    public void ShowPanelOnclick()
    {
        if (dropdown.value == 0)
        {
            return;
        }
        else if (dropdown.value == 1)
        {
            showPanel1KW.SetActive(true);
        }
        else if (dropdown.value == 2)
        {
            showPanel2KW.SetActive(true);
        }
        else if (dropdown.value == 3)
        {
            showPanel3KW.SetActive(true);
        }
        else if (dropdown.value == 4)
        {
            showPanel4KW.SetActive(true);
        }
        else if (dropdown.value == 5)
        {
            showPanel5KW.SetActive(true);
        }
        else if (dropdown.value == 6)
        {
            showPanel6KW.SetActive(true);
        }
        else if (dropdown.value == 7)
        {
            showPanel7KW.SetActive(true);
        }
        else if (dropdown.value == 8)
        {
            showPanel8KW.SetActive(true);
        }
        else if (dropdown.value == 9)
        {
            showPanel9KW.SetActive(true);
        }

    }
    //ongrid panel close code
    public void closePanelSubsidy()
    {

        showPanel1KW.SetActive(false);
        showPanel2KW.SetActive(false);
        showPanel3KW.SetActive(false);
        showPanel4KW.SetActive(false);
        showPanel5KW.SetActive(false);
        showPanel6KW.SetActive(false);
        showPanel7KW.SetActive(false);
        showPanel8KW.SetActive(false);
        showPanel9KW.SetActive(false);

    }





    //offgrid panel
    public void ShowPanelOFFGridOnclick()
    {
        if (dropdown.value == 0)
        {
            return;
        }
        else if (dropdown.value == 1)
        {
            showPanelOFFGrid1KW.SetActive(true);
        }
        else if (dropdown.value == 2)
        {
            showPanelOFFGrid2KW.SetActive(true);
        }
        else if (dropdown.value == 3)
        {
            showPanelOFFGrid3KW.SetActive(true);
        }
        else if (dropdown.value == 4)
        {
            showPanelOFFGrid4KW.SetActive(true);
        }
        else if (dropdown.value == 5)
        {
            showPanelOFFGrid5KW.SetActive(true);
        }
        else if (dropdown.value == 6)
        {
            showPanelOFFGrid6KW.SetActive(true);
        }
        else if (dropdown.value == 7)
        {
            showPanelOFFGrid7KW.SetActive(true);
        }
        else if (dropdown.value == 8)
        {
            showPanelOFFGrid8KW.SetActive(true);
        }
        else if (dropdown.value == 9)
        {
            showPanelOFFGrid9KW.SetActive(true);
        }

    }
    //offgrid panel close code panel
    public void closePanelOffGrid()
    {

        showPanelOFFGrid1KW.SetActive(false);
        showPanelOFFGrid2KW.SetActive(false);
        showPanelOFFGrid3KW.SetActive(false);
        showPanelOFFGrid4KW.SetActive(false);
        showPanelOFFGrid5KW.SetActive(false);
        showPanelOFFGrid6KW.SetActive(false);
        showPanelOFFGrid7KW.SetActive(false);
        showPanelOFFGrid8KW.SetActive(false);
        showPanelOFFGrid9KW.SetActive(false);

    }


}




















//using UnityEngine;
//using TMPro; 
//using UnityEngine;
//using TMPro;

//public class PlansCustumer : MonoBehaviour
//{
//    public TMP_Dropdown dropdown;  
//    public GameObject panel;      

//    private void Start()
//    {

//        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(); });// aga r ham delegate nhi use kregai toh dropdownchanged()main(int value karna pdega or parameter dena pdega i.e dropdown.value ki jgh value ==1;)
//    }

//    private void DropdownValueChanged()
//    {

//        if (dropdown.value == 1)
//        {
//            panel.SetActive(false); 
//        }
//        else
//        {
//            panel.SetActive(true);
//        }
//    }
//}



