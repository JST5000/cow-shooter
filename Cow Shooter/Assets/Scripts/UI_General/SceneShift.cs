using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneShift : MonoBehaviour {

	public void shiftScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
