using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
	public void StartGame() {
        SceneManager.LoadScene("Level_1");
    }
}
