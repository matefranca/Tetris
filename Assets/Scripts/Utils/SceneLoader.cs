using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tetris.Scenes
{
    public class SceneLoader : Singleton<SceneLoader>
    {
        [Header("Loading Image.")]
        [SerializeField]
        private GameObject loadingObject;
        [SerializeField]
        private Image loadingBar;

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            loadingObject.SetActive(true);
            loadingBar.fillAmount = 0;

            yield return new WaitForSeconds(0.2f);

            AsyncOperation handle = SceneManager.LoadSceneAsync(sceneName);

            while (handle.progress < 1)
            {
                loadingBar.fillAmount = handle.progress;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(1.2f);

            loadingObject.SetActive(false);
        }
    }
}