// StardewValley.Game1
// Token: 0x060001B5 RID: 437
public static void UpdateGameClock(GameTime time)
{
	if (CheatMenu.TimeFrozen)
	{
		Game1.timeOfDay = CheatMenu.FrozenTimeOfDay;
		Game1.gameTimeInterval = 0;
		return;
	}
	if (Game1.shouldTimePass() && !Game1.IsClient)
	{
		Game1.gameTimeInterval += time.ElapsedGameTime.Milliseconds;
	}
	if (Game1.timeOfDay >= Game1.getTrulyDarkTime())
	{
		int adjustedTime = (int)((float)(Game1.timeOfDay - Game1.timeOfDay % 100) + (float)(Game1.timeOfDay % 100 / 10) * 16.66f);
		float transparency = Math.Min(0.93f, 0.75f + ((float)(adjustedTime - Game1.getTrulyDarkTime()) + (float)Game1.gameTimeInterval / 7000f * 16.6f) * 0.000625f);
		Game1.outdoorLight = (Game1.isRaining ? Game1.ambientLight : Game1.eveningColor) * transparency;
	}
	else if (Game1.timeOfDay >= Game1.getStartingToGetDarkTime())
	{
		int adjustedTime2 = (int)((float)(Game1.timeOfDay - Game1.timeOfDay % 100) + (float)(Game1.timeOfDay % 100 / 10) * 16.66f);
		float transparency2 = Math.Min(0.93f, 0.3f + ((float)(adjustedTime2 - Game1.getStartingToGetDarkTime()) + (float)Game1.gameTimeInterval / 7000f * 16.6f) * 0.00225f);
		Game1.outdoorLight = (Game1.isRaining ? Game1.ambientLight : Game1.eveningColor) * transparency2;
	}
	else if (Game1.bloom != null && Game1.timeOfDay >= Game1.getStartingToGetDarkTime() - 100 && Game1.bloom.Visible)
	{
		Game1.bloom.Settings.BloomThreshold = Math.Min(1f, Game1.bloom.Settings.BloomThreshold + 0.0004f);
	}
	else if (Game1.isRaining)
	{
		Game1.outdoorLight = Game1.ambientLight * 0.3f;
	}
	if (Game1.currentLocation != null && Game1.gameTimeInterval > 7000 + Game1.currentLocation.getExtraMillisecondsPerInGameMinuteForThisLocation())
	{
		if (Game1.panMode)
		{
			Game1.gameTimeInterval = 0;
			return;
		}
		Game1.performTenMinuteClockUpdate();
	}
}
