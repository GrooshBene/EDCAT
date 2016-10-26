using UnityEngine;
using System.Collections;

public class WebViews : MonoBehaviour {

    private WebViewObject webViewObject;

    // Update is called once per frame
    void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.GetKey(KeyCode.Escape))
            {
                Destroy(webViewObject);
                return;
            }
        }

    }

    public void StartWebView()
    {
        string strUrl = "http://www.fb.com";

        webViewObject =
            (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(string.Format("CallFromJS[{0}]", msg));
        });

        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(100, 100, 100, 100);
    }
}
