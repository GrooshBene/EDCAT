using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;

    public GameObject slot;
    public GameObject itemInfo;
    public GameObject slotZip;

    public List<Item> Items;
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

    public void Open()
    {
        ani.SetBool("Open", !ani.GetBool("Open"));
        if (ani.GetBool("Open"))
            SetInven();
        else
            UserData.instance.UIopen = false;
    }

    void SetInven()
    {
        int cnt = 0;
        string data = PlayerPrefs.GetString("Inven");
        string[] inves = data.Split(',');

        for (int j = 0; j < MaxLen.y; j++)
        {
            for (int i = 0; i < MaxLen.x; i++)
            {
                GameObject slotTmp = Instantiate(slot, slotZip.transform) as GameObject;
                slotTmp.transform.localPosition = new Vector3(BasicPos.x + Margin.x * i, BasicPos.y - Margin.y * j);
                ItemSlot slotTarget = slotTmp.GetComponent<ItemSlot>();
                slotTarget.slotNum = cnt;
                Slots.Add(slotTmp);
                ++cnt;
            }
        }

        if (data != "" && data != null)
        {
            print(data);
            Items.Clear();
            for (int q = 0; q < inves.Length; q++)
            {
                string[] res = inves[q].Split('|');
                if (res.Length == 2)
                {
                    for (int b = 0; b < int.Parse(res[1]); b++)
                    {
                        AddItem(int.Parse(res[0]));
                    }
                }
            }
            for (int k = 0; k < Items.Count; k++)
            {
                Slots[k].GetComponent<ItemSlot>().item = Items[k];
            }
        }
        else
        {
            print("qwe?");
            PlayerPrefs.SetString("Inven", "");
            AddItem(0);
            AddItem(0);
            AddItem(0);
        }

    }

    public void AddItem(int id)
    {
        Item item = ItemDatabase.instance.Find(id);
        if (SortItem(id) == false)
        {
            print("add");
            Items.Add(new Item(item));
        }
        SaveSlot();
    }

    public void AddItem(Item i)
    {
        if (SortItem(i.ID) == false)
        {
            Items.Add(new Item(i));
        }
        SaveSlot();
    }

    public bool SortItem(int id)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].ID == id)
            {
                Items[i].Value += 1;
                return true;
            }
        }
        return false;
    }

    public void SaveSlot()
    {
        string asd = "";
        for (int i = 0; i < Items.Count; i++)
        {
            asd += Items[i].ID + "|" + Items[i].Value + ",";
        }
        PlayerPrefs.SetString("Inven", asd);
    }
}
