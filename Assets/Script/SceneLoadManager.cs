using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour {

    static AsyncOperation asyncOperation;
    static UnityAction<float> _progress;

    static public void LoadScene(string name,UnityAction<float> progress,UnityAction finish)
    {
        new GameObject("#SceneLoadManager#").AddComponent<SceneLoadManager>();
        asyncOperation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        _progress = progress;
        asyncOperation.completed += delegate (AsyncOperation obj)
        {
            finish();
            asyncOperation = null;
        };
    }
	
	// Update is called once per frame
	void Update () {
        if (asyncOperation != null)
        {
            if(_progress != null)
            {
                _progress(asyncOperation.progress);
                _progress = null;
            }
        }
	}
}
