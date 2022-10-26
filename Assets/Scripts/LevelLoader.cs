using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public void LoadScene(int index) {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
