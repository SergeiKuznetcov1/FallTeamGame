using UnityEngine;
using UnityEngine.UI;

public class LevelEnergyManager : MonoBehaviour
{
    public static LevelEnergyManager instance;
	[SerializeField] private Slider _energySlider;
	[SerializeField] private GameObject _energyFillArea;
	[SerializeField] private float _energyReduceSpeed;
    private float _lightStartValue;
    private float _lightCurrentValue;
    private bool _energyOut;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        _lightStartValue = RenderSettings.ambientLight.r;
        _lightCurrentValue = _lightStartValue;
    }
    private void Update() {
        if (_energyOut) return;
        ReduceEnergy();
    }

    private void ReduceEnergy() {
        _energySlider.value -= _energyReduceSpeed * Time.deltaTime / 100;
        _lightCurrentValue -= Time.deltaTime / 100;
        RenderSettings.ambientLight = new Color(_lightCurrentValue,_lightCurrentValue, _lightCurrentValue);
        if (_energySlider.value == 0) {
            _energyFillArea.SetActive(false);
            _energyOut = true;
        }
    }

    public void AddEnergy(float amount) {
        _lightCurrentValue += amount;
        if (_lightCurrentValue > _lightStartValue) {
            _lightCurrentValue = _lightStartValue;
        }
        _energySlider.value = _lightCurrentValue;
    }
}
