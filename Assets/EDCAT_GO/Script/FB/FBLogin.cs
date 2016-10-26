using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Facebook.Unity;
using UnityEngine.SceneManagement;
using System.Collections;

public class FBLogin : MonoBehaviour {

    public static FBLogin instance;

    public GameObject DialogLoggedIn;
    public GameObject DialogLoggedOut;
    public string UserName;
    public Sprite Profile_Pic;

    void Awake() {
        instance = this;
        FB.Init(SetInit, OnHideUnity);
    }

    void SetInit() {
        if (FB.IsLoggedIn)
        {
            print("FB is logged in");
        }
        else {
            print("FB is not logged in");
        }

        DealWithFBMenus(FB.IsLoggedIn);
    }

    void OnHideUnity(bool isGameShown) {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    public void FBlogin() {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);
    }

    void AuthCallBack(IResult res) {
        if (res.Error != null)
        {
            print(res.Error);
        }
        else {
            if (FB.IsLoggedIn)
            {
                if (PlayerPrefs.GetString("token") == null || PlayerPrefs.GetString("token") == "")
                {
                    print("FB is logged in!!");
                    //토큰 을 전달합니다.
                    string url = "http://kafuuchino.one:7070/auth/facebook/token?access_token=" + AccessToken.CurrentAccessToken.TokenString;
                    WWW www = new WWW(url);
                    PlayerPrefs.SetString("token", AccessToken.CurrentAccessToken.TokenString);
                    print("token is  : " + AccessToken.CurrentAccessToken.TokenString);
                }
                else if (PlayerPrefs.GetString("token") != "")
                {
                    print("FB is logged in 2");
                    //토큰 을 전달합니다.
                    string url = "http://kafuuchino.one:7070/auth/facebook/token?access_token=" + PlayerPrefs.GetString("token");
                    WWW www = new WWW(url);
                    print("token2 is  : " + AccessToken.CurrentAccessToken.TokenString);
                }
            }
            else
            {
                print("FB is not logged in");
            }
            DealWithFBMenus(FB.IsLoggedIn);
        }
    }

    void DealWithFBMenus(bool isLoggedIn) {
        if (isLoggedIn)
        {
            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);
            FB.API("/me?fields=name", HttpMethod.GET, DisplayUsername);
            FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
        }
        else {
            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);
        }
    }

    void DisplayUsername(IResult res) {
        if (res.Error == null)
        {
            UserName = res.ResultDictionary["name"].ToString();
        }
        else {
            print(res.Error);
        }
    }

    void DisplayProfilePic(IGraphResult res) {
        if (res.Texture != null) {
            Profile_Pic = Sprite.Create(res.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
    }

    public void MainSC() {
        SceneManager.LoadScene("Main");
    }

}
