using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _lamps;
    // [SerializeField] private TextMeshProUGUI _lampFoundText;
	public static LevelManager instance;
    public float waitToRespawn;
    public int lampFoundCount;
    public delegate void RespawnHealthUpdate();
    public static event RespawnHealthUpdate OnRespawnHealthUpdate;
    public delegate void LampTextUpdate(int lampsFound, int lampsTotal);
    public static event LampTextUpdate OnLampFound;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateLampText();
    }

    public void UpdateLampText() {
        OnLampFound?.Invoke(lampFoundCount, _lamps.Length);
    }

    public void RespawnPlayer() {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo() {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        PlayerController.instance.transform.position = CheckpointsController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        // UIController.instance.UpdateHealthDisplay();
        OnRespawnHealthUpdate?.Invoke();
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.IsGrounded = true;
    }
}
