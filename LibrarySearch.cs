using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LibrarySearch : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    Loadcsv csv;
    string path;
    int max;
    public List<string[]> ls;
    InfiniteScroll infiniteScroll; 
    ItemControllerLimited itemControllerLimited;
    void Start()
    {
        path=Helper.libcsv;
        csv=new Loadcsv();
        string text="";
        infiniteScroll=GameObject.Find("Scroll Content").GetComponent<InfiniteScroll>();
        itemControllerLimited=GameObject.Find("Scroll Content").GetComponent<ItemControllerLimited>();
        max=itemControllerLimited.max;
        try{
        ls=csv.loadcsv(path,text,ref max);
        Debug.Log(ls.Count);
        }
        catch{}
        //Debug.Log(ls.Count);
        
        /*if (ls.Count<infiniteScroll.instantateItemCount){
            infiniteScroll.instantateItemCount=ls.Count;
        }*/
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void search(){
        string text=inputField.text;
        //var ls=new List<string>();
        ls=csv.loadcsv(path,text,ref max);
        //Debug.Log(ls.Count);
        infiniteScroll.Searchresult();
        
    }


}
