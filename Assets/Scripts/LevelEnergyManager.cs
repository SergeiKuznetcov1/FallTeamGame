using UnityEngine;
using UnityEngine.UI;

public class LevelEnergyManager : MonoBehaviour
{
    public static LevelEnergyManager instance;
	// [SerializeField] private Slider _energySlider;
	// [SerializeField] private GameObject _energyFillArea;
	[SerializeField] private float _energyReduceSpeed;
	[SerializeField] private float _sliderBarsAmount;
    private float _lightStartValue;
    public float lightCurrentValue;
    private bool _energyOut;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        _lightStartValue = RenderSettings.ambientLight.r;
        lightCurrentValue = _lightStartValue;
    }
    private void Update() {
        if (_energyOut) return;
        ReduceEnergy();
    }

    private void ReduceEnergy() {
        // _energySlider.value -= _energyReduceSpeed * Time.deltaTime / _sliderBarsAmount;
        lightCurrentValue -= Time.deltaTime / _sliderBarsAmount;
        RenderSettings.ambientLight = new Color(lightCurrentValue,lightCurrentValue, lightCurrentValue);
        if (lightCurrentValue <= 0) {
            
            _energyOut = true;
        }
    }

    public void AddEnergy(float amount) {
        _energyOut = false;
        // _energyFillArea.SetActive(true);
        lightCurrentValue += amount;
        if (lightCurrentValue > _lightStartValue) {
            lightCurrentValue = _lightStartValue;
        }
        // _energySlider.value = lightCurrentValue;
    }
}
