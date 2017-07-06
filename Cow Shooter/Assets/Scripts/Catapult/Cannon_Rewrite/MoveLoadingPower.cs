using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLoadingPower : MovePower {

	public List<AmmoHolder> ammoStorages = new List<AmmoHolder>();
	private InitialUI gameStartInd;

	protected override void updateMovable() {
		gameStartInd = GameObject.Find ("Global_Scripts").GetComponent<InitialUI>();
		movable = GameObject.Find ("Loading_Bar/PowerIndicator");
		pow = new PowerControl ();
		pow.max = 100;
		pow.min = 0;
		pow.milliUntilMaxPower = 2000;
		pow.originalIncreasing = true;
	}

	protected override void otherActions ()
	{
		if (gameStartInd.isGamePlaying () && Time.deltaTime != 0) {
			pow.changePower ();
			if (pow.getCurrentPercent () > 98) {
				foreach (AmmoHolder ammo in ammoStorages) {
					ammo.tryToAddAmmo ();
				}
				pow.resetPower ();
			}
		}
	}
}
