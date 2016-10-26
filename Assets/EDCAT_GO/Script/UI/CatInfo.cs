using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatInfo : MonoBehaviour
{

    public Cat cat;

    public GameObject Name;
    public GameObject Icon;
    public GameObject Value;
    public GameObject Content;

    public bool Have = false;

    void Start()
    {
        if (Have)
            SetInfoHave();
        else
            SetInfo();
    }

    void OnEnable() {
        if (Have)
            SetInfoHave();
        else
            SetInfo();
    }

    void SetInfoHave()
    {
        Name.GetComponent<Text>().text = cat.Name;
        Icon.GetComponent<Image>().sprite = cat.Icon;
        Content.GetComponent<Text>().text = cat.Content;
        Value.GetComponent<Text>().text = cat.Count.ToString();
    }

    void SetInfo()
    {
        Name.GetComponent<Text>().text = cat.Name;
        Icon.GetComponent<Image>().sprite = cat.Icon;
        Content.GetComponent<Text>().text = cat.Content;
    }

}
