using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptSceneChange : MonoBehaviour
{
    public void QuitApplication() {
        if (UnityEditor.EditorApplication.isPlaying) {
            UnityEditor.EditorApplication.isPlaying = false;
        } else {
            Application.Quit();
        }
    }

    public void LoadSceneDelay(string sceneName) {
        StartCoroutine(LoadSceneAfterDelay(sceneName));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName) {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
