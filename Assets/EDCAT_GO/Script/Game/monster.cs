using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {

    public GameObject asd;

    public void set() {
        asd.SetActive(true);
        Invoke("actived", 5f);
    }

    void actived() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
