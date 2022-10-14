using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
	public static UIController instance;
    [SerializeField] private Image heart1, heart2, heart3;
    [SerializeField] private Sprite heartFull, heartEmpty;
    [SerializeField] private TextMeshProUGUI _lampFoundText;
    [SerializeField] private Slider _energySlider;
	[SerializeField] private GameObject _energyFillArea;

    private void OnEnable() {
        LevelManager.OnRespawnHealthUpdate += UpdateHealthDisplay;
        LevelManager.OnLampFound += UpdateLampsText;
        PlayerHealthController.OnDamageTaken += UpdateHealthDisplay;
    }

    private void OnDisable() {
        LevelManager.OnRespawnHealthUpdate -= UpdateHealthDisplay;
        LevelManager.OnLampFound -= UpdateLampsText;
        PlayerHealthController.OnDamageTaken -= UpdateHealthDisplay;
    }

    private void Awake() {
        instance = this;
    }

    private void Update() {
        _energySlider.value = LevelEnergyManager.instance.lightCurrentValue;
        if (_energySlider.value <= 0) {
            _energyFillArea.SetActive(false);
        }
        else {
            _energyFillArea.SetActive(true);
        }
    }

    private void UpdateLampsText(int lampsFound, int lampsTotal) {
        _lampFoundText.text = $"Lamps activated: {lampsFound} / {lampsTotal}";
    }

    private void UpdateHealthDisplay() {
        switch (PlayerHealthController.instance.currentHealth) {
            case 3: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 2:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 1:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartFull;
                break;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
        }
    }
}
