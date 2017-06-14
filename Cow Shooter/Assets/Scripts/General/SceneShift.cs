using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneShift {

	public static void shiftScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
