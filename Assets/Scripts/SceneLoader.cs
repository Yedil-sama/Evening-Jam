using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private LoadingCanvas loadingCanvas;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void LoadScene(string name) => StartCoroutine(LoadSceneAsync(name));

    public void ReloadScene() => StartCoroutine(LoadSceneAsync(SceneManager.GetActiveScene().name));

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        loadingCanvas.Show();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            if (loadingCanvas != null)
                loadingCanvas.SetProgress(operation.progress);
            yield return null;
        }

        if (loadingCanvas != null)
            loadingCanvas.SetProgress(1f);

        yield return new WaitForSeconds(1f);

        operation.allowSceneActivation = true;
        yield return null;

        loadingCanvas.Hide();
    }
}
