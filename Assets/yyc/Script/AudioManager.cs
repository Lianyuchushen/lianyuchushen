using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class AudioManager : MonoBehaviour {

		public static string bgmPath = "Audio/BGM/";
		public static string touchtonePath = "Audio/Touchtone/";
		public static string voicePath = "Audio/Voice/";
		public static string soundEffectPath = "Audio/SoundEffect/"; 

		public static string currentBGMName = "bgm1";	// 当前BGM
		public static string currentTouchtoneName = "touchtone1";	// 当前按键音
		//public static string currentVoiceName;	// 当前语音
		//public static string currentSoundEffectName;	//当前其他音效

		public static bool bgmSwitch = true;	//	是否暂停BGM
		public static bool voiceSwitch = true;	//	是否暂停提示音

		//	BGM列表
		public static Dictionary <string, string> bgmList = new Dictionary <string, string> {
			{"bgm1", "bgm1"},
			{"bgm2", "bgm2"}, 
			{"bgm3", "bgm3"}
		};

		//	按键音列表
		public static Dictionary <string, string> touchtoneList = new Dictionary <string, string> {
			{"touchtone1", "touchtone1"}

		};

		//	提示音列表
		public static Dictionary <string, string> voiceList = new Dictionary <string, string> {
			{"voice1", "voice1"},
			{"voice2", "voice2"},
			{"voice3", "voice3"},
			{"voice4", "voice4"}
		};

		//	其他音效列表
		public static Dictionary<string, string> soundEffectList = new Dictionary <string, string> {
			{"sound1", "sound1"},
			{"sound2", "sound2"},
			{"sound3", "sound3"},
			{"sound4", "sound4"},
			{"sound5", "sound5"},
			{"sound6", "sound6"},
			{"sound7", "sound7"},
			{"sound8", "sound8"}
		};


		public static AudioSource currentBGM;
		public static AudioSource currentVoice;
		public static AudioSource currentTouchtone;
		public static AudioSource currentSoundEffect;

		public static float bgmVolume;
		public static float voiceVolume;

		void Start ()
		{
			currentBGM = GameObject.Find ("currentBGM").GetComponent<AudioSource> ();
			currentVoice = GameObject.Find("currentVoice").GetComponent<AudioSource> ();
			currentTouchtone = GameObject.Find("currentTouchtone").GetComponent<AudioSource> ();
			currentSoundEffect = GameObject.Find("currentSoundEffect").GetComponent<AudioSource> ();

			currentBGM.clip = Resources.Load <AudioClip>(bgmPath + bgmList[currentBGMName]);
			currentBGM.Play ();
		}

		/************************ Control BGM ************************/

		public static void PlayBGM ()
		{
			currentBGM.clip = Resources.Load <AudioClip>(bgmPath + bgmList[currentBGMName]);
			currentBGM.Play ();
		}

		public static void PauseBGM ()
		{
			
		}

		/************************************************/



		/************************ Control Voice ************************/

		public static void PlayVoice (string voiceName)
		{
			currentVoice.clip = Resources.Load <AudioClip>(voicePath + voiceList[voiceName]);
			currentVoice.Play ();	
		}

		public static void PauseVoice ()
		{
		}
			
		/************************************************/



		/************************ Control Touchtone ************************/

		public static void PlayTouchtone (string touchtoneName)
		{
			currentTouchtone.clip = Resources.Load <AudioClip>(touchtonePath + touchtoneList[touchtoneName]);
			currentTouchtone.Play ();	
		}

		/************************************************/



		/************************ Control SoundEffect ************************/

		public static void PlaySoundEffect (string soundEffectName)
		{
			currentSoundEffect.clip = Resources.Load <AudioClip>(soundEffectPath + soundEffectList[soundEffectName]);
			currentSoundEffect.Play ();	
		}

		/************************************************/

	}

