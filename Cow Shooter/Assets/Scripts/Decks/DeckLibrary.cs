using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLibrary : MonoBehaviour {

	public static void giveAdminDeckTo(PlayerData deckHolder) {
		deckHolder.throwableNames.Clear ();
		deckHolder.throwableNames.Add ("Anchor");
		deckHolder.throwableNames.Add ("Bomb");
		deckHolder.throwableNames.Add ("BouncyHouse");
		deckHolder.throwableNames.Add ("Chair");
		deckHolder.throwableNames.Add ("Cow");
		deckHolder.throwableNames.Add ("Doughnut");
		deckHolder.throwableNames.Add ("Flatscreen");
		deckHolder.throwableNames.Add ("Long-Blue");
		deckHolder.throwableNames.Add ("Pan");
		deckHolder.throwableNames.Add ("Piano");
		deckHolder.throwableNames.Add ("Present");
		deckHolder.throwableNames.Add ("Square-Blue");
		deckHolder.throwableNames.Add ("Teddy");
		deckHolder.throwableNames.Add ("Tetris_T");
	}

	public static void giveBomberManDeckTo(PlayerData deckHolder) {
		deckHolder.throwableNames.Clear ();
		deckHolder.throwableNames.Add ("Bomb");
		deckHolder.throwableNames.Add ("Present");
	}
}
