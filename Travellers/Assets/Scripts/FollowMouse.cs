/*
* Created by Daniel Mak
*/

using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public Vector3 offset = new Vector3(0, 0, 10);
    [Min(0)] public float smoothTime = 0.1f;

    private Vector3 velocity;

    private void Update () {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}