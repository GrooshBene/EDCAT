using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HaveCatList : MonoBehaviour
{

    public static HaveCatList instance;

    public GameObject slot;
    public GameObject catInfo;
    public GameObject slotZip;
    public GameObject Val;

    public List<Cat> Cats;
    public List<GameObject> Slots;

    public Vector2 BasicPos;
    public Vector2 Margin;
    public Vector2 MaxLen;

    Animator ani;

    void Start()
    {
        if (instance == null)
            instance = this;
        ani = GetComponent<Animator>();
    }

    void Update() {
        if (instance == null)
            instance = this;
    }

    public void Open()
    {
        ani.SetBool("Open", !ani.GetBool("Open"));
        if (ani.GetBool("Open") == false)
            UserData.instance.UIopen = false;
    }

    public void SetCatList()
    {
        int cnt = 0;
        string data = PlayerPrefs.GetString("HaveCat");
        string[] list = data.Split(',');

        for (int j = 0; j < MaxLen.y; j++)
        {
            for (int i = 0; i < MaxLen.x; i++)
            {
                GameObject slotTmp = Instantiate(slot, slotZip.transform) as GameObject;
                slotTmp.transform.localPosition = new Vector3(BasicPos.x + Margin.x * i, BasicPos.y - Margin.y * j);
                CatSlot slotTarget = slotTmp.GetComponent<CatSlot>();
                slotTarget.slotNum = cnt;
                Slots.Add(slotTmp);
                ++cnt;
            }
        }

        if (data != "" && data != null)
        {
            print(data);
            for (int q = 0; q < list.Length; q++)
            {
                if(list[q] != "")
                AddCat(int.Parse(list[q]));
            }


            for (int k = 0; k < Cats.Count; k++)
            {
                Slots[k].GetComponent<CatSlot>().cat = Cats[k];
            }
        }
        else
        {
            print("qwe?");
            PlayerPrefs.SetString("HaveCat", "");
            AddCat(0);
        }

    }


    public void AddCat(int id)
    {
        Cat cat = CatDatabase.instance.FindCat(id);
        Cats.Add(new Cat(cat));
        SaveSlot();
    }

    public void AddCat(Cat i)
    {
        Cats.Add(new Cat(i));
        SaveSlot();
    }

    public void SaveSlot()
    {
        string asd = "";
        for (int i = 0; i < Cats.Count; i++)
        {
            asd += Cats[i].ID+",";
        }
        PlayerPrefs.SetString("HaveCat", asd);
        Val.GetComponent<Text>().text = Cats.Count+" / 12";
    }
}