using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _lamps;
    [SerializeField] private TextMeshProUGUI _lampFoundText;
	public static LevelManager instance;
    public float waitToRespawn;
    public int lampFoundCount;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateLampText();
    }

    public void UpdateLampText() {
        _lampFoundText.text = $"Lamps activated: {lampFoundCount} / {_lamps.Length}";
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
        PlayerController.instance.IsGrounded = true;
    }
}
