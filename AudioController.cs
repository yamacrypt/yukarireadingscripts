using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Networking;

public class AudioController : MonoBehaviour
{
       AudioSource audioSource;
       public AudioMixer am;
       int backtime;
      // public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {

        backtime=30;
        audioSource = GetComponent<AudioSource>();
        
    }
    public  IEnumerator PlayOnClicked(string audiofile){
       string soundPath="file://" /*+ Application.persistentDataPath*/+ audiofile;
     /* using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(soundPath, AudioType.MPEG))
        {
            Debug.Log("ok");
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioSource.clip= DownloadHandlerAudioClip.GetContent(www);
            }
        } */
         WWW www;           
        www = new WWW(soundPath);  

        yield return www;

        if (www != null && www.isDone)
        {
            //Debug.Log("ok");
            audioSource.clip = www.GetAudioClip(true, false, AudioType.MPEG);
            audioSource.Play();
        }
        
    }
    public void PlayorPauseonclicked(){
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else{
            audioSource.UnPause();
        }
    }
    
    public void BackOnClicked(){
        if(audioSource.time>=backtime){
            audioSource.time-=backtime;
        }
        else{
            audioSource.time=0;
        }
    }

    public void ChangeSpeed(){
        float speed=2.0f;
        float pitchshift=1.0f/speed;
        am.SetFloat("MyExposedParam",pitchshift);
        audioSource.pitch=speed;
        //m
        //audioSource.shi
    }
}