using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Ads : MonoBehaviour {

    public int previousScene;

	void Start () {
        Advertisement.Initialize("1665333");
	}

	void Update () {
		
	}

    public void OnButtonClick()
    {
        Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:

                int.TryParse(PlayerPrefs.GetString("previousScene"), out previousScene);

                SceneManager.LoadScene(previousScene);
                
                break;
        }

    }
}
