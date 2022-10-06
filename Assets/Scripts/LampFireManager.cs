using UnityEngine;

public class LampFireManager : MonoBehaviour
{
	private void OnEnable() {
        LevelManager.instance.lampFoundCount++;
        LevelManager.instance.UpdateLampText();
    }
}
