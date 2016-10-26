using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatSlot : MonoBehaviour {

    public int slotNum;
    public Cat cat;
    public Sprite asd;

    void Update()
    {
        if (HaveCatList.instance.Cats.Count > slotNum)
        {
            cat = HaveCatList.instance.Cats[slotNum];
            transform.GetChild(1).GetComponent<Text>().text = cat.Name;
            transform.GetChild(0).GetComponent<Image>().sprite = cat.Icon;
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = asd;
            transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    public void CatInfo()
    {
        if (HaveCatList.instance.Cats.Count > slotNum)
        {
            HaveCatList.instance.catInfo.SetActive(true);
            HaveCatList.instance.catInfo.GetComponent<CatInfo>().cat = cat;
        }
    }
}
