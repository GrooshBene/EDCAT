using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatchSlot : MonoBehaviour {

    public int slotNum;
    public Cat cat;
    Image img;
    Color[] colors = new Color[2]{new Color(0, 0, 0, 255),new Color(255, 255, 255, 255) };

    public GameObject Name;

    void Awake() {
        img = transform.GetChild(0).GetComponent<Image>();
    }

    void Start() {
        img.sprite = cat.Icon;
        Name.GetComponent<Text>().text = cat.Name;
    }

    void Update() {
        if (cat.Success)
        {
            img.color = colors[1];
        }
        else {
            img.color = colors[0];
        }
    }

    public void CatInfo()
    {
        if (cat.Success)
        {
            CatchCatList.instance.catInfo.SetActive(true);
            CatchCatList.instance.catInfo.GetComponent<CatInfo>().cat = cat;
        }
    }


}
