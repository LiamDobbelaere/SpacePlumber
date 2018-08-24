using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneDelayed : MonoBehaviour {
    public string sceneName;
    public int delayInSeconds;

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadNextSceneDelayed());
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator LoadNextSceneDelayed()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneName);
    }
}
