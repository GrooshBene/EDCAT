using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class slidervalue : MonoBehaviour {

    public Text slidervalues;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        slidervalues.text = GetComponent<Slider>().value.ToString();
	}
}
