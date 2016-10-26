using UnityEngine;
using System.Collections;

public class MainLayout : MonoBehaviour {

    public GameObject InvenUI;
    public GameObject CatchListUI;
    public GameObject UserInfoUI;


    public void GoInven() {
        InvenUI.SetActive(true);
        InvenUI.GetComponent<Inventory>().Open();
        UserData.instance.UIopen = true;
    }


    public void GoCatchList()
    {
        CatchListUI.SetActive(true);
        CatchListUI.GetComponent<CatchCatList>().Open();
        UserData.instance.UIopen = true;
    }

    public void GoUserInfo()
    {
        UserInfoUI.SetActive(true);
        UserInfoUI.GetComponent<UserInfo>().Open();
        UserData.instance.UIopen = true;
    }




}
