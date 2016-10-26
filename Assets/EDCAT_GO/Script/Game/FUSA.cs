using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using Facebook.Unity;

public class FUSA : MonoBehaviour {

    public static FUSA instance;

    Texture2D profilePic;

    // Use this for initialization
    void Start () {
        instance = this;
    }


    public void Btn() {
        FB.API("/me/picture?redirect=false", HttpMethod.GET, ProfilePhotoCallback);
        FB.API("/me?fields=id,name", HttpMethod.GET, DealWithUserName);
    }


    private void ProfilePhotoCallback(IGraphResult result)
    {
        print("asdfqq");
        if (string.IsNullOrEmpty(result.Error) && !result.Cancelled)
        {
            print("asdfww");
            IDictionary data = result.ResultDictionary["data"] as IDictionary;
            string photoURL = (string)data["url"];

            StartCoroutine(fetchProfilePic(photoURL));
        }
    }

    void DealWithUserName(IGraphResult result)
    {
        if (result.Error != null)
        {
            Debug.Log("problem with getting user name");
            FB.API("/me?field=id,name", HttpMethod.GET, DealWithUserName);
            return;
        }

        LitJson.JsonData get = LitJson.JsonMapper.ToObject(result.RawResult);
        print(result.RawResult);
        print(get["name"]);
        
    }

    private IEnumerator fetchProfilePic(string url)
    {
        print("asdf");
        WWW www = new WWW(url);
        yield return www;
        this.profilePic = www.texture;
        GetComponent<Renderer>().material.mainTexture = www.texture;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
