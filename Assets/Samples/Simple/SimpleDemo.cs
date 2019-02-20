using BarcodeScanner;
using BarcodeScanner.Scanner;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Wizcorp.Utils.Logger;

public class SimpleDemo : MonoBehaviour {

	private IScanner BarcodeScanner;
	public Text TextHeader;
	public RawImage Image1;
	public AudioSource Audio;
    public RawImage Image2;



    // Disable Screen Rotation on that screen
    void Awake()
	{
        //Screen.autorotateToPortrait = false;
        //Screen.autorotateToPortraitUpsideDown = false;
       

    }

	void Start () {
		// Create a basic scanner
		BarcodeScanner = new Scanner();
		BarcodeScanner.Camera.Play();

        // Display the camera texture through a RawImage
        BarcodeScanner.OnReady += (sender, arg) =>
        {

            // Set Orientation & Texture
            Image1.gameObject.SetActive(true);
            Image2.gameObject.SetActive(true);

            Image1.transform.localEulerAngles = BarcodeScanner.Camera.GetEulerAngles();
            Image1.transform.localScale = BarcodeScanner.Camera.GetScale();
            Image1.texture = BarcodeScanner.Camera.Texture;
            Image2.texture = BarcodeScanner.Camera.Texture;
            Image2.transform.localEulerAngles = BarcodeScanner.Camera.GetEulerAngles();
            Image2.transform.localScale = BarcodeScanner.Camera.GetScale();
            // Keep Image Aspect Ratio
            var rect = Image1.GetComponent<RectTransform>();
            var newHeight = rect.sizeDelta.x * BarcodeScanner.Camera.Height / BarcodeScanner.Camera.Width;
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, newHeight);



            ClickStart();
        };

		// Track status of the scanner
		BarcodeScanner.StatusChanged += (sender, arg) => {
			TextHeader.text = "Scan QR code " ;
		};


    }

	/// <summary>
	/// The Update method from unity need to be propagated to the scanner
	/// </summary>
	void Update()
	{
		if (BarcodeScanner == null)
		{
			return;
		}
		BarcodeScanner.Update();
	}

	#region UI Buttons

	public void ClickStart()
	{
		if (BarcodeScanner == null)
		{
			Log.Warning("No valid camera - Click Start");
			return;
		}

		// Start Scanning
		BarcodeScanner.Scan((barCodeType, barCodeValue) => {
			BarcodeScanner.Stop();
			TextHeader.text = "Found it !";
            SceneSwitcher.QRValue = barCodeValue;
            //SceneSwitcherScript.OnButtonClick();
            ClickBack();
            // Feedback
            Audio.Play();

			#if UNITY_ANDROID || UNITY_IOS
			Handheld.Vibrate();
			#endif
		});
	}


	public void ClickBack()
	{
		// Try to stop the camera before loading another scene
		StartCoroutine(StopCamera(() => {
			SceneManager.LoadScene("ARScene");
		}));
	}

	/// <summary>
	/// This coroutine is used because of a bug with unity (http://forum.unity3d.com/threads/closing-scene-with-active-webcamtexture-crashes-on-android-solved.363566/)
	/// Trying to stop the camera in OnDestroy provoke random crash on Android
	/// </summary>
	/// <param name="callback"></param>
	/// <returns></returns>
	public IEnumerator StopCamera(Action callback)
	{
		// Stop Scanning
		Image1 = null;
		BarcodeScanner.Destroy();
		BarcodeScanner = null;

		// Wait a bit
		yield return new WaitForSeconds(0.1f);

		callback.Invoke();
	}

	#endregion
}
