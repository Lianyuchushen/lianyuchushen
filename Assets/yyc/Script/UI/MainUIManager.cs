using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
	public class MainUIManager : MonoBehaviour {

		#region Variables
		public float fadeSpeed = 1.4f;
		public Canvas MainMenu;
		public Canvas PersonalData;
		public Canvas GameSetting;

		public Canvas GameModeChoose;
		public Canvas LinearGame;
		public Canvas SemiOpenGame;

        public Canvas LG_Adventure_Mode_Level_Choose;
        /*
        public Canvas LG_Adventure_Mode;
		public Canvas LG_Match_Mode;
		public Canvas LG_Perception_Mode;
		public Canvas LG_Expression_Mode;
        */

        public Canvas LG_Custom_Mode;
        public Canvas LG_Level_Creator;
        public Canvas LG_Choose_Custom_Game;

		public GameObject childContentPort;
		public GameObject addChildButton;
		public GameObject childData;
		public List<GameObject> childList;
		public int childListLength = 0;
		public GameObject childListContent;

		public GameObject CustomImageManager;
		public GameObject CustomImageBrowser;
		public GameObject SuccesslyImportImage_Popup_CIB;	// Successly Import Image Popup int Custom Image Browser 
		public CustomImageManager CustomImageController;
		#endregion

		#region uiFadeOut uiFadeIn prototype
		/******************** uiFadeOut prototype ********************/
		/*
		private void uiFadeIn (Canvas canvasUi)
		{
			canvasUi.GetComponent<CanvasGroup> ().alpha = 0;
			canvasUi.gameObject.SetActive (true);
			StartCoroutine (ieUiFadeIn (canvasUi));
		}

		IEnumerator ieUiFadeIn (Canvas canvasUi)
		{
			for (float i = 0; i <= 1; i += Time.deltaTime) 
			{
				canvasUi.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
		}
		*/
		/**************************************************/

		/******************** uiFadeIn prototype ********************/
		/*
		private void uiFadeOut (Canvas canvasUi)
		{
			StartCoroutine (ieUiFadeOut(canvasUi));
		}

		IEnumerator ieUiFadeOut (Canvas canvasUi)
		{
			for(float i = 1; i >= 0; i -= Time.deltaTime)
			{
				canvasUi.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			canvasUi.gameObject.SetActive(false);
		}
		*/
		/**************************************************/
		#endregion

		#region MainMenu and GameModeChoose
		/******************** MainMenu To GameModeChoose ********************/
		public void MainMenu_To_GameModeChoose ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(MM_To_GMC());
		}

		IEnumerator MM_To_GMC ()
		{
			//	fade out MainMenu UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				MainMenu.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			MainMenu.gameObject.SetActive(false);

			//	fade in GameModeChoose UI
			GameModeChoose.GetComponent<CanvasGroup> ().alpha = 0;
			GameModeChoose.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				GameModeChoose.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** GameModeChoose To MainMenu ********************/
		public void GameModeChoose_To_MainMenu ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(GMC_To_MM());
		}

		IEnumerator GMC_To_MM ()
		{
			//	fade out GameModeChoose UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				GameModeChoose.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			GameModeChoose.gameObject.SetActive(false);

			//	fade in MainMenu UI
			MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
			MainMenu.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				MainMenu.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region GameModeChoose and LinearGame
		/******************** GameModeChoose To LinearGame ********************/
		public void GameModeChoose_To_LinearGame ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(GMC_To_LG());
		}

		IEnumerator GMC_To_LG ()
		{
			//	fade out GameModeChoose UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				GameModeChoose.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			GameModeChoose.gameObject.SetActive(false);

			//	fade in LinearGame UI
			LinearGame.GetComponent<CanvasGroup> ().alpha = 0;
			LinearGame.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				LinearGame.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** LinearGame To GameModeChoose  ********************/
		public void LinearGame_To_GameModeChoose ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(LG_To_GMC());
		}

		IEnumerator LG_To_GMC ()
		{
			//	fade out LinearGame UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				LinearGame.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			LinearGame.gameObject.SetActive(false);

			//	fade in GameModeChoose UI
			GameModeChoose.GetComponent<CanvasGroup> ().alpha = 0;
			GameModeChoose.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				GameModeChoose.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region GameModeChoose and SemiOpenGame
		/******************** GameModeChoose To SemiOpenGame  ********************/
		public void GameModeChoose_To_SemiOpenGame ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(GMC_To_SOG());
		}

		IEnumerator GMC_To_SOG ()
		{
			//	fade out GameModeChoose UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				GameModeChoose.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			GameModeChoose.gameObject.SetActive(false);

			//	fade in SemiOpenGame UI
			SemiOpenGame.GetComponent<CanvasGroup> ().alpha = 0;
			SemiOpenGame.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				SemiOpenGame.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** SemiOpenGame To GameModeChoose  ********************/
		public void SemiOpenGame_To_GameModeChoose ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(SOG_To_GMC());
		}

		IEnumerator SOG_To_GMC ()
		{
			//	fade out SemiOpenGame UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				SemiOpenGame.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			SemiOpenGame.gameObject.SetActive(false);

			//	fade in GameModeChoose UI
			GameModeChoose.GetComponent<CanvasGroup> ().alpha = 0;
			GameModeChoose.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				GameModeChoose.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region MainMenu and GameSetting
		/******************** MainMenu To GameSetting  ********************/
		public void MainMenu_To_GameSetting ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(MM_To_GS());
		}

		IEnumerator MM_To_GS ()
		{
			//	fade out MainMenu UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				MainMenu.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			MainMenu.gameObject.SetActive(false);

			//	fade in GameSetting UI
			GameSetting.GetComponent<CanvasGroup> ().alpha = 0;
			GameSetting.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				GameSetting.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** GameSetting To MainMenu  ********************/
		public void GameSetting_To_MainMenu ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(GS_To_MM());
		}

		IEnumerator GS_To_MM ()
		{
			//	fade out GameSetting UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				GameSetting.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			GameSetting.gameObject.SetActive(false);

			//	fade in MainMenu UI
			MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
			MainMenu.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				MainMenu.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region MainMenu and PersonalData
		/******************** MainMenu To PersonalData  ********************/
		public void MainMenu_To_PersonalData ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(MM_To_PD());
		}

		IEnumerator MM_To_PD ()
		{
			//	fade out MainMenu UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				MainMenu.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			MainMenu.gameObject.SetActive(false);

			//	fade in PersonalData UI
			PersonalData.GetComponent<CanvasGroup> ().alpha = 0;
			PersonalData.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				PersonalData.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** PersonalData To MainMenu  ********************/
		public void PersonalData_To_MainMenu ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(PD_To_MM());
		}

		IEnumerator PD_To_MM ()
		{
			//	fade out PersonalData UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				PersonalData.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			PersonalData.gameObject.SetActive(false);

			//	fade in MainMenu UI
			MainMenu.GetComponent<CanvasGroup> ().alpha = 0;
			MainMenu.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				MainMenu.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
        /**************************************************/
        #endregion

        #region LinearGame and LG_Adventure_Mode
        //      /******************** LinearGame To LG_Adventure_Mode  ********************/
        //      public void LinearGame_To_LGAdventureMode ()
        //{
        //	AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
        //	StartCoroutine(LG_To_LGAM());
        //}

        //IEnumerator LG_To_LGAM ()
        //{
        //	//	fade out LinearGame UI
        //	for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //	{
        //		LinearGame.GetComponent<CanvasGroup> ().alpha = i;
        //		yield return null;
        //	}
        //	LinearGame.gameObject.SetActive(false);

        //          //	fade in LG_Adventure_Mode UI
        //          LG_Adventure_Mode.GetComponent<CanvasGroup> ().alpha = 0;
        //          LG_Adventure_Mode.gameObject.SetActive (true);

        //	for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
        //	{
        //              LG_Adventure_Mode.GetComponent<CanvasGroup> ().alpha = i;
        //		yield return null;
        //	}

        //}
        ///**************************************************/



        ///******************** LG_Adventure_Mode To LinearGame  ********************/
        //public void LGAdventureMode_To_LinearGame ()
        //{
        //	AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
        //	StartCoroutine(LGAM_To_LG());
        //}

        //IEnumerator LGAM_To_LG ()
        //{
        //	//	fade out LG_Adventure_Mode UI
        //	for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //	{
        //		LG_Adventure_Mode.GetComponent<CanvasGroup> ().alpha = i;
        //		yield return null;
        //	}
        //	LG_Adventure_Mode.gameObject.SetActive(false);

        //	//	fade in LinearGame UI
        //	LinearGame.GetComponent<CanvasGroup> ().alpha = 0;
        //	LinearGame.gameObject.SetActive (true);

        //	for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
        //	{
        //		LinearGame.GetComponent<CanvasGroup> ().alpha = i;
        //		yield return null;
        //	}

        //}
        ///**************************************************/
        #endregion

        #region LinearGame and LG_Adventure_Mode_Level_Choose
        /******************** LinearGame To LG_Adventure_Mode_Level_Choose  ********************/
        public void LinearGame_To_LGAdventureModeLevelChoose()
        {
            AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
            StartCoroutine(LG_To_LGAMLC());
        }

        IEnumerator LG_To_LGAMLC()
        {
            //	fade out LinearGame UI
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                LinearGame.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
            LinearGame.gameObject.SetActive(false);

            //	fade in LG_Adventure_Mode_Level_Choose UI
            LG_Adventure_Mode_Level_Choose.GetComponent<CanvasGroup>().alpha = 0;
            LG_Adventure_Mode_Level_Choose.gameObject.SetActive(true);

            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                LG_Adventure_Mode_Level_Choose.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }

        }
        /**************************************************/



        /******************** LG_Adventure_Mode_Level_Choose To LinearGame  ********************/
        public void LGAdventureModeLevelChoose_To_LinearGame()
        {
            AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
            StartCoroutine(LGAMLC_To_LG());
        }

        IEnumerator LGAMLC_To_LG()
        {
            //	fade out LG_Adventure_Mode_Level_Choose UI
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                LG_Adventure_Mode_Level_Choose.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
            LG_Adventure_Mode_Level_Choose.gameObject.SetActive(false);

            //	fade in LinearGame UI
            LinearGame.GetComponent<CanvasGroup>().alpha = 0;
            LinearGame.gameObject.SetActive(true);

            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                LinearGame.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }

        }
        /**************************************************/
        #endregion

        #region LinearGame and LG_Custom_Mode
        /******************** LinearGame To LG_Custom_Mode  ********************/
        public void LinearGame_To_LGCustomMode ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(LG_To_LGCM());
		}

		IEnumerator LG_To_LGCM ()
		{
			//	fade out LinearGame UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				LinearGame.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
			LinearGame.gameObject.SetActive(false);

            //	fade in LG_Custom_Mode UI
            LG_Custom_Mode.GetComponent<CanvasGroup> ().alpha = 0;
            LG_Custom_Mode.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
                LG_Custom_Mode.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



        /******************** LG_Custom_Mode To LinearGame  ********************/
        public void LGCustomMode_To_LinearGame ()
		{
			AudioManager.PlayTouchtone (AudioManager.currentTouchtoneName);
			StartCoroutine(LGCM_To_LG());
		}

		IEnumerator LGCM_To_LG ()
		{
            //	fade out LG_Custom_Mode UI
			for(float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
                LG_Custom_Mode.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}
            LG_Custom_Mode.gameObject.SetActive(false);

			//	fade in LinearGame UI
			LinearGame.GetComponent<CanvasGroup> ().alpha = 0;
			LinearGame.gameObject.SetActive (true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed) 
			{
				LinearGame.GetComponent<CanvasGroup> ().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region LG_Adventure_Mode and LG_Match_Mode
        ///******************** LG_Adventure_Mode To LG_Match_Mode  ********************/
        //public void LGAdventureMode_To_LGMatchMode()
        //{
        //    AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
        //    StartCoroutine(LGAM_To_LGMM());
        //}

        //IEnumerator LGAM_To_LGMM()
        //{
        //    //  fade out LG_Adventure_Mode UI
        //    for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }
        //    LG_Adventure_Mode.gameObject.SetActive(false);

        //    //  fade in LG_Match_Mode UI
        //    LG_Match_Mode.GetComponent<CanvasGroup>().alpha = 0;
        //    LG_Match_Mode.gameObject.SetActive(true);

        //    for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Match_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }

        //}
        ///**************************************************/



        ///******************** LG_Match_Mode To LG_Adventure_Mode  ********************/
        //public void LGMatchMode_To_LGAdventureMode()
        //{
        //    AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
        //    StartCoroutine(LGMM_To_LGAM());
        //}

        //IEnumerator LGMM_To_LGAM()
        //{
        //    //  fade out LG_Match_Mode UI
        //    for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Match_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }
        //    LG_Match_Mode.gameObject.SetActive(false);

        //    //  fade in LG_Adventure_Mode UI
        //    LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = 0;
        //    LG_Adventure_Mode.gameObject.SetActive(true);

        //    for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }

        //}
        ///**************************************************/
		#endregion

		#region LG_Adventure_Mode and LG_Perception_Mode
        ///******************** LG_Adventure_Mode To LG_Perception_Mode  ********************/
        //public void LGAdventureMode_To_LGPerceptionMode()
        //{
        //    AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
        //    StartCoroutine(LGAM_To_LGPM());
        //}

        //IEnumerator LGAM_To_LGPM()
        //{
        //    //  fade out LG_Adventure_Mode UI
        //    for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }
        //    LG_Adventure_Mode.gameObject.SetActive(false);

        //    //  fade in LG_Perception_Mode UI
        //    LG_Perception_Mode.GetComponent<CanvasGroup>().alpha = 0;
        //    LG_Perception_Mode.gameObject.SetActive(true);

        //    for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Perception_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }

        //}
        ///**************************************************/



        ///******************** LG_Perception_Mode To LG_Adventure_Mode  ********************/
        //public void LGPerceptionMode_To_LGAdventureMode()
        //{
        //    AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
        //    StartCoroutine(LGPM_To_LGAM());
        //}

        //IEnumerator LGPM_To_LGAM()
        //{
        //    //  fade out LG_Perception_Mode UI
        //    for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Perception_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }
        //    LG_Perception_Mode.gameObject.SetActive(false);

        //    //  fade in LG_Adventure_Mode UI
        //    LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = 0;
        //    LG_Adventure_Mode.gameObject.SetActive(true);

        //    for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }

        //}
        ///**************************************************/
		#endregion

		#region LG_Adventure_Mode and LG_Expression_Mode
        ///******************** LG_Adventure_Mode To LG_Expression_Mode  ********************/
        //public void LGAdventureMode_To_LGExpressionMode()
        //{
        //    AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
        //    StartCoroutine(LGAM_To_LGEM());
        //}

        //IEnumerator LGAM_To_LGEM()
        //{
        //    //  fade out LG_Adventure_Mode UI
        //    for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }
        //    LG_Adventure_Mode.gameObject.SetActive(false);

        //    //  fade in LG_Expression_Mode UI
        //    LG_Expression_Mode.GetComponent<CanvasGroup>().alpha = 0;
        //    LG_Expression_Mode.gameObject.SetActive(true);

        //    for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Expression_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }

        //}
        ///**************************************************/



        ///******************** LG_Expression_Mode To LG_Adventure_Mode  ********************/
        //public void LGExpressionMode_To_LGAdventureMode()
        //{
        //    AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
        //    StartCoroutine(LGEM_To_LGAM());
        //}

        //IEnumerator LGEM_To_LGAM()
        //{
        //    //  fade out LG_Expression_Mode UI
        //    for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Expression_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }
        //    LG_Expression_Mode.gameObject.SetActive(false);

        //    //  fade in LG_Adventure_Mode UI
        //    LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = 0;
        //    LG_Adventure_Mode.gameObject.SetActive(true);

        //    for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
        //    {
        //        LG_Adventure_Mode.GetComponent<CanvasGroup>().alpha = i;
        //        yield return null;
        //    }

        //}
        ///**************************************************/
		#endregion

		#region LG_Custom_Mode and LG_Level_Creator
        /******************** LG_Custom_Mode To LG_Level_Creator  ********************/
        public void LGCustomMode_To_LGLevelCreator()
        {
            AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
            StartCoroutine(LGCM_To_LGLC());
        }

        IEnumerator LGCM_To_LGLC()
        {
            //  fade out LG_Custom_Mode UI
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                LG_Custom_Mode.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
            LG_Custom_Mode.gameObject.SetActive(false);

            //  fade in LG_Level_Creator UI
            LG_Level_Creator.GetComponent<CanvasGroup>().alpha = 0;
            LG_Level_Creator.gameObject.SetActive(true);

            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                LG_Level_Creator.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }

        }
        /**************************************************/



        /******************** LG_Level_Creator To LG_Custom_Mode  ********************/
        public void LGLevelCreator_To_LGCustomMode()
        {
            AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
            StartCoroutine(LGLC_To_LGCM());
        }

        IEnumerator LGLC_To_LGCM()
        {
            //  fade out LG_Level_Creator UI
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                LG_Level_Creator.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
            LG_Level_Creator.gameObject.SetActive(false);

            //  fade in LG_Custom_Mode UI
            LG_Custom_Mode.GetComponent<CanvasGroup>().alpha = 0;
            LG_Custom_Mode.gameObject.SetActive(true);

            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                LG_Custom_Mode.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }

        }
        /**************************************************/
		#endregion

		#region LG_Custom_Mode and LG_Choose_Custom_Game
        /******************** LG_Custom_Mode To LG_Choose_Custom_Game  ********************/
        public void LGCustomMode_To_LGChooseCustomGame()
        {
            AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
            StartCoroutine(LGCM_To_LGCCG());
        }

        IEnumerator LGCM_To_LGCCG()
        {
            //  fade out LG_Custom_Mode UI
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                LG_Custom_Mode.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
            LG_Custom_Mode.gameObject.SetActive(false);

            //  fade in LG_Choose_Custom_Game UI
            LG_Choose_Custom_Game.GetComponent<CanvasGroup>().alpha = 0;
            LG_Choose_Custom_Game.gameObject.SetActive(true);

            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                LG_Choose_Custom_Game.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }

        }
        /**************************************************/



        /******************** LG_Choose_Custom_Game To LG_Custom_Mode  ********************/
        public void LGChooseCustomGame_To_LGCustomMode()
        {
            AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
            StartCoroutine(LGCCG_To_LGCM());
        }

        IEnumerator LGCCG_To_LGCM()
        {
            //  fade out LG_Choose_Custom_Game UI
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                LG_Choose_Custom_Game.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }
            LG_Choose_Custom_Game.gameObject.SetActive(false);

            //  fade in LG_Custom_Mode UI
            LG_Custom_Mode.GetComponent<CanvasGroup>().alpha = 0;
            LG_Custom_Mode.gameObject.SetActive(true);

            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                LG_Custom_Mode.GetComponent<CanvasGroup>().alpha = i;
                yield return null;
            }

        }
        /**************************************************/
		#endregion

		#region GameSetting and Custom_Image_Manager
		/******************** GameSetting To Custom_Image_Manager  ********************/
		public void GameSetting_To_CustomImageManager()
		{
			AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
			StartCoroutine(GS_To_CIM());
		}

		IEnumerator GS_To_CIM()
		{
			//  fade out GameSetting UI
			for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				GameSetting.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}
			GameSetting.gameObject.SetActive(false);

			//  fade in Custom_Image_Manager UI
			CustomImageManager.GetComponent<CanvasGroup>().alpha = 0;
			CustomImageManager.gameObject.SetActive(true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
			{
				CustomImageManager.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** Custom_Image_Manager To GameSetting  ********************/
		public void CustomImageManager_To_GameSetting()
		{
			AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
			StartCoroutine(CIM_To_GS());
		}

		IEnumerator CIM_To_GS()
		{
			//  fade out Custom_Image_Manager UI
			for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				CustomImageManager.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}
			CustomImageManager.gameObject.SetActive(false);

			//  fade in GameSetting UI
			GameSetting.GetComponent<CanvasGroup>().alpha = 0;
			GameSetting.gameObject.SetActive(true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
			{
				GameSetting.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region Custom_Image_Manager and Custom_Image_Browser
		/******************** Custom_Image_Manager To Custom_Image_Browser  ********************/
		public void CustomImageManager_To_CustomImageBrowser()
		{
			AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
			StartCoroutine(CIM_To_CIB());
		}

		IEnumerator CIM_To_CIB()
		{
			//  fade out Custom_Image_Manager UI
			for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				CustomImageManager.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}
			CustomImageManager.gameObject.SetActive(false);

			//  fade in Custom_Image_Browser UI
			CustomImageBrowser.GetComponent<CanvasGroup>().alpha = 0;
			CustomImageBrowser.gameObject.SetActive(true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
			{
				CustomImageBrowser.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}

		}
		/**************************************************/



		/******************** Custom_Image_Browser To Custom_Image_Manager  ********************/
		public void CustomImageBrowser_To_CustomImageManager()
		{
			AudioManager.PlayTouchtone(AudioManager.currentTouchtoneName);
			StartCoroutine(CIB_To_CIM());
		}

		IEnumerator CIB_To_CIM()
		{
			//  fade out Custom_Image_Browser UI
			for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
			{
				CustomImageBrowser.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}
			CustomImageBrowser.gameObject.SetActive(false);

			//  fade in Custom_Image_Manager UI
			CustomImageManager.GetComponent<CanvasGroup>().alpha = 0;
			CustomImageManager.gameObject.SetActive(true);

			for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
			{
				CustomImageManager.GetComponent<CanvasGroup>().alpha = i;
				yield return null;
			}

		}
		/**************************************************/
		#endregion

		#region CustomImageBrowser and SuccesslyImportImage_Popup_CIB
		public void CustomImageBrowser_To_SuccesslyImportImage_Popup_CIB()
		{
			SuccesslyImportImage_Popup_CIB.SetActive (true);
		}

		public void SuccesslyImportImage_Popup_CIB_To_CustomImageBrowser()
		{
			SuccesslyImportImage_Popup_CIB.SetActive (false);
		}
		#endregion

		/******************** Add New Child  ********************/

		public void AddNewChild ()
		{
			childList.Add (Instantiate (childData));
			childListLength = childList.Count;
			childList [childListLength - 1].transform.SetParent (childListContent.transform, false);
			childList [childListLength - 1].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-160, addChildButton.GetComponent<RectTransform> ().anchoredPosition.y);
			addChildButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-160, addChildButton.GetComponent<RectTransform> ().anchoredPosition.y - 600);
			childContentPort.GetComponent<RectTransform> ().sizeDelta = new Vector2 (0, 1150 + 600 * childListLength);
		}
	    
		/**************************************************/
	}
