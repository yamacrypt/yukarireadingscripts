using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
public class SpeedItem : UIBehaviour 
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
	protected override void  Start(){
        
		button.onClick.AddListener (OnClickButton);
	}
	static int title=0;
	static int author=2;
	public void UpdateItem(int count) 
	{
		index=count;
        double speed=0.9+(double)index*0.1f;
        text.text=speed.ToString()+"x";
		//uiText.text = (count + 1).ToString("00");
		//uiBackground.color = colors[Mathf.Abs(count) % colors.Length];
		//uiIcon.sprite = Resources.Load<Sprite>((Mathf.Abs(count) % 30 + 1).ToString("icon000"));
	}


	public void OnClickButton() {

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
