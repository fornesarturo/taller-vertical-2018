using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectGuilty : MonoBehaviour {

    private bool selecting;

    // Use this for initialization
    void Start () {
        selecting = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void oscarIsGuilty()
    {
        StartCoroutine("selectOscarGuiltyCorroutine");
    }

    public void frankIsGuilty()
    {
        StartCoroutine("selectFrankGuiltyCorroutine");
    }

    public void SetGaze(bool gaze)
    {
        this.selecting = gaze;
        if (!this.selecting)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator selectOscarGuiltyCorroutine()
    {
        float seconds = 0f;
        while (true)
        {
            if (seconds < 1f)
            {
                seconds += 1f;
            }
            else
            {
                PlayerPrefs.SetString("NextSceneToLoad", "Ending");
                SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
                Debug.Log("Oscar Guilty");
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    IEnumerator selectFrankGuiltyCorroutine()
    {
        float seconds = 0f;
        while (true)
        {
            if (seconds < 1f)
            {
                seconds += 1f;
            }
            else
            {
				PlayerPrefs.SetString("NextSceneToLoad", "Ending");
                SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
                Debug.Log("Frank Guilty");
            }
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
