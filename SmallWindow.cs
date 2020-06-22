using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallWindow : MonoBehaviour
{
    public Image image;
    //AudioController audioController;
    //public Button playbutton;
     //public Button backbutton;
    // Start is called before the first frame update
    public void  ShowWindow(string name){
        image.gameObject.SetActive(true);
        var text=image.GetComponentInChildren<Text>();
        text.text=name;
    }
    

}
