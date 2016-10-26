using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UserData : MonoBehaviour
{

    public static UserData instance;

    //유저 랭킹
    public int userRank;

    //업적 
    public int achiveCnt;

    //포획
    public int catchCnt;
    public int catchFailCnt;
    public int combo;
    public int catchAchiveCnt;

    //아이템 수집
    public int itemCnt;

    public GameObject profile_pic;
    public GameObject HotspotInfo;
    public GameObject CatchInfo;

    public Item wearItem;

    public bool UIopen;

    // Use this for initialization
    void Awake()
    {
        //싱글톤으로 지정합니다.
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //파괴 되지 않도록 보호합니다.
        DontDestroyOnLoad(this.gameObject);

        //처음 플레이 인 경우
        if (PlayerPrefs.GetInt("UserRank",0) == 0)
        {
            PlayerPrefs.SetInt("UserLank", 0);
            PlayerPrefs.SetInt("AchiveCnt", 0);
            PlayerPrefs.SetInt("CatchCnt", 0);
            PlayerPrefs.SetInt("CatchFailCnt", 0);
            PlayerPrefs.SetInt("ItemCnt", 0);

            userRank = 0;
            achiveCnt = 0;
            catchCnt = 0;
            catchFailCnt = 0;
            itemCnt = 0;
        }
        // 이미 플레이 기록이 있는 경우
        else
        {
            userRank = PlayerPrefs.GetInt("UserRank");
            achiveCnt = PlayerPrefs.GetInt("AchiveCnt");
            catchCnt = PlayerPrefs.GetInt("CatchCnt");
            catchFailCnt = PlayerPrefs.GetInt("CatchFailCnt");
            itemCnt = PlayerPrefs.GetInt("ItemCnt");
        }

        //페이스북 프로필 사진을 로드합니다.
        if (FBLogin.instance.Profile_Pic != null)
            profile_pic.GetComponent<Image>().sprite = FBLogin.instance.Profile_Pic;

    }

    //유저 업적 데이터를 로컬에 저장합니다.
    public void SaveUserAchiveData()
    {
        PlayerPrefs.SetInt("UserLank", userRank);
        PlayerPrefs.SetInt("AchiveCnt", achiveCnt);
        PlayerPrefs.SetInt("CatchCnt", catchCnt);
        PlayerPrefs.SetInt("CatchFailCnt", catchFailCnt);
        PlayerPrefs.SetInt("ItemCnt", itemCnt);
    }

    //업적 >  랭킹의 데이터를 갱신합니다.
    public void UpdateRank(int rank)
    {
        userRank = rank;
        //2등 1등 업적
        switch (userRank)
        {
            case 2:
                AchiveDatabase.instance.SetSuccess(1);
                break;
            case 1:
                AchiveDatabase.instance.SetSuccess(0);
                break;
            default:
                break;
        }
        SaveUserAchiveData();
        UpdateAchiveCnt();
    }

    //업적 > 업적 누적량 데이터를 갱신합니다.
    public void UpdateAchiveCnt()
    {
        achiveCnt = AchiveDatabase.instance.CountOfSuccess();
        if (achiveCnt >= AchiveDatabase.instance.achives.Count)
        {
            AchiveDatabase.instance.SetSuccess(3);
        }
        SaveUserAchiveData();
    }

    //업적 >  포획한 누적 고양이 양 데이터를 갱신합니다.
    public void UpdateCatchCnt(bool success)
    {
        if (success)
        {
            ++catchCnt;
            if (combo < 0)
                combo = 0;
            ++combo;
        }
        else
        {
            ++catchFailCnt;
            if (catchFailCnt == 1)
            {
                //첫 실패
                AchiveDatabase.instance.SetSuccess(11);
            }
            combo = 0;
            combo -= 1;
        }

        //누적 포획량 업적 클리어
        switch (catchCnt)
        {
            case 50:
                AchiveDatabase.instance.SetSuccess(10);
                break;
            case 20:
                AchiveDatabase.instance.SetSuccess(7);
                break;
            case 10:
                AchiveDatabase.instance.SetSuccess(6);
                break;
            case 5:
                AchiveDatabase.instance.SetSuccess(5);
                break;
            case 1:
                AchiveDatabase.instance.SetSuccess(4);
                break;
            default:
                break;
        }

        if (combo >= 3)
        {
            //연속 포획 업적 클리어
            AchiveDatabase.instance.SetSuccess(9);
        }
        else if (combo <= -3)
        {
            //연속 실패 업적 클리어
            AchiveDatabase.instance.SetSuccess(12);
        }

        if (catchAchiveCnt == 9)
        {
            //사냥 마스터 획득
            AchiveDatabase.instance.SetSuccess(13);
        }
        UpdateAchiveCnt();
        SaveUserAchiveData();

    }

    //업적 > 아이템 획득 량 데이터를 갱신합니다.
    public void UpdateItemCnt()
    {
        ++itemCnt;

        //누적 아이템 수집 업적 클리어
        switch (itemCnt)
        {
            case 5:
                AchiveDatabase.instance.SetSuccess(18);
                break;
            case 4:
                AchiveDatabase.instance.SetSuccess(17);
                break;
            case 3:
                AchiveDatabase.instance.SetSuccess(16);
                break;
            case 2:
                AchiveDatabase.instance.SetSuccess(15);
                break;
            case 1:
                AchiveDatabase.instance.SetSuccess(14);
                break;

            default: break;
        }

        if (itemCnt == 5)
        {
            //아이템 업적 모두 클리어
            AchiveDatabase.instance.SetSuccess(19);
        }
        UpdateAchiveCnt();
        SaveUserAchiveData();
    }




}
