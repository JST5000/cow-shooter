using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShift : MonoBehaviour {

	public static void shiftScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

	public void workaround() {

	}
}
