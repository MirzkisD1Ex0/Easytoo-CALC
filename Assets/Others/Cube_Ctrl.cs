using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Ctrl : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private float tx = 0;
    private float ty = 0;
    private float index = 7;
    private float rx = 0;
    private float ry = 0;
    private float rz = 0;
    private float sx = 0;
    private float sy = 0;
    private float sz = 0;
    private bool minsx = false;
    private bool minsy = false;
    private bool minsz = false;
    private float sspeed = 0.2f;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Transform>().position = new Vector3(Random.Range(-45.0f, 45.0f), 110, 60);
	}
	
	// Update is called once per frame
	void Update () {
        index += Time.deltaTime;
        if (index>=7)
        {
            tx = Random.Range(-45.0f, 45.0f);
            ty = Random.Range(-95.0f, 95.0f);
            rx = Random.Range(0.0f, 360.0f);
            ry = Random.Range(0.0f, 360.0f);
            rz = Random.Range(0.0f, 360.0f);
            sx = Random.Range(0f, 10.0f);
            sy = Random.Range(0f, 10.0f);
            sz = Random.Range(0f, 10.0f);
            index = 0;
        }
        //gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        gameObject.GetComponent<Transform>().position = Vector3.SmoothDamp(gameObject.GetComponent<Transform>().position, new Vector3(tx, ty, 60), ref velocity, 3);
        gameObject.GetComponent<Transform>().rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(new Vector3(rx, ry, rz)), Time.deltaTime * 0.4f);

        if (gameObject.GetComponent<Transform>().localScale.x >= 10)
        {
            minsx = true;
        }
        if (gameObject.GetComponent<Transform>().localScale.x <= -10)
        {
            minsx = false;
        }
        if (minsx)
        {
            gameObject.GetComponent<Transform>().localScale -= new Vector3(sx, 0, 0) * Time.deltaTime * sspeed;
        }
        else
        {
            gameObject.GetComponent<Transform>().localScale += new Vector3(sx, 0, 0) * Time.deltaTime * sspeed;
        }

        if (gameObject.GetComponent<Transform>().localScale.y >= 10)
        {
            minsy = true;
        }
        if (gameObject.GetComponent<Transform>().localScale.y <= -10)
        {
            minsy = false;
        }
        if (minsy)
        {
            gameObject.GetComponent<Transform>().localScale -= new Vector3(0, sy, 0) * Time.deltaTime * sspeed;
        }
        else
        {
            gameObject.GetComponent<Transform>().localScale += new Vector3(0, sy, 0) * Time.deltaTime * sspeed;
        }

        if (gameObject.GetComponent<Transform>().localScale.z >= 10)
        {
            minsz = true;
        }
        if (gameObject.GetComponent<Transform>().localScale.z <= -10)
        {
            minsz = false;
        }
        if (minsz)
        {
            gameObject.GetComponent<Transform>().localScale -= new Vector3(0, 0, sz) * Time.deltaTime * sspeed;
        }
        else
        {
            gameObject.GetComponent<Transform>().localScale += new Vector3(0, 0, sz) * Time.deltaTime * sspeed;
        }
    }
}
