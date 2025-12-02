using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Netcode;
using StardewValley.BellsAndWhistles;
using StardewValley.Events;
using StardewValley.Locations;
using StardewValley.Menus;
using StardewValley.Minigames;
using StardewValley.Network;
using StardewValley.Quests;
using StardewValley.Util;
using xTile.Dimensions;
using xTile.Display;

namespace StardewValley
{
	// Token: 0x02000012 RID: 18
	public partial class Game1 : Game
	{
		// Token: 0x06000189 RID: 393
		protected override void Update(GameTime gameTime)
		{
			if (Game1.input.GetKeyboardState().IsKeyDown(Keys.F7) && Game1.activeClickableMenu == null && base.IsActive)
			{
				Game1.activeClickableMenu = new CheatMenu();
				Game1.playSound("bigSelect");
			}
			if (CheatMenu.IsImmortal && Game1.player != null)
			{
				Game1.player.health = Game1.player.maxHealth;
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
	}
}
