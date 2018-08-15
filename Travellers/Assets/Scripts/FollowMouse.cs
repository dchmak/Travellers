/*
* Created by Daniel Mak
*/

using UnityEngine;

public class FollowMouse : MonoBehaviour {

    public Vector3 offset = new Vector3(0, 0, 10);

    private void Update () {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
	}
}