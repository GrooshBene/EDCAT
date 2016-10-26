using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemInfo : MonoBehaviour {

    public Item item;

    public GameObject Name,Icon,Value,Content,Effect;
    public GameObject Wears, PutOffs;

	// Use this for initialization
	void Start () {
        print(UserData.instance.wearItem.Name);
        if (UserData.instance.wearItem.ID == item.ID)
        {
            print(UserData.instance.wearItem.Name);
            Wears.SetActive(false);
            PutOffs.SetActive(true);
        }
        else {
            print(item.ID);
            Wears.SetActive(true);
            PutOffs.SetActive(false);
        }
        SetInfo();

	}

    void OnEnable()
    {
        SetInfo();
    }

    void SetInfo() {
        Name.GetComponent<Text>().text = item.Name;
        Icon.GetComponent<Image>().sprite = item.Icon;
        Content.GetComponent<Text>().text = item.Content;
        Value.GetComponent<Text>().text = "x "+item.Value.ToString();
        Effect.GetComponent<Text>().text = "포획 확률 + "+ item.CatchPercent.ToString()+"%";
    }

    public void Wear() {
        UserData.instance.wearItem = item;
    }

    public void PutOff() {
        UserData.instance.wearItem = null;
    }

	
}
