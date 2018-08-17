/*
* Created by Daniel Mak
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneTransition : MonoBehaviour {

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Reload() {
        StartCoroutine(TransitToSceneCoroutine(SceneManager.GetActiveScene().buildIndex));
    }

    public void TransitTo(int index) {
        StartCoroutine(TransitToSceneCoroutine(index));
    }

    public void TransitToNextScene() {
        StartCoroutine(TransitToSceneCoroutine(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator TransitToSceneCoroutine(int index) {
        if (index < SceneManager.sceneCountInBuildSettings) {
            animator.SetTrigger("Transit");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            SceneManager.LoadScene(index);
        }
    }
}