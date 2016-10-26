using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AchiveList : MonoBehaviour {

    public static AchiveList instance;

    public GameObject Lists;
    public GameObject List;

    public List<GameObject> Slots;

    public Vector2 BasicPos;
    public Vector2 Margin;

    Animator ani;

    void Start()
    {
        if (instance == null)
            instance = this;
        ani = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    public void Open()
    {
        ani.SetBool("Open", !ani.GetBool("Open"));
    }

    public void SetAchive()
    {
        for (int i = 0; i < AchiveDatabase.instance.achives.Count; i++) {
            GameObject temp = Instantiate(List,Lists.transform) as GameObject;
            temp.transform.localPosition = new Vector3(BasicPos.x, BasicPos.y - Margin.y * i);
            temp.GetComponent<Text>().text = AchiveDatabase.instance.achives[i].Name;
            temp.transform.GetChild(0).GetComponent<Text>().text = AchiveDatabase.instance.achives[i].Content;
            if (AchiveDatabase.instance.achives[i].Success)
            {
                temp.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                temp.transform.GetChild(1).gameObject.SetActive(false);
            }

            Slots.Add(temp);
        }
    }

    public void UpdateAchive(int id) {
        if (AchiveDatabase.instance.achives[id].Success)
        {
            Slots[id].transform.GetChild(1).gameObject.SetActive(true);
        }
        else {
            Slots[id].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
