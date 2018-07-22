using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

public class screenshoting : MonoBehaviour {
    public Texture2D ScreenCap;
    bool shot = false;
    public Texture2D border;
    public Button btn;

	// Use this for initialization
	void Start () {
        //btn= 
        //  ScreenCap = new Texture2D(new Rect(200, 200,10,10);
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
        ScreenCap = new Texture2D(1900,900,TextureFormat.RGB24,false);
        border = new Texture2D(2,2 ,TextureFormat.ARGB32,false);
        border.Apply();
		
	}
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(2,2,1920,2),border,ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(2, 1080, 1920, 2), border, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(2, 2, 2,1080 ), border, ScaleMode.StretchToFill);
        GUI.DrawTexture(new Rect(1920, 2, 2, 1080), border, ScaleMode.StretchToFill);
        if (shot)
        {
            GUI.DrawTexture(new Rect(0, 0, 500, 300), ScreenCap, ScaleMode.StretchToFill);
            // new WaitForSeconds(2);

            // shot = false;
        }
            var imagebytes = ScreenCap.EncodeToPNG();
            var path = Application.dataPath + "/../screenshots/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var timestamp = DateTime.Now.ToString("yyyMMddHHmmssfff");
            File.WriteAllBytes(path, imagebytes);
        


    }

    // Update is called once per frame
    void Update () {
        /*  if (Input.GetKeyUp(KeyCode.Mouse0))
          {
              StartCoroutine("Capturing");

          }*/

        btn.onClick.AddListener(docapture);
		
	}
    void docapture()
    {
        StartCoroutine("Capturing");

    }
    
    IEnumerator Capturing()
    {
      // yield return  new  WaitForEndOfFrame();
        ScreenCap.ReadPixels(new Rect(3, 3, 1900, 900), 0, 0);
        ScreenCap.Apply();
       /* var imagebytes = ScreenCap.EncodeToPNG();
        var path = Application.dataPath + "/screenshots/";*/

        shot = true;
       
        

        yield return new WaitForSeconds(1);
        shot = false;
       
    }
}
