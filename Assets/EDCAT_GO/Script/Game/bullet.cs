using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{

    Vector3 oldpos;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != oldpos)
        {
            //print(oldpos + " : " + transform.position);
            oldpos = transform.position;
        }
        transform.Translate(Vector3.forward * 500f * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "aa")
        {
            print("pung");
            col.transform.parent.gameObject.SetActive(false);
            col.transform.parent.gameObject.GetComponent<monster>().set();
            Destroy(this.gameObject);
        }
    }


}
