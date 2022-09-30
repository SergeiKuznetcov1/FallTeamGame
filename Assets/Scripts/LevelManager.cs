using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;
    public float waitToRespawn;

    private void Awake() {
        instance = this;
    }

    public void RespawnPlayer() {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo() {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        PlayerController.instance.transform.position = CheckpointsController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
        PlayerController.instance.gameObject.SetActive(true);
    }
}
