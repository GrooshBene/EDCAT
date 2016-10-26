using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlot : MonoBehaviour
{

    public int slotNum = 1000;
    public Item item;

    void Update()
    {
        if (Inventory.instance.Items.Count > slotNum)
        {
            item = Inventory.instance.Items[slotNum];
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item.Icon;
            transform.GetChild(1).GetComponent<Text>().text = item.Value.ToString();
        }
        else
        {
            transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
            transform.GetChild(1).GetComponent<Text>().text = "";
        }
    }

    public void ItemInfo()
    {
        Inventory.instance.itemInfo.SetActive(true);
        Inventory.instance.itemInfo.GetComponent<ItemInfo>().item = item;
    }

}
