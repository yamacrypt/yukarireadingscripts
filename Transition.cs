using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Transition : MonoBehaviour
{
    //public Button toDL;
        // Use this for initialization
     public  Canvas searchCanvas;
     public  Canvas libraryCanvas;
     public  Canvas settingCanvas;
    private string state="library";
    public string GetState(){
        return state;
    }
        public void ChangeDL()
        {
            state="dl";
            //SceneManager.LoadScene("DL");
            searchCanvas.gameObject.SetActive(true);
            libraryCanvas.gameObject.SetActive(false);
            settingCanvas.gameObject.SetActive(false);
        }
        public void ChangeLibrary()
        {
            state="library";
            libraryCanvas.gameObject.SetActive(true);
            searchCanvas.gameObject.SetActive(false);
            settingCanvas.gameObject.SetActive(false);
        }
         public void ChangeSetting()
        {
            state="setting";
           settingCanvas.gameObject.SetActive(true);
            libraryCanvas.gameObject.SetActive(false);
            searchCanvas.gameObject.SetActive(false);
        }
}
