using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotSpotInfo : MonoBehaviour
{

    public GameObject Name;
    public GameObject Icon;
    public GameObject Content;
    public GameObject Time;
    public GameObject Gift;

    public HotSpot h;

    public void SetData()
    {
        Name.GetComponent<Text>().text = h.Name;
        Icon.GetComponent<Image>().sprite = h.Icon;
        Content.GetComponent<Text>().text = h.Content;
    }

    public void GetItem()
    {
        Inventory.instance.AddItem(Random.Range(0,ItemDatabase.instance.items.Count));
        HotSpotDatabase.instance.ResetGetItem(h.ID);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (h.GetItem)
        {
            Gift.SetActive(true);
            Time.SetActive(false);
        }
        else
        {
            if (Gift.activeSelf == true)
            {
                Gift.SetActive(false);
                Time.SetActive(true);
            }
            Time.GetComponent<Text>().text = ((int)(h.Time/60)) + " : " + (h.Time%60);
        }

    }
}
