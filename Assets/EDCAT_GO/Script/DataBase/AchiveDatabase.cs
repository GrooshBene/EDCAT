using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AchiveDatabase : MonoBehaviour
{

    public static AchiveDatabase instance;

    public List<Achive> achives;

    public int InID;
    public string InName;
    [TextArea]
    public string InContent;
    public Sprite InIcon;
    public Achive.Kind InKind;
    public int InPoint;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (PlayerPrefs.GetString("Achive") != "")
        {
            LoadSuccess();
        }
        if (AchiveList.instance != null)
            AchiveList.instance.Invoke("SetAchive", 1f);
        /*
        else {
            Invoke("Seta",1f);
        }
        */
        DontDestroyOnLoad(gameObject);
    }

    void Seta() {
        AchiveList.instance.Invoke("SetAchive", 1f);
    }

    public void Add()
    {
        achives.Add(new Achive(InID, InName, InContent, InIcon, InPoint, InKind));
    }

    public int CountOfSuccess()
    {
        int cnt = 0;

        for (int i = 0; i < achives.Count; i++)
        {
            if (achives[i].Success)
                ++cnt;
        }
        return cnt;
    }

    public void SetSuccess(int id)
    {
        if (achives[id].Success == false)
        {
            achives[id].Success = true;
            switch (achives[id].kind)
            {
                case Achive.Kind.Catch:
                    UserData.instance.catchAchiveCnt++;
                    break;
                default: break;
            }
            //www 통신
            string url = "http://kafuuchino.one:7070/user/addexp";

            WWWForm form = new WWWForm();
            form.AddField("exp", achives[id].Point);
            form.AddField("id", PlayerPrefs.GetString("token"));
            WWW www = new WWW(url, form);

            print("www 업적으로 인한 포인트 증가");
            SaveSuccess();
        }
    }

    public void LoadSuccess()
    {
        string data = PlayerPrefs.GetString("Achive");
        string[] list = data.Split(',');
        for (int i = 0; i < achives.Count; i++)
        {
            if (list[i] != "" && achives[i].ID == int.Parse(list[i]))
                achives[i].Success = true;
        }
    }

    public void SaveSuccess()
    {
        string asd = "";
        for (int i = 0; i < achives.Count; i++)
        {
            if (achives[i].Success)
                asd += achives[i].ID + ",";
        }
        PlayerPrefs.SetString("Achive", asd);
    }
}


[System.Serializable]
public class Achive
{
    public enum Kind
    {
        Special,
        Catch,
        Items
    };

    public int ID;
    public string Name;
    [TextArea]
    public string Content;
    public Kind kind;
    public Sprite Icon;
    public int Point;
    public bool Success;

    public Achive()
    {

    }

    public Achive(Achive a)
    {
        ID = a.ID;
        Name = a.Name;
        Content = a.Content;
        Icon = a.Icon;
        Point = a.Point;
        Success = a.Success;
        kind = a.kind;
    }

    public Achive(int id, string name, string content, Sprite icon, int point, Kind kinds)
    {
        ID = id;
        Name = name;
        Content = content;
        Icon = icon;
        Point = point;
        kind = kinds;
    }

}
