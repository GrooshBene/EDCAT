using UnityEngine;
using System.Collections.Generic;

public class CatchCatList : MonoBehaviour
{

    public static CatchCatList instance;

    public GameObject slot;
    public GameObject catInfo;
    public GameObject slotZip;

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
        DontDestroyOnLoad(gameObject);
    }

    public void Open()
    {
        ani.SetBool("Open", !ani.GetBool("Open"));
        if (ani.GetBool("Open"))
            SetCatList();
        else
            UserData.instance.UIopen = false;
    }

    void SetCatList()
    {
        int cnt = 0;
        for (int j = 0; j < MaxLen.y; j++)
        {
            for (int i = 0; i < MaxLen.x; i++)
            {
                GameObject slotTmp = Instantiate(slot, slotZip.transform) as GameObject;
                slotTmp.transform.localPosition = new Vector3(BasicPos.x + Margin.x * i, BasicPos.y - Margin.y * j);
                CatchSlot slotTarget = slotTmp.GetComponent<CatchSlot>();
                slotTarget.slotNum = cnt;
                slotTarget.cat = CatDatabase.instance.cats[cnt];
                Slots.Add(slotTmp);
                ++cnt;
            }
        }
    }
}
