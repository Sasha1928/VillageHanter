using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    [SerializeField] private GameObject _loadScane;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _loadScane.SetActive(true);

        StartCoroutine(LoadAsyns());
    }
    IEnumerator LoadAsyns(){
        AsyncOperation loadAsyns = SceneManager.LoadSceneAsync(1);
        loadAsyns.allowSceneActivation = false;

        while (!loadAsyns.isDone)
        {
            _slider.value = loadAsyns.progress;

            if(loadAsyns.progress >= 0.9f && !loadAsyns.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsyns.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
