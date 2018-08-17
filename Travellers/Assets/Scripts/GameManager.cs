/*
* Created by Daniel Mak
*/

using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public CircleManager circle;
    [Header("Events")]
    public UnityEvent OnLoseEvents;
    
    private bool hasStart = false;

    private void Update() {
        if (!hasStart) {
            CheckStart();
        } else {
            CheckLose();
        }
    }

    private void CheckStart() {
        if (circle.InsideCenterCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
            hasStart = true;
        }
    }

    private void CheckLose() {
        if (!circle.InsideCenterCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition))) {
            OnLoseEvents.Invoke();
        }
    }    

    private void OnValidate() {
        name = "[Game Manager]";
    }
}