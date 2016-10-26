using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ARCat : MonoBehaviour
{

    public static ARCat arcat;


    public Slider s;
    public GameObject o, x;
    public Cat cat;


    SpriteRenderer spr;

    void Start()
    {
        arcat = this;
        spr = GetComponent<SpriteRenderer>();
        cat = GameManager.instance.AR;
        spr.sprite = cat.Img;
    }


    public void Fail()
    {
        print("Remove");
        x.SetActive(true);
        UserData.instance.UpdateCatchCnt(false);
        Invoke("MainGo", 2f);
    }


    public IEnumerator Catching()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(2f);
            int rand = Random.Range(0, 100);
            if (cat.Percent+ARGrass.argrass.item.CatchPercent >= rand)
            {
                //success
                s.value += 0.2f;
            }
        }
        //s.value = 1;
        if (s.value == 1)
        {
            s.gameObject.SetActive(false);
            o.SetActive(true);
            GameManager.instance.Catchs = cat;
            UserData.instance.UpdateCatchCnt(true);
            CatDatabase.instance.cats[cat.ID].Count += 1;
            CatDatabase.instance.SetCatSuccess(cat.ID);
           
            //HaveCatList.instance.AddCat(cat.ID);

            
            /*
            //www 고양이 포인트 증가
            string url = "http://kafuuchino.one:7070/user/addexp";
            WWWForm form = new WWWForm();
            form.AddField("exp", cat.Point);
            form.AddField("id", PlayerPrefs.GetString("token"));
            WWW www = new WWW(url, form);
            */
            Invoke("MainGo", 1f);
        }
        else {
            s.gameObject.SetActive(false);
            o.SetActive(false);
            Fail();
        }

    }

    public void MainGo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }



}
