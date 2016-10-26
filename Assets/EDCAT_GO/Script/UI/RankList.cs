using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class RankList : MonoBehaviour
{

    public static RankList instance;

    public GameObject Lists;
    public GameObject list;

    public Vector2 BasicPos;
    public Vector2 Margin;

    public JsonData jsondata;

    Animator ani;

    void Awake()
    {
        if (instance == null)
            instance = this;
        ani = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    public void Open()
    {
        ani.SetBool("Open", !ani.GetBool("Open"));
        if (ani.GetBool("Open"))
            SetLank();
    }

    void SetLank()
    {
        string url = "http://kafuuchino.one:7070/user/getrank";
        WWWForm form = new WWWForm();
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
            jsondata = JsonMapper.ToObject(www.text);
        }
        else {
            Debug.Log("WWW Error: " + www.error);
        }

    }

    void ListMake()
    {
        for (int i = 0; i < jsondata.Count; i++)
        {
            GameObject temp = Instantiate(list, Lists.transform) as GameObject;
            temp.transform.localPosition = new Vector3(BasicPos.x, BasicPos.y - Margin.y * i);
            if (i == 0)
            {
                temp.transform.GetChild(1).gameObject.SetActive(true);
            }
            temp.GetComponent<Text>().text = jsondata[i]["name"].ToString();
            temp.transform.GetChild(2).GetComponent<Text>().text = jsondata[i]["name"].ToString();
            temp.transform.GetChild(3).GetComponent<Text>().text = jsondata[i]["exp"].ToString();
        }
    }
}