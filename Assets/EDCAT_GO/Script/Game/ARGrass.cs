using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ARGrass : MonoBehaviour
{

    public static ARGrass argrass;

    public int[] ck = new int[2] { 0, 0};
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
        if (s.value < 0.4f)
        {
			ck [0] = Random.Range (0, 3);
			print (ck [0]);
        }
        else if (s.value > 0.6f)
        {
			ck [1] = Random.Range (0, 3);
			print (ck [1]);
        }
		else if (ck[0]==1 && ck[1]==1 && success == true)
        {
            success = true;
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        }
    }
}
