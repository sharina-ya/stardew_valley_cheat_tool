protected override void Update(GameTime gameTime)
{
	if (Game1.input.GetKeyboardState().IsKeyDown(Keys.F7) && Game1.activeClickableMenu == null && base.IsActive)
	{
		Game1.activeClickableMenu = new CheatMenu();
		Game1.playSound("bigSelect");
	}
	if (Game1.input.GetGamePadState().IsButtonDown(Buttons.RightStick))
	{
		Game1.rightStickHoldTime += gameTime.ElapsedGameTime.Milliseconds;
	}
	this._update(gameTime);
	Rumble.update((float)gameTime.ElapsedGameTime.Milliseconds);
	if (Game1.options.gamepadControls && Game1.thumbstickMotionMargin > 0)
	{
		Game1.thumbstickMotionMargin -= gameTime.ElapsedGameTime.Milliseconds;
	}
	if (!Game1.input.GetGamePadState().IsButtonDown(Buttons.RightStick))
	{
		Game1.rightStickHoldTime = 0;
	}
	base.Update(gameTime);
}
