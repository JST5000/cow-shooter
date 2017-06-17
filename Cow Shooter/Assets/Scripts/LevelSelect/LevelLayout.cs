using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayout : MonoBehaviour {

	public int levelsPerRow;
	public float xDisplacement;
	public float yDisplacement;
	public Vector2 topLeftCorner;

	void Start() {
		instantiateLevelUI ();
		print ("JI");
	}

	private void instantiateLevelUI() {
		GameObject levelUI = (GameObject)Resources.Load ("UI_Prefabs/" + "LevelIcon");
		Vector2 currentPosition;
		int lvlsOnCurrentRow = 0;
		int currentRow = 0;
		foreach (Level lvl in LevelLibrary.allLevels) {
			currentPosition = new Vector2(topLeftCorner.x + xDisplacement * (lvlsOnCurrentRow % levelsPerRow),
				topLeftCorner.y - (yDisplacement * currentRow));
			GameObject instance = Instantiate (levelUI, GameObject.Find ("Canvas").transform);
			instance.transform.localPosition = currentPosition;
			int levelNumber = lvlsOnCurrentRow + currentRow * levelsPerRow + 1;
			instance.GetComponent<LevelToUI> ().adoptLevel (lvl, levelNumber);
			lvlsOnCurrentRow++;
			if (lvlsOnCurrentRow % levelsPerRow == 0 && lvlsOnCurrentRow != 0) {
				currentRow++;
				lvlsOnCurrentRow = 0;
			}
		}
	}
}
