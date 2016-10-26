using UnityEngine;
using System.Collections;


public class ServerAddMarker : MonoBehaviour
{

    public static ServerAddMarker instance;


    void Awake()
    {
        if (instance == null)
            instance = this;

        //WWW


    }

    // Use this for initialization
    void Start()
    {
        //서버에서 유효한 마커를 가져옵니다.

        //핫스팟 설정
        OnlineMaps.instance.AddMarkerHotSpot(new Vector2(127.061221f, 37.535517f), CatDatabase.instance.cats[0].Marker, CatDatabase.instance.cats[0].Name, 1);

        //선린 인터넷고등학교
        for (int i = 0; i < HotSpotDatabase.instance.hotspots.Count;i++)
        {
            OnlineMaps.instance.AddMarkerHotSpot(HotSpotDatabase.instance.hotspots[i].Pos, HotSpotDatabase.instance.hotspots[i].Marker, HotSpotDatabase.instance.hotspots[i].Name, HotSpotDatabase.instance.hotspots[i].ID);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
