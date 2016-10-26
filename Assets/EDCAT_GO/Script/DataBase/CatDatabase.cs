using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CatDatabase : MonoBehaviour {

    public static CatDatabase instance;

    public List<Cat> cats;

    public int InID;
    public string InName;
    [TextArea]
    public string InContent;
    public System.DateTime Intime;
    public int InPoint;
    public float InPercent;
    public Sprite InImg;
    public Sprite InIcon;
    public Texture2D InMarker;


    void Awake()
    {
        //싱글톤으로 지정합니다.
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this.gameObject);
        }
        //파괴 되지 않도록 보호합니다.
        DontDestroyOnLoad(this.gameObject);
        
    }

    //데이터 베이스에 추가
    public void Add() {
        cats.Add(new Cat(InID, InName, InContent, InIcon, InImg, InPoint,InPercent,InMarker));
    }

    //포획된 고양이의 수를 계산
    public int CountOfCatSuccess() {
        int cnt = 0;

        for (int i = 0; i < cats.Count; i++) {
            if (cats[i].Success)
                ++cnt;
        }
        return cnt;
    }

    //DB에서 고양이를 찾습니다.
    public Cat FindCat(int id) {
        for (int i = 0; i < cats.Count; i++) {
            if (id == cats[i].ID) {
                return cats[i];
            }
        }
        return null;
    }

    //고양이 포획의 성공처리를 세팅 합니다.
    public void SetCatSuccess(int id)
    {
        if (cats[id].Success == false)
        {
            cats[id].Success = true;
            SaveSuccess();
        }
    }

    //성공한 고양이 리스트를 읽어 옵니다.
    public void LoadCatSuccess()
    {
        string SuccessData = PlayerPrefs.GetString("CatCatch");
        string[] sort = SuccessData.Split(',');
        for (int i = 0; i < cats.Count; i++)
        {
            if (sort[i] != "" && cats[i].ID == int.Parse(sort[i]))
                cats[i].Success = true;
        }
    }

    //성공한 고양이 리스트를 저장합니다.
    public void SaveSuccess()
    {
        string SuccessData = "";
        for (int i = 0; i < cats.Count; i++)
        {
            if (cats[i].Success)
                SuccessData += cats[i].ID + ",";
        }
        PlayerPrefs.SetString("CatCatch", SuccessData);
    }

}


[System.Serializable]
public class Cat {
    public int ID;
    public string Name;
    [TextArea]
    public string Content;
    public System.DateTime Time;
    public int Point;
    public float Percent;
    public Sprite Img;
    public Sprite Icon;
    public Texture2D Marker;
    public int Count;
    public bool Success;

    public Cat() {

    }

    public Cat(Cat c)
    {
        ID = c.ID;
        Name = c.Name;
        Content = c.Content;
        Icon = c.Icon;
        Img = c.Img;
        Time = c.Time;
        Point = c.Point;
        Percent = c.Percent;
        Marker = c.Marker;
        Count = c.Count;
        Success = c.Success;
    }
    public Cat(int id, string name, string content, Sprite icon, Sprite img, int point,float percent,Texture2D marker)
    {
        ID = id;
        Name = name;
        Content = content;
        Icon = icon;
        Img = img;
        Point = point;
        Percent = percent;
        Marker = marker;
    }
    public Cat(int id, string name, string content, Sprite icon, Sprite img, int point,float percent ,System.DateTime time,Texture2D marker)
    {
        ID = id;
        Name = name;
        Content = content;
        Icon = icon;
        Img = img;
        Time = time;
        Point = point;
        Percent = percent;
        Marker = marker;
    }
}
