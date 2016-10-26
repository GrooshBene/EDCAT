using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public List<Item> items;

    public int inID;
    public string inName;
    [TextArea]
    public string inContent;
    public Item.Kind inKind;
    public Sprite inIcon;
    public int inValue;

    //포획 확률
    public float InCatchPercent;

    //버프성 시간
    public float InTime;

    //과금 옵션
    public bool InSpendOption;


    void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Add() {
        items.Add(new Item(inID, inName,inContent,inKind,inIcon, inValue, InCatchPercent, InTime, InSpendOption));
    }

    public Item Find(int id) {
        for (int i = 0; i<items.Count; i++) {
            if (id == items[i].ID)
                return items[i];
        }
        return null;
    }

}


[System.Serializable]
public class Item
{
    public enum Kind {
        Buff,
        Use,
        HotTime,
        Box
    };

    public int ID;
    public string Name;
    [TextArea]
    public string Content;
    public Kind Kinds;
    public Sprite Icon;
    public int Value;

    //포획 확률
    public float CatchPercent;

    //버프성 시간
    public float Time;

    //과금 옵션
    public bool SpendOption;



    Item() {}

    public Item(Item i) {
        ID = i.ID;
        Name = i.Name;
        Content = i.Content;
        Kinds = i.Kinds;
        Icon = i.Icon;
        Value = i.Value;
        CatchPercent = i.CatchPercent;
        Time = i.Time;
        SpendOption = i.SpendOption;
    }

    public Item(int id, string name, string content, Kind kind, Sprite icon,int value,float percent, float time, bool option) {
        ID = id;
        Name = name;
        Content = content;
        Kinds = kind;
        Icon = icon;
        Value = value;
        CatchPercent = percent;
        Time = time;
        SpendOption = option;
    }

}
