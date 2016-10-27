using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public List<OnlineMapsMarker> CatMarker;

    public Cat AR;
    public Cat Catchs;

    void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("CatMake");
        print("game : " + Catchs.Name);
        if (Catchs.Name != "")
        {
            ViewCatInfo();
        }
    }

    IEnumerator CatMake()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            if (CatMarker.Count <= 4)
            {
                int val = Random.Range(1, 4);
                for (int i = 0; i < val; i++)
                {
                    int rand = Random.Range(0, CatDatabase.instance.cats.Count);
                    Vector2 Pos = OnlineMapsLocationService.instance.position;
                    Pos.x += Random.Range(0.000003f, 0.00008f);
                    Pos.y += Random.Range(0.000003f, 0.00008f);
                    Pos.x += Random.Range(-0.000001f, -0.00003f);
                    Pos.y += Random.Range(-0.000001f, -0.00003f);

                    print("make marker");
                    OnlineMapsMarker temp = OnlineMaps.instance.AddMarkerCat(Pos, CatDatabase.instance.cats[rand].Marker, CatDatabase.instance.cats[rand].Name, rand);
                    CatMarker.Add(temp);
                }
            }
        }
    }

    public void ViewCatInfo()
    {

        print("is not null");
        print(Catchs.Name);
        UserData.instance.CatchInfo.GetComponent<CatInfo>().Icon.GetComponent<Image>().sprite = Catchs.Icon;
        UserData.instance.CatchInfo.GetComponent<CatInfo>().Name.GetComponent<Text>().text = Catchs.Name;
        UserData.instance.CatchInfo.GetComponent<CatInfo>().Content.GetComponent<Text>().text = Catchs.Content;
        UserData.instance.CatchInfo.SetActive(true);

        Catchs = null;
    }
}
