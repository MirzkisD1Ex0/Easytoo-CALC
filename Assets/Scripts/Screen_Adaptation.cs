using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_Adaptation : MonoBehaviour {

    public GameObject calcui;
    public GameObject decbar;
    public GameObject bgis;
    public GameObject panel;
    public GameObject button;
    public GameObject error;
    private int width = 0;
    private int height = 0;
    public float index = 0;
    public bool indexstart = true;
    private bool err = false;

	// Use this for initialization
	void Start () {
        width = Screen.width;
        height = Screen.height;
        Check();

        Debug.Log(width);
        Debug.Log(height);
    }
    
    void Update()
    {
        if (err)
        {
            error.GetComponent<Text>().color = new Color(255, 0, 0, index);
            if (indexstart)
            {
                index += Time.deltaTime;
                if (index >= 1)
                    indexstart = false;

            }
            else
            {
                index -= Time.deltaTime;
                if (index <= 0)
                    indexstart = true;
            }
        }
        

        //if (!hero && !bgm_died_bool)
        //{
        //    self.GetComponent<AudioSource>().Play();
        //    bgm_died_bool = true;
        //}
    }

    void puls()
    {
        while (index <= 155)
        {
            index += Time.deltaTime / 2;
        }
    }

    void Check()
    {
        //1440x2560适配
        if (width == 1440 && height == 2560)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 10.8f;
            decbar.SetActive(false);
            bgis.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 0.8f);
            return;
        }

        //1080x2340适配
        if (width == 1080 && height == 2340)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 9f;
            panel.GetComponent<RectTransform>().localPosition = new Vector3(0, 10, 0);
            button.GetComponent<RectTransform>().localPosition = new Vector3(0, -13, 0);
            return;
        }

        //1080x2160适配
        if (width == 1080 && height == 2160)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 9f;
            return;
        }

        //1080x1920适配
        if (width == 1080 && height == 1920)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 8.3f;
            decbar.SetActive(false);
            bgis.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            return;
        }

        //720x1280适配
        if (width == 720 && height == 1280)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 5.6f;
            decbar.SetActive(false);
            bgis.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            return;
        }

        //分辨率<720p适配
        if (width < 720 || height < 1280)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 3.3f;
            decbar.SetActive(false);
            bgis.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            err = true;
            return;
        }

        //分辨率>2k适配
        if (width > 1440 || height > 2560)
        {
            calcui.GetComponent<Canvas>().scaleFactor = 16.7f;
            decbar.SetActive(false);
            bgis.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
            err = true;
            return;
        }

        //介于2k与720p适配
        if ((width < 1440 && width > 720) || (height > 1280 && height < 2560))
        {
            calcui.GetComponent<Canvas>().scaleFactor = 8f;
            decbar.SetActive(false);
            bgis.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            err = true;
        }
    }
}
