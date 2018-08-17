/*
* Created by Daniel Mak
*/

using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Camera Shaker Settings", menuName = "Camera Shaker Settings")]
public class CameraShakeSettings : ScriptableObject {
    [Min(0)] public float time;
    [Min(0)] public float shakiness;
}

public class CameraShake : MonoBehaviour {

    public CameraShakeSettings settings;

    public void Shake() {
        StartCoroutine(ShakeCoroutine(settings.time, settings.shakiness, Time.deltaTime));
    }

    public void Shake(float time, float shakiness, float interval) {
        StartCoroutine(ShakeCoroutine(time, shakiness, interval));
    }

    private IEnumerator ShakeCoroutine(float time, float shakiness, float interval) {
        float timer = 0f;

        Vector3 camOriginalPosition = transform.localPosition;

        while (timer < time) {
            transform.localPosition += new Vector3(Random.Range(-1f, 1f) * shakiness, Random.Range(-1f, 1f) * shakiness, 0);

            yield return new WaitForSeconds(interval);
            timer += interval;
        }

        transform.localPosition = camOriginalPosition;
    }
}