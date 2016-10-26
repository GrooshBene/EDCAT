using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ARGrass : MonoBehaviour
{

    public static ARGrass argrass;

    public bool[] ck = new bool[2] { false, false };
    public bool success;
    Slider s;
    public Image grass;

    public Item item;

    void Start()
    {
        argrass = this;

        s = GetComponent<Slider>();
        s.value = 0.5f;

        if (UserData.instance.wearItem.Name == "")
        {
            item = ItemDatabase.instance.items[0];
            grass.sprite = item.Icon;
        }
        else
        {
            item = UserData.instance.wearItem;
            grass.sprite = UserData.instance.wearItem.Icon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CkShake();
    }

    void CkShake()
    {
        if (ck[0] == false && s.value < 0.4f)
        {
            ck[0] = true;
        }
        else if (ck[1] == false && s.value > 0.6f)
        {
            ck[1] = true;
        }
        else if (ck[0] && ck[1] && success == false)
        {
            GameManager.instance.AR = null;
            success = true;
            ARCat.arcat.StartCoroutine("Catching");
        }
    }
}
