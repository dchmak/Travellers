/*
* Created by Daniel Mak
*/

using UnityEngine;

public class PowerUp : MonoBehaviour {

    [Min(0)] public float radius;
    [Min(0)] public float value;

    private GameManager manager;

    private void Start() {
        manager = GameManager.instance;
    }

    private void Update() {
        if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < radius) {
            manager.circle.ChangeRadius(value);
            print("Power Up!");
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}