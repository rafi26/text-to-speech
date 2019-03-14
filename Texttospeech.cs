using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Texttospeech : MonoBehaviour {
	
	public Animator animator;

	public Transform fimale3;

	public AudioSource _audio;

	public AudioClip klip; 

	public float panjangklip;

	public InputField inputText;


	void Start () {
		_audio = gameObject.GetComponent<AudioSource> ();
		animator = fimale3.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		

	}

	IEnumerator DownloadTheAudio () {

		string url = "http://arbihaza.com/student/rafi/api.php/?sl=id&tl=en&s="+inputText.text;
		WWW www = new WWW (url);
		yield return www;

		string url2 = "http://arbihaza.com/student/rafi/test.mp3";
		WWW www2 = new WWW (url2);
		yield return www2;

		_audio.clip = www2.GetAudioClip (false, true, AudioType.MPEG);
		panjangklip = _audio.clip.length;  
		_audio.Play ();



		GetComponent<Animator>().Play("FimaleAction_001");
		animator = gameObject.GetComponent<Animator>();
		animator.Play ("FimaleAction_001");

	
		//animationplay
		//masukkan kodingan memplay animasi

	}
	public void ButtonClick() 
	{
		

		StartCoroutine (DownloadTheAudio ());
		//animator.Play ("FimaleAction_001",-1,0f);
		nunggump3selesai (panjangklip);
	}


	public IEnumerator nunggump3selesai(float waktu){
	
		yield return new WaitForSeconds (waktu);
		StopCoroutine (DownloadTheAudio ());
		animator.Play ("PoseLib");

		//animator.StopPlayback();
		//animator.Play ("NewState", -1,0f);
		//animator.Play ("PoseLib", 1,0f);


		//animationstop;
		//masukkan kodingan stop animasi

	}
}
