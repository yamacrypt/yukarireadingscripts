using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
public class LibItem : UIBehaviour 
{

	[SerializeField]
	Button button;
	[SerializeField]
	Text text;
	Seacher sc;
    string link;
	private int index=0;
     string showname;
	private readonly Color[] colors = new Color[] {
		new Color(1, 1, 1, 1),
		new Color(0.9f, 0.9f, 1, 1),
	};
	protected override void  Awake(){
		sc=GameObject.Find("EventSystem").GetComponent<Seacher>();
	}
	protected override void  Start(){
        
		button.onClick.AddListener (OnClickButton);
	}
	static int title=0;
	static int author=2;
	public void UpdateItem(int count) 
	{
		index=count;
        showname=sc.ls[count][title]+"\n"+sc.ls[count][author];
		//Debug.Log(count);
		try{
			//Debug.Log(sc.ls[count]);
			text.text=showname;
		}
		catch {
			text.text=count.ToString();
		}
        link=@"/home/ryota/ミュージック/音声.mp3";
		//uiText.text = (count + 1).ToString("00");
		//uiBackground.color = colors[Mathf.Abs(count) % colors.Length];
		//uiIcon.sprite = Resources.Load<Sprite>((Mathf.Abs(count) % 30 + 1).ToString("icon000"));
	}


	public void OnClickButton() {
        
        //WWW www = new WWW(path);
       // Debug.Log(link);
        var audiocontroller=GameObject.Find("Audio Source").GetComponent<AudioController>();
		StartCoroutine(audiocontroller.PlayOnClicked(link));
        var smallwindow=GameObject.Find("EventSystem").GetComponent<SmallWindow>();
        smallwindow.ShowWindow(showname);
        /*string path=@"/media/ryota/HDD/completedbooks/";
		int len=sc.ls[index].Length;	
		string fullpath=path+sc.ls[index][len-1]+".txt";
		string libpath=Helper.libpath+sc.ls[index][len-1]+".txt";
		try{
		File.Copy(fullpath,libpath);
		using (var sw = new StreamWriter(Helper.libcsv,true))
        {
                sw.WriteLine(string.Join(",",sc.ls[index]));

        }
		}
		catch{}*/
		//　ボタンの文字列に応じて書き換える
		//buttonText.text = (buttonText.text == "test1") ? "test2" : "test1"; 
	}
}
