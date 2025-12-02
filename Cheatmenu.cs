using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StardewValley.Menus
{
	// Token: 0x02000353 RID: 851
	public class CheatMenu : IClickableMenu
	{
		// Token: 0x06002983 RID: 10627
		public CheatMenu() : base(Game1.viewport.Width / 2 - (1000 + IClickableMenu.borderWidth * 2) / 2, Game1.viewport.Height / 2 - (600 + IClickableMenu.borderWidth * 2) / 2, 1000 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, false)
		{
			int num = this.xPositionOnScreen + 50;
			int y = this.yPositionOnScreen + 130;
			int num2 = 333;
			this.moneyTextBox = new TextBox(Game1.content.Load<Texture2D>("LooseSprites\\textBox"), null, Game1.smallFont, Game1.textColor)
			{
				X = num,
				Y = y,
				Width = 200,
				Height = 60,
				Text = "1000"
			};
			this.addMoneyButton = new ClickableTextureComponent(new Rectangle(num + 210, y, 64, 64), Game1.mouseCursors, new Rectangle(128, 256, 64, 64), 0.8f, false);
			this.energyButton = new ClickableTextureComponent(new Rectangle(num + num2, y, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.closeButton = new ClickableTextureComponent(new Rectangle(this.xPositionOnScreen + this.width + 10, this.yPositionOnScreen - 80, 40, 40), Game1.mouseCursors, new Rectangle(337, 494, 12, 12), 4f, false);
			this.immortalButton = new ClickableTextureComponent(new Rectangle(num + num2 * 2, y, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.timeButton = new ClickableTextureComponent(new Rectangle(num, y + 100, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			int speedY = y + 200;
			this.speedUpButton = new ClickableTextureComponent(new Rectangle(num, speedY, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.speedDownButton = new ClickableTextureComponent(new Rectangle(num + 170, speedY, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.speedResetButton = new ClickableTextureComponent(new Rectangle(num + 340, speedY, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			CheatMenu.InitializeOriginalSpeed();
		}

		// Token: 0x06002984 RID: 10628
		private Rectangle GetTextBoxBounds()
		{
			return new Rectangle(this.moneyTextBox.X, this.moneyTextBox.Y, this.moneyTextBox.Width, this.moneyTextBox.Height);
		}

		// Token: 0x06002985 RID: 10629
		public override void draw(SpriteBatch b)
		{
			b.Draw(Game1.staminaRect, new Rectangle(0, 0, Game1.viewport.Width, Game1.viewport.Height), Color.Black * 0.5f);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 373, 18, 18), this.xPositionOnScreen, this.yPositionOnScreen, this.width, this.height, Color.White, 4f, true);
			string text = "Cheat menu";
			Vector2 vector = Game1.dialogueFont.MeasureString(text);
			Utility.drawTextWithShadow(b, text, Game1.dialogueFont, new Vector2((float)(this.xPositionOnScreen + this.width / 2) - vector.X / 2f, (float)(this.yPositionOnScreen + 30)), Color.Gold, 1f, -1f, -1, -1, 1f, 3);
			Utility.drawTextWithShadow(b, "Add money:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 50), (float)(this.yPositionOnScreen + 90)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			this.moneyTextBox.Draw(b, true);
			this.addMoneyButton.draw(b);
			Utility.drawTextWithShadow(b, "Refill stamina:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 50 + 333), (float)(this.yPositionOnScreen + 90)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.energyButton.bounds.X, this.energyButton.bounds.Y, this.energyButton.bounds.Width, this.energyButton.bounds.Height, this.energyButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			Vector2 vector2 = Game1.dialogueFont.MeasureString("Refill");
			Utility.drawTextWithShadow(b, "Refill", Game1.smallFont, new Vector2((float)(this.energyButton.bounds.X + this.energyButton.bounds.Width / 2) - vector2.X / 2f, (float)this.energyButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			Utility.drawTextWithShadow(b, "Immortality:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 50 + 666), (float)(this.yPositionOnScreen + 90)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.immortalButton.bounds.X, this.immortalButton.bounds.Y, this.immortalButton.bounds.Width, this.immortalButton.bounds.Height, this.immortalButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			if (this.isImmortal)
			{
				Vector2 vector3 = Game1.dialogueFont.MeasureString("On");
				Utility.drawTextWithShadow(b, "On", Game1.smallFont, new Vector2((float)(this.immortalButton.bounds.X + this.immortalButton.bounds.Width / 2) - vector3.X / 2f, (float)this.immortalButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			}
			else
			{
				Vector2 vector4 = Game1.dialogueFont.MeasureString("Off");
				Utility.drawTextWithShadow(b, "Off", Game1.smallFont, new Vector2((float)(this.immortalButton.bounds.X + this.immortalButton.bounds.Width / 2) - vector4.X / 2f, (float)this.immortalButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			}
			Utility.drawTextWithShadow(b, "Stop time:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 50), (float)(this.yPositionOnScreen + 90 + 100)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.timeButton.bounds.X, this.timeButton.bounds.Y, this.timeButton.bounds.Width, this.timeButton.bounds.Height, this.timeButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			string timeLabel = CheatMenu.TimeFrozen ? "On" : "Off";
			Vector2 timeSize = Game1.dialogueFont.MeasureString(timeLabel);
			Utility.drawTextWithShadow(b, timeLabel, Game1.smallFont, new Vector2((float)(this.timeButton.bounds.X + this.timeButton.bounds.Width / 2) - timeSize.X / 2f, (float)this.timeButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			Utility.drawTextWithShadow(b, "Speed:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 150), (float)(this.yPositionOnScreen + 90 + 200 + 10)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.speedUpButton.bounds.X, this.speedUpButton.bounds.Y, this.speedUpButton.bounds.Width, this.speedUpButton.bounds.Height, this.speedUpButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			Utility.drawTextWithShadow(b, "Faster", Game1.smallFont, new Vector2((float)(this.speedUpButton.bounds.X + 10), (float)(this.speedUpButton.bounds.Y + 8)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.speedDownButton.bounds.X, this.speedDownButton.bounds.Y, this.speedDownButton.bounds.Width, this.speedDownButton.bounds.Height, this.speedDownButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			Utility.drawTextWithShadow(b, "Slower", Game1.smallFont, new Vector2((float)(this.speedDownButton.bounds.X + 10), (float)(this.speedDownButton.bounds.Y + 8)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.speedResetButton.bounds.X, this.speedResetButton.bounds.Y, this.speedResetButton.bounds.Width, this.speedResetButton.bounds.Height, this.speedResetButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			Utility.drawTextWithShadow(b, "Normal", Game1.smallFont, new Vector2((float)(this.speedResetButton.bounds.X + 10), (float)(this.speedResetButton.bounds.Y + 8)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			string speedText = string.Format("Current: x{0:F1}", CheatMenu.SpeedMultiplier);
			Utility.drawTextWithShadow(b, speedText, Game1.smallFont, new Vector2((float)this.speedUpButton.bounds.X, (float)(this.speedUpButton.bounds.Y + this.speedUpButton.bounds.Height + 10)), Color.LightGreen, 1f, -1f, -1, -1, 1f, 3);
			this.closeButton.draw(b);
			base.draw(b);
			base.drawMouse(b);
		}

		// Token: 0x06002986 RID: 10630
		public override void performHoverAction(int x, int y)
		{
			base.performHoverAction(x, y);
			this.addMoneyButton.tryHover(x, y, 0.1f);
			this.closeButton.tryHover(x, y, 0.1f);
		}

		// Token: 0x06002987 RID: 10631
		public override void receiveLeftClick(int x, int y, bool playSound = true)
		{
			base.receiveLeftClick(x, y, playSound);
			if (this.GetTextBoxBounds().Contains(x, y))
			{
				this.moneyTextBox.SelectMe();
				return;
			}
			if (this.closeButton.containsPoint(x, y))
			{
				Game1.exitActiveMenu();
				Game1.playSound("bigDeSelect");
			}
			if (this.addMoneyButton.containsPoint(x, y))
			{
				int num;
				if (int.TryParse(this.moneyTextBox.Text, out num))
				{
					Game1.player.Money += num;
					Game1.playSound("coin");
					Game1.addHUDMessage(new HUDMessage(string.Format("Added: {0} coins", num), 2));
					return;
				}
				Game1.addHUDMessage(new HUDMessage("Error: enter a number", 3));
			}
			if (this.energyButton.containsPoint(x, y))
			{
				Game1.player.Stamina = (float)Game1.player.MaxStamina;
				Game1.addHUDMessage(new HUDMessage("Stamina refilled", 2));
			}
			if (this.immortalButton.containsPoint(x, y))
			{
				if (this.isImmortal)
				{
					Game1.addHUDMessage(new HUDMessage("Immortality: off", 2));
					this.isImmortal = false;
					return;
				}
				Game1.addHUDMessage(new HUDMessage("Immortality: on", 2));
				this.isImmortal = true;
			}
			if (this.timeButton.containsPoint(x, y))
			{
				if (CheatMenu.TimeFrozen)
				{
					CheatMenu.TimeFrozen = false;
					Game1.addHUDMessage(new HUDMessage("Time: normal", 2));
					return;
				}
				CheatMenu.TimeFrozen = true;
				CheatMenu.FrozenTimeOfDay = Game1.timeOfDay;
				Game1.addHUDMessage(new HUDMessage("Time: stopped", 2));
			}
			if (this.speedUpButton.containsPoint(x, y))
			{
				CheatMenu.SpeedMultiplier += 0.5f;
				if (CheatMenu.SpeedMultiplier > 5f)
				{
					CheatMenu.SpeedMultiplier = 5f;
				}
				CheatMenu.ApplySpeed();
				Game1.addHUDMessage(new HUDMessage(string.Format("Speed: x{0:F1}", CheatMenu.SpeedMultiplier), 2));
			}
			if (this.speedDownButton.containsPoint(x, y))
			{
				CheatMenu.SpeedMultiplier -= 0.5f;
				if (CheatMenu.SpeedMultiplier < 0.2f)
				{
					CheatMenu.SpeedMultiplier = 0.2f;
				}
				CheatMenu.ApplySpeed();
				Game1.addHUDMessage(new HUDMessage(string.Format("Speed: x{0:F1}", CheatMenu.SpeedMultiplier), 2));
			}
			if (this.speedResetButton.containsPoint(x, y))
			{
				CheatMenu.SpeedMultiplier = 1f;
				CheatMenu.ApplySpeed();
				Game1.addHUDMessage(new HUDMessage("Speed: normal", 2));
			}
		}

		// Token: 0x06002988 RID: 10632
		public override void receiveKeyPress(Keys key)
		{
			base.receiveKeyPress(key);
			if (!this.moneyTextBox.Selected)
			{
				if (key == Keys.Escape || key == Keys.F7)
				{
					Game1.exitActiveMenu();
				}
				return;
			}
			if (key == Keys.Enter)
			{
				int num;
				if (int.TryParse(this.moneyTextBox.Text, out num))
				{
					Game1.player.Money += num;
					Game1.playSound("coin");
					Game1.exitActiveMenu();
				}
				this.moneyTextBox.Selected = false;
				return;
			}
			if (key == Keys.Escape)
			{
				this.moneyTextBox.Selected = false;
				return;
			}
			this.moneyTextBox.RecieveSpecialInput(key);
		}

		// Token: 0x06002989 RID: 10633
		public override void update(GameTime time)
		{
			base.update(time);
			this.moneyTextBox.Update();
			CheatMenu.UpdateSpeedContinuously();
		}

		// Token: 0x06002F6C RID: 12140
		static CheatMenu()
		{
			CheatMenu.SpeedMultiplier = 1f;
			CheatMenu.TimeFrozen = false;
			CheatMenu.FrozenTimeOfDay = 600;
		}

		// Token: 0x06003128 RID: 12584
		private static void InitializeOriginalSpeed()
		{
			if (CheatMenu.OriginalBaseSpeed < 0f && Game1.player != null)
			{
				CheatMenu.OriginalBaseSpeed = (float)Game1.player.speed;
				CheatMenu.OriginalAddedSpeed = (float)Game1.player.addedSpeed;
			}
		}

		// Token: 0x06003129 RID: 12585
		private static void ApplySpeed()
		{
			try
			{
				if (CheatMenu.OriginalBaseSpeed < 0f)
				{
					CheatMenu.InitializeOriginalSpeed();
				}
				int newSpeed = (int)(CheatMenu.OriginalBaseSpeed * CheatMenu.SpeedMultiplier);
				int newAddedSpeed = (int)(CheatMenu.OriginalAddedSpeed * CheatMenu.SpeedMultiplier);
				if (newSpeed < 0)
				{
					newSpeed = 0;
				}
				if (newAddedSpeed < 0)
				{
					newAddedSpeed = 0;
				}
				if (newSpeed > 20)
				{
					newSpeed = 20;
				}
				if (newAddedSpeed > 20)
				{
					newAddedSpeed = 20;
				}
				if (Game1.player != null)
				{
					Game1.player.speed = newSpeed;
					Game1.player.addedSpeed = newAddedSpeed;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600312A RID: 12586
		public static void UpdateSpeedContinuously()
		{
			try
			{
				if (Game1.player != null)
				{
					if (CheatMenu.SpeedMultiplier != 1f)
					{
						if (CheatMenu.OriginalBaseSpeed < 0f)
						{
							CheatMenu.InitializeOriginalSpeed();
						}
						int targetSpeed = (int)(CheatMenu.OriginalBaseSpeed * CheatMenu.SpeedMultiplier);
						int targetAddedSpeed = (int)(CheatMenu.OriginalAddedSpeed * CheatMenu.SpeedMultiplier);
						if (targetSpeed < 0)
						{
							targetSpeed = 0;
						}
						if (targetAddedSpeed < 0)
						{
							targetAddedSpeed = 0;
						}
						if (targetSpeed > 20)
						{
							targetSpeed = 20;
						}
						if (targetAddedSpeed > 20)
						{
							targetAddedSpeed = 20;
						}
						if (Game1.player.speed == targetSpeed && Game1.player.addedSpeed == targetAddedSpeed)
						{
							goto IL_174;
						}
						Game1.player.speed = targetSpeed;
						Game1.player.addedSpeed = targetAddedSpeed;
						try
						{
							Type typeFromHandle = typeof(Character);
							FieldInfo netSpeedField = typeFromHandle.GetField("netSpeed", BindingFlags.Instance | BindingFlags.NonPublic);
							FieldInfo netAddedSpeedField = typeFromHandle.GetField("netAddedSpeed", BindingFlags.Instance | BindingFlags.NonPublic);
							if (netSpeedField != null && netAddedSpeedField != null)
							{
								object netSpeedObj = netSpeedField.GetValue(Game1.player);
								object netAddedSpeedObj = netAddedSpeedField.GetValue(Game1.player);
								PropertyInfo valueProperty = netSpeedObj.GetType().GetProperty("Value");
								if (valueProperty != null)
								{
									valueProperty.SetValue(netSpeedObj, targetSpeed);
									valueProperty.SetValue(netAddedSpeedObj, targetAddedSpeed);
								}
							}
							goto IL_174;
						}
						catch
						{
							goto IL_174;
						}
					}
					if (CheatMenu.OriginalBaseSpeed >= 0f && (Game1.player.speed != (int)CheatMenu.OriginalBaseSpeed || Game1.player.addedSpeed != (int)CheatMenu.OriginalAddedSpeed))
					{
						Game1.player.speed = (int)CheatMenu.OriginalBaseSpeed;
						Game1.player.addedSpeed = (int)CheatMenu.OriginalAddedSpeed;
					}
				}
				IL_174:;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x040023C8 RID: 9160
		private TextBox moneyTextBox;

		// Token: 0x040023C9 RID: 9161
		private ClickableTextureComponent addMoneyButton;

		// Token: 0x040023CA RID: 9162
		private ClickableTextureComponent energyButton;

		// Token: 0x040023CB RID: 9163
		private ClickableTextureComponent closeButton;

		// Token: 0x040023CC RID: 9164
		private ClickableTextureComponent immortalButton;

		// Token: 0x040023CD RID: 9165
		private bool isImmortal;

		// Token: 0x04002A8C RID: 10892
		private ClickableTextureComponent timeButton;

		// Token: 0x04002A8F RID: 10895
		public static bool TimeFrozen;

		// Token: 0x04002A90 RID: 10896
		public static int FrozenTimeOfDay;

		// Token: 0x04002C48 RID: 11336
		public static float SpeedMultiplier;

		// Token: 0x04002C50 RID: 11344
		private ClickableTextureComponent speedUpButton;

		// Token: 0x04002C51 RID: 11345
		private ClickableTextureComponent speedDownButton;

		// Token: 0x04002C52 RID: 11346
		private ClickableTextureComponent speedResetButton;

		// Token: 0x04002C57 RID: 11351
		private static float OriginalBaseSpeed = -1f;

		// Token: 0x04002C58 RID: 11352
		private static float OriginalAddedSpeed = -1f;
	}
}
