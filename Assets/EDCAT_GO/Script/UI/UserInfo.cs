using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInfo : MonoBehaviour {

    public static UserInfo instance;

    public GameObject CatchCat;
    public GameObject Rank;
    public GameObject Archive;

    public GameObject ArchiveSlider;
    public GameObject CatchCatSlider;

    public GameObject Profile_pic;
    public GameObject Profile_Name;

    

    Animator ani;

    void Awake()
    {
        if (instance == null)
            instance = this;
        ani = GetComponent<Animator>();
        if (FBLogin.instance.Profile_Pic != null)
        {
            Profile_pic.GetComponent<Image>().sprite = FBLogin.instance.Profile_Pic;
            Profile_Name.GetComponent<Text>().text = FBLogin.instance.UserName;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Open()
    {
        ani.SetBool("Open", !ani.GetBool("Open"));
        if (ani.GetBool("Open") == false)
        {
            UserData.instance.UIopen = false;
        }
        else {
            UpdateArchiveSlider();
            UpdateCatchCatSlider();
        }
    }

    public void UpdateArchiveSlider() {
        ArchiveSlider.GetComponent<Slider>().maxValue = AchiveDatabase.instance.achives.Count;
        ArchiveSlider.GetComponent<Slider>().value = AchiveDatabase.instance.CountOfSuccess();
        ArchiveSlider.transform.GetChild(2).GetComponent<Text>().text = ArchiveSlider.GetComponent<Slider>().value + " / "+AchiveDatabase.instance.achives.Count;
    }

    public void UpdateCatchCatSlider()
    {
        CatchCatSlider.GetComponent<Slider>().maxValue = CatDatabase.instance.cats.Count;
        CatchCatSlider.GetComponent<Slider>().value = CatDatabase.instance.CountOfCatSuccess();
        CatchCatSlider.transform.GetChild(2).GetComponent<Text>().text = CatchCatSlider.GetComponent<Slider>().value + " / " + AchiveDatabase.instance.achives.Count;
    }



    public void RankBtn()
    {
        Rank.SetActive(true);
        RankList.instance.Open();
    }

    public void CatchCatBtn()
    {
        CatchCat.SetActive(true);
        CatchCatList.instance.Open();
    }

    public void ArchiveBtn()
    {
        Archive.SetActive(true);
        AchiveList.instance.Open();
    }
}
