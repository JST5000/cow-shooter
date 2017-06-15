using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminDeck {

	public static void giveDeckTo(PlayerData deckHolder) {
		deckHolder.throwableNames.Add ("Anchor");
		deckHolder.throwableNames.Add ("Bomb");
		deckHolder.throwableNames.Add ("BouncyHouse");
		deckHolder.throwableNames.Add ("Chair");
		deckHolder.throwableNames.Add ("Cow");
		deckHolder.throwableNames.Add ("Doughnut");
		deckHolder.throwableNames.Add ("FlatscreenRed");
		deckHolder.throwableNames.Add ("Long-Blue");
		deckHolder.throwableNames.Add ("Pan");
		deckHolder.throwableNames.Add ("Piano");
		deckHolder.throwableNames.Add ("Present_Red");
		deckHolder.throwableNames.Add ("Square-Blue");
		deckHolder.throwableNames.Add ("Teddy");
		deckHolder.throwableNames.Add ("Tetris_T");
	}

}
