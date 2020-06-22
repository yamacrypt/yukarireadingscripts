using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    public InputField inputField;
     public Text text;
 
    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start() {
 
        //inputField = GetComponent<InputField>();
        //text = text.GetComponent<Text> ();
        InitInputField();
    }
    /*public void InputLogger() {
 
        string inputValue = inputField.text;
 
        Debug.Log(inputValue);
 
        InitInputField();
    }*/
    public void InputText(){
                //テキストにinputFieldの内容を反映
         text.text = inputField.text;

     }

    void InitInputField() {
 
        // 値をリセット
        inputField.text = "";
        Debug.Log("Init");
        // フォーカス
        inputField.ActivateInputField();
    }
}
