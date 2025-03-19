using UnityEngine;

public class LeanTween2 : MonoBehaviour
{
    public Light directionalLight;
    public float dayIntensity = 1.0f;
    public float nightIntensity = 0.2f;
    public float cycleDuration = 10f; 

    private void Start()
    {

        StartDayNightCycle();
    }

    void StartDayNightCycle()
    {
        LeanTween.value(directionalLight.gameObject, dayIntensity, nightIntensity, cycleDuration / 2).setOnUpdate((float value) => {directionalLight.intensity = value;}).setOnComplete(() => {
        LeanTween.value(directionalLight.gameObject, nightIntensity, dayIntensity, cycleDuration / 2).setOnUpdate((float value) => {directionalLight.intensity = value;}).setOnComplete(() => {StartDayNightCycle();});});
    }
}
