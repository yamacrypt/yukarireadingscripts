using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
public class Item : UIBehaviour 
{

	[SerializeField]
	Button button;
	[SerializeField]
	Text text;
	Seacher sc;
	private int index=0;
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
		//Debug.Log(count);
		try{
			//Debug.Log(sc.ls[count]);
			text.text=sc.ls[count][title]+"\n"+sc.ls[count][author];
		}
		catch {
			text.text=count.ToString();
		}
		//uiText.text = (count + 1).ToString("00");
		//uiBackground.color = colors[Mathf.Abs(count) % colors.Length];
		//uiIcon.sprite = Resources.Load<Sprite>((Mathf.Abs(count) % 30 + 1).ToString("icon000"));
	}

		
	public void OnClickButton() {
		string path=Helper.dlpath;
		int len=sc.ls[index].Length;	
		try{
		string fullpath=path+sc.ls[index][len-1]+".txt";
		string libpath=Helper.libpath+sc.ls[index][len-1]+".txt";
		File.Copy(fullpath,libpath);
		using (var sw = new StreamWriter(Helper.libcsv,true))
        {
                sw.WriteLine(string.Join(",",sc.ls[index]));

        }
		}
		catch{}
		//　ボタンの文字列に応じて書き換える
		//buttonText.text = (buttonText.text == "test1") ? "test2" : "test1"; 
	}
}
