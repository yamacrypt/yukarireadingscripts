using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Seacher : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    Loadcsv csv;
    string path;
    public List<string[]> ls;
    int max;
    InfiniteScroll infiniteScroll; 
    ItemControllerLimited itemControllerLimited;
    void Start()
    {
        Debug.Log("load");
        var transition=GameObject.Find("Transition").GetComponent<Transition>();
        var statename=transition.GetState();
        //Debug.Log(statename);
        path=Helper.libcsv;
        if(statename=="dl"){
            path=Helper.dlcsv;
        }
        //SceneManager.sceneLoaded += OnSceneLoaded;
        //path=Helper.dlcsv;
        csv=new Loadcsv();
        string text="";
        itemControllerLimited=GameObject.Find("Scroll Content").GetComponent<ItemControllerLimited>();
        //max=itemControllerLimited.max;
        ls=csv.loadcsv(path,text,ref itemControllerLimited.max);
        //itemControllerLimited.max=max;
        infiniteScroll=GameObject.Find("Scroll Content").GetComponent<InfiniteScroll>();
      //  infiniteScroll.Searchresult();
    }

    public void search(){
        string text=inputField.text;
        if(text==null)
        text="";
        //var ls=new List<string>();
        ls=csv.loadcsv(path,text,ref itemControllerLimited.max);
        //Debug.Log(ls.Count);
        //Debug.Log(max);
        //itemControllerLimited.max=max;
        infiniteScroll.Searchresult();
    }

}
