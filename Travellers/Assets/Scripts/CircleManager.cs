/*
* Created by Daniel Mak
*/

using UnityEngine;

public class CircleManager : MonoBehaviour {

    public ParticleSystem centerCircle;
    public ParticleSystem concentricCircles;
    [Space]
    public float radius;

    public bool InsideCenterCircle() {
        Vector2 mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Vector2.Distance(mousePostion, transform.position) < radius;
    }

    private void Update() {
        print(InsideCenterCircle());
    }

    private void OnValidate() {
        if (centerCircle != null) {
            ParticleSystem.MainModule centerCircleMain = centerCircle.main;
            centerCircleMain.startSize = radius;
        }

        if (concentricCircles != null) {
            ParticleSystem.MainModule concentricCirclesMain = concentricCircles.main;
            ParticleSystem.SizeOverLifetimeModule concentricCirclesSizeOverLifeTime = concentricCircles.sizeOverLifetime;
            Keyframe[] keyframes = new Keyframe[2];
            keyframes[0] = new Keyframe(0, 1);
            keyframes[1] = new Keyframe(1, radius / concentricCirclesMain.startSize.constant);
            concentricCirclesSizeOverLifeTime.size = new ParticleSystem.MinMaxCurve(1, new AnimationCurve(keyframes));
        }
    }
}