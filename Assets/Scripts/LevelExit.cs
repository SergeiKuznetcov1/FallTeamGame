using UnityEngine;

public class LevelExit : MonoBehaviour
{
	[SerializeField] private LevelLoader _levelLoader;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _levelLoader.LoadScene("Level_Select");
        }
    }
}
