using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace yyc
{

	public class SceneLoader : MonoBehaviour {

		public static int level;
		public Slider sliderBar;
		private float progress;

		public GameObject loadingScene;
		public GameObject uiMaskCanvas;
		public float uiFadeSpeed = 1.4f;

		/******************** LoadScene 1,2,4,5  ********************/

		public void LoadScene_1 ()	//Loading MatchTraining_Same_basic
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 1;
			LoadChoosedScene ("Game 001");
		}

		public void LoadScene_2 ()	//loading MatchTraining_Same_intermediate
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 2;
			LoadChoosedScene ("Game 001");
		}

		public void LoadScene_4 ()	//loading MatchTraining_Difference_basic
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 4;
			LoadChoosedScene ("Game 001");
		}

		public void LoadScene_5 ()	//loading MatchTraining_Difference_intermediate
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 5;
			LoadChoosedScene ("Game 001");
		}

		/**************************************************/

		/******************** LoadScene 3,6  ********************/

		public void LoadScene_3 ()	//Loading MatchTraining_Same_advanced
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 3;
			LoadChoosedScene ("Game 002");
		}

		public void LoadScene_6 ()	//Loading MatchTraining_Difference_advanced
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 6;
			LoadChoosedScene ("Game 002");
		}

		/**************************************************/

		/******************** LoadScene 7,8,9  ********************/

		public void LoadScene_7 ()	//Loading PerceptionTraining_primer
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 7;
			LoadChoosedScene ("Game 003");
		}

		public void LoadScene_8 ()	//Loading PerceptionTraining_basic
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 8;
			LoadChoosedScene ("Game 003");
		}

		public void LoadScene_9 ()	//Loading PerceptionTraining_intermediate
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 9;
			LoadChoosedScene ("Game 003");
		}

		/**************************************************/

		/******************** LoadScene 11,12,13  ********************/

		public void LoadScene_11 ()	//Loading ExpressionTraining_basic
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 11;
			LoadChoosedScene ("Game 004");
		}

		public void LoadScene_12 ()	//Loading ExpressionTraining_intermediate
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 12;
			LoadChoosedScene ("Game 004");
		}

		public void LoadScene_13 ()	//Loading ExpressionTraining_advanced
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			level = 13;
			LoadChoosedScene ("Game 004");
		}

		/**************************************************/

		

		void LoadChoosedScene(string sceneName)
		{
			uiMaskCanvas.SetActive (true);
			loadingScene.SetActive (true);
			StartCoroutine (LoadScene (sceneName));
		}

		IEnumerator LoadScene (string sceneName)
		{
			// cover ui
			for (float i = 0; i < 1; i += Time.deltaTime * uiFadeSpeed) 
			{
				uiMaskCanvas.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

			// fade in loading ui
			for (float i = 0; i < 1; i += Time.deltaTime * uiFadeSpeed) 
			{
				loadingScene.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

			AsyncOperation async = SceneManager.LoadSceneAsync (sceneName);

			while (!async.isDone) 
			{
				progress = Mathf.Clamp01 (async.progress);
				sliderBar.value = progress;
				yield return null;
			}

		}
	}

}
