/*
* Created by Daniel Mak
*/

using UnityEngine;

public class CircleManager : MonoBehaviour {

    public ParticleSystem centerCircle;
    public ParticleSystem concentricCircles;
    [Space]
    [Min(0)] public float radius;

    public bool InsideCenterCircle(Vector2 position) {
        return Vector2.Distance(position, transform.position) < radius;
    }

    private void OnValidate() {
        if (centerCircle != null) {
            ParticleSystem.MainModule centerCircleMain = centerCircle.main;
            centerCircleMain.startSize = radius * 2;
        }

        if (concentricCircles != null) {
            ParticleSystem.MainModule concentricCirclesMain = concentricCircles.main;
            ParticleSystem.SizeOverLifetimeModule concentricCirclesSizeOverLifeTime = concentricCircles.sizeOverLifetime;
            Keyframe[] keyframes = new Keyframe[2];
            keyframes[0] = new Keyframe(0, 1);
            keyframes[1] = new Keyframe(1, radius * 2 / concentricCirclesMain.startSize.constant);
            concentricCirclesSizeOverLifeTime.size = new ParticleSystem.MinMaxCurve(1, new AnimationCurve(keyframes));
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}