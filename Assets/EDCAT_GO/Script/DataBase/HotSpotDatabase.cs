using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HotSpotDatabase : MonoBehaviour
{

    public static HotSpotDatabase instance;

    public List<HotSpot> hotspots;

    public int inID;
    public string inName;
    [TextArea]
    public string inContent;
    public Vector2 inPos;
    public float inTime;
    public int inItemID;
    public Sprite inIcon;
    public Texture2D inMarker;

    void Awake()
    {
        if (instance == null)
            instance = this;
        StartCoroutine("DelayUpdate");
        DontDestroyOnLoad(gameObject);
    }

    public void Add()
    {
        hotspots.Add(new HotSpot(inID, inName, inContent, inPos, inTime, inItemID, inIcon,inMarker));
    }

    public HotSpot Find(int id)
    {
        for (int i = 0; i < hotspots.Count; i++)
        {
            if (id == hotspots[i].ID)
            {
                return hotspots[i];
            }
        }
        return null;
    }

    public void ResetGetItem(int id)
    {
        for (int i = 0; i < hotspots.Count; i++)
        {
            if (id == hotspots[i].ID)
            {
                hotspots[i].Time = hotspots[i].BaseTime;
                break;
            }
        }
    }

    IEnumerator DelayUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < hotspots.Count; i++)
            {
                --hotspots[i].Time;
                if (hotspots[i].Time <= 0)
                {
                    hotspots[i].GetItem = true;
                }
                else
                {
                    hotspots[i].GetItem = false;
                }
            }
        }
    }

}

[System.Serializable]
public class HotSpot
{

    public int ID;
    public string Name;
    [TextArea]
    public string Content;
    public Vector2 Pos;
    public float BaseTime;
    public float Time;
    public bool GetItem;
    public int ItemID;
    public Sprite Icon;
    public Texture2D Marker;

    public HotSpot()
    {

    }

    public HotSpot(HotSpot h)
    {
        ID = h.ID;
        Name = h.Name;
        Content = h.Content;
        Pos = h.Pos;
        BaseTime = h.BaseTime;
        Time = h.Time;
        ItemID = h.ItemID;
        Icon = h.Icon;
        Marker = h.Marker;
    }

    public HotSpot(int id, string name, string content, Vector2 pos, float time, int itemid, Sprite icon,Texture2D m)
    {
        ID = id;
        Name = name;
        Content = content;
        Pos = pos;
        BaseTime = time;
        Time = BaseTime;
        ItemID = itemid;
        Icon = icon;
        Marker = m;
    }

}