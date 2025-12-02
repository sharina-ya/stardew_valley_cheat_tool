using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley.TerrainFeatures;

namespace StardewValley.Menus
{
	// Token: 0x02000351 RID: 849
	public class CheatMenu : IClickableMenu
	{
		// Token: 0x0600268B RID: 9867 RVA: 0x00241F3C File Offset: 0x0024013C
		public CheatMenu() : base(Game1.viewport.Width / 2 - (1000 + IClickableMenu.borderWidth * 2) / 2, Game1.viewport.Height / 2 - (600 + IClickableMenu.borderWidth * 2) / 2, 1000 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, false)
		{
			int num = this.xPositionOnScreen + 50;
			int num2 = this.yPositionOnScreen + 130;
			int num3 = 333;
			this.moneyTextBox = new TextBox(Game1.content.Load<Texture2D>("LooseSprites\\textBox"), null, Game1.smallFont, Game1.textColor)
			{
				X = num,
				Y = num2,
				Width = 200,
				Height = 60,
				Text = "1000"
			};
			this.addMoneyButton = new ClickableTextureComponent(new Rectangle(num + 210, num2, 64, 64), Game1.mouseCursors, new Rectangle(128, 256, 64, 64), 0.8f, false);
			this.energyButton = new ClickableTextureComponent(new Rectangle(num + num3, num2, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.closeButton = new ClickableTextureComponent(new Rectangle(this.xPositionOnScreen + this.width + 10, this.yPositionOnScreen - 80, 40, 40), Game1.mouseCursors, new Rectangle(337, 494, 12, 12), 4f, false);
			this.immortalButton = new ClickableTextureComponent(new Rectangle(num + num3 + 165 + 50, num2, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.oneHitKillButton = new ClickableTextureComponent(new Rectangle(num + num3 * 2 + 80, num2, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			this.inventorySizeTextBox = new TextBox(Game1.content.Load<Texture2D>("LooseSprites\\textBox"), null, Game1.smallFont, Game1.textColor)
			{
				X = num + num3 + 165 + 50,
				Y = num2 + 80,
				Width = 200,
				Height = 60,
				Text = "36"
			};
			this.inventorySizeButton = new ClickableTextureComponent(new Rectangle(num + num3 + 165 + 50 + 210, num2 + 80, 64, 64), Game1.mouseCursors, new Rectangle(128, 256, 64, 64), 0.8f, false);
			int num4 = num2 + 80 + 100;
			this.autoWaterButton = new ClickableTextureComponent(new Rectangle(num + num3 + 165 + 50, num4, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
			int y = num4 + 80;
			this.growAllButton = new ClickableTextureComponent(new Rectangle(num + num3 + 165 + 50, y, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
		}

		// Token: 0x0600268C RID: 9868 RVA: 0x00018CE2 File Offset: 0x00016EE2
		private Rectangle GetTextBoxBounds()
		{
			return new Rectangle(this.moneyTextBox.X, this.moneyTextBox.Y, this.moneyTextBox.Width, this.moneyTextBox.Height);
		}

		// Token: 0x0600268D RID: 9869 RVA: 0x00242274 File Offset: 0x00240474
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
			Utility.drawTextWithShadow(b, "Immortality:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 50 + 333 + 165 + 50), (float)(this.yPositionOnScreen + 90)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.immortalButton.bounds.X, this.immortalButton.bounds.Y, this.immortalButton.bounds.Width, this.immortalButton.bounds.Height, this.immortalButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			if (CheatMenu.IsImmortal)
			{
				Vector2 vector3 = Game1.dialogueFont.MeasureString("On");
				Utility.drawTextWithShadow(b, "On", Game1.smallFont, new Vector2((float)(this.immortalButton.bounds.X + this.immortalButton.bounds.Width / 2) - vector3.X / 2f, (float)this.immortalButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			}
			else
			{
				Vector2 vector4 = Game1.dialogueFont.MeasureString("Off");
				Utility.drawTextWithShadow(b, "Off", Game1.smallFont, new Vector2((float)(this.immortalButton.bounds.X + this.immortalButton.bounds.Width / 2) - vector4.X / 2f, (float)this.immortalButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			}
			Utility.drawTextWithShadow(b, "One Hit Kill:", Game1.smallFont, new Vector2((float)(this.xPositionOnScreen + 50 + 666 + 80), (float)(this.yPositionOnScreen + 90)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.oneHitKillButton.bounds.X, this.oneHitKillButton.bounds.Y, this.oneHitKillButton.bounds.Width, this.oneHitKillButton.bounds.Height, this.oneHitKillButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			if (CheatMenu.IsOneHitKill)
			{
				Vector2 vector5 = Game1.dialogueFont.MeasureString("On");
				Utility.drawTextWithShadow(b, "On", Game1.smallFont, new Vector2((float)(this.oneHitKillButton.bounds.X + this.oneHitKillButton.bounds.Width / 2) - vector5.X / 2f, (float)this.oneHitKillButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			}
			else
			{
				Vector2 vector6 = Game1.dialogueFont.MeasureString("Off");
				Utility.drawTextWithShadow(b, "Off", Game1.smallFont, new Vector2((float)(this.oneHitKillButton.bounds.X + this.oneHitKillButton.bounds.Width / 2) - vector6.X / 2f, (float)this.oneHitKillButton.bounds.Y), Color.White, 1f, -1f, -1, -1, 1f, 3);
			}
			Utility.drawTextWithShadow(b, "Inventory size:", Game1.smallFont, new Vector2((float)this.inventorySizeTextBox.X, (float)(this.inventorySizeTextBox.Y - 40)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			this.inventorySizeTextBox.Draw(b, true);
			this.inventorySizeButton.draw(b);
			Utility.drawTextWithShadow(b, "Auto water crops:", Game1.smallFont, new Vector2((float)this.autoWaterButton.bounds.X, (float)(this.autoWaterButton.bounds.Y - 40)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.autoWaterButton.bounds.X, this.autoWaterButton.bounds.Y, this.autoWaterButton.bounds.Width, this.autoWaterButton.bounds.Height, this.autoWaterButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			Utility.drawTextWithShadow(b, "Water All", Game1.smallFont, new Vector2((float)(this.autoWaterButton.bounds.X + 10), (float)this.autoWaterButton.bounds.Y + 10f), Color.White, 1f, -1f, -1, -1, 1f, 3);
			Utility.drawTextWithShadow(b, "Grow all crops:", Game1.smallFont, new Vector2((float)this.growAllButton.bounds.X, (float)(this.growAllButton.bounds.Y - 40)), Color.White, 1f, -1f, -1, -1, 1f, 3);
			IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), this.growAllButton.bounds.X, this.growAllButton.bounds.Y, this.growAllButton.bounds.Width, this.growAllButton.bounds.Height, this.growAllButton.containsPoint(Game1.getMouseX(), Game1.getMouseY()) ? Color.Wheat : Color.White, 4f, false);
			Utility.drawTextWithShadow(b, "Grow All", Game1.smallFont, new Vector2((float)(this.growAllButton.bounds.X + 10), (float)this.growAllButton.bounds.Y + 10f), Color.White, 1f, -1f, -1, -1, 1f, 3);
			this.closeButton.draw(b);
			base.draw(b);
			base.drawMouse(b);
		}

		// Token: 0x0600268E RID: 9870 RVA: 0x00242B98 File Offset: 0x00240D98
		public override void performHoverAction(int x, int y)
		{
			base.performHoverAction(x, y);
			this.addMoneyButton.tryHover(x, y, 0.1f);
			this.closeButton.tryHover(x, y, 0.1f);
			this.autoWaterButton.tryHover(x, y, 0.1f);
			this.growAllButton.tryHover(x, y, 0.1f);
		}

		// Token: 0x0600268F RID: 9871 RVA: 0x00242BF8 File Offset: 0x00240DF8
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
				if (CheatMenu.IsImmortal)
				{
					Game1.addHUDMessage(new HUDMessage("Immortality: off", 2));
					CheatMenu.IsImmortal = false;
					return;
				}
				Game1.addHUDMessage(new HUDMessage("Immortality: on", 2));
				CheatMenu.IsImmortal = true;
			}
			if (this.oneHitKillButton.containsPoint(x, y))
			{
				if (CheatMenu.IsOneHitKill)
				{
					Game1.addHUDMessage(new HUDMessage("One Hit Kill: off", 2));
					CheatMenu.IsOneHitKill = false;
					return;
				}
				Game1.addHUDMessage(new HUDMessage("One Hit Kill: on", 2));
				CheatMenu.IsOneHitKill = true;
			}
			if (this.inventorySizeButton.containsPoint(x, y))
			{
				int num2;
				if (int.TryParse(this.inventorySizeTextBox.Text, out num2))
				{
					if (num2 >= 12 && num2 <= 36)
					{
						Game1.player.MaxItems = num2;
						while (Game1.player.Items.Count < num2)
						{
							Game1.player.Items.Add(null);
						}
						if (Game1.player.Items.Count > num2)
						{
							for (int i = Game1.player.Items.Count - 1; i >= num2; i--)
							{
								Game1.player.Items.RemoveAt(i);
							}
						}
						Game1.playSound("coin");
						Game1.addHUDMessage(new HUDMessage(string.Format("Inventory size: {0}", num2), 2));
						return;
					}
					Game1.addHUDMessage(new HUDMessage("Enter 12-36", 3));
					return;
				}
				else
				{
					Game1.addHUDMessage(new HUDMessage("Error: enter a number", 3));
				}
			}
			if (this.autoWaterButton.containsPoint(x, y))
			{
				this.WaterAllCrops();
			}
			if (this.growAllButton.containsPoint(x, y))
			{
				this.GrowAllCrops();
			}
		}

		// Token: 0x06002690 RID: 9872 RVA: 0x00242E88 File Offset: 0x00241088
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

		// Token: 0x06002691 RID: 9873 RVA: 0x00018D15 File Offset: 0x00016F15
		public override void update(GameTime time)
		{
			base.update(time);
			this.moneyTextBox.Update();
			this.inventorySizeTextBox.Update();
		}

		// Token: 0x06002692 RID: 9874 RVA: 0x00003371 File Offset: 0x00001571
		static CheatMenu()
		{
		}

		// Token: 0x06002693 RID: 9875 RVA: 0x00242F20 File Offset: 0x00241120
		private void WaterAllCrops()
		{
			if (Game1.currentLocation == null)
			{
				Game1.addHUDMessage(new HUDMessage("No location found", 3));
				return;
			}
			int num = 0;
			int num2 = 0;
			try
			{
				foreach (KeyValuePair<Vector2, TerrainFeature> keyValuePair in Game1.currentLocation.terrainFeatures.Pairs)
				{
					HoeDirt hoeDirt;
					if ((hoeDirt = (keyValuePair.Value as HoeDirt)) != null)
					{
						num2++;
						if (hoeDirt.needsWatering())
						{
							hoeDirt.state.Value = 1;
							num++;
						}
					}
				}
				if (num > 0)
				{
					Game1.playSound("slosh");
					Game1.addHUDMessage(new HUDMessage(string.Format("Watered {0} crops", num), 2));
				}
				else if (num2 > 0)
				{
					Game1.addHUDMessage(new HUDMessage(string.Format("All {0} crops already watered", num2), 1));
				}
				else
				{
					Game1.addHUDMessage(new HUDMessage("No crops found on this map", 1));
				}
			}
			catch (Exception ex)
			{
				Game1.addHUDMessage(new HUDMessage("Error: " + ex.Message, 3));
			}
		}

		// Token: 0x06002694 RID: 9876 RVA: 0x00243050 File Offset: 0x00241250
		private void GrowAllCrops()
		{
			if (Game1.currentLocation == null)
			{
				Game1.addHUDMessage(new HUDMessage("No location found", 3));
				return;
			}
			int num = 0;
			int num2 = 0;
			try
			{
				foreach (KeyValuePair<Vector2, TerrainFeature> keyValuePair in Game1.currentLocation.terrainFeatures.Pairs)
				{
					HoeDirt hoeDirt;
					if ((hoeDirt = (keyValuePair.Value as HoeDirt)) != null && hoeDirt.crop != null)
					{
						num2++;
						int num3 = hoeDirt.crop.phaseDays.Count - 1;
						if (hoeDirt.crop.currentPhase.Value < num3 && !hoeDirt.crop.fullyGrown.Value)
						{
							hoeDirt.crop.currentPhase.Value = num3;
							hoeDirt.crop.fullyGrown.Value = true;
							hoeDirt.crop.dayOfCurrentPhase.Value = 0;
							num++;
						}
					}
				}
				if (num > 0)
				{
					Game1.playSound("coin");
					Game1.addHUDMessage(new HUDMessage(string.Format("Grew {0} crops to full maturity", num), 2));
				}
				else if (num2 > 0)
				{
					Game1.addHUDMessage(new HUDMessage(string.Format("All {0} crops already fully grown", num2), 1));
				}
				else
				{
					Game1.addHUDMessage(new HUDMessage("No crops found on this map", 1));
				}
			}
			catch (Exception ex)
			{
				Game1.addHUDMessage(new HUDMessage("Error: " + ex.Message, 3));
			}
		}

		// Token: 0x04002064 RID: 8292
		private TextBox moneyTextBox;

		// Token: 0x04002065 RID: 8293
		private ClickableTextureComponent addMoneyButton;

		// Token: 0x04002066 RID: 8294
		private ClickableTextureComponent energyButton;

		// Token: 0x04002067 RID: 8295
		private ClickableTextureComponent closeButton;

		// Token: 0x04002068 RID: 8296
		private ClickableTextureComponent immortalButton;

		// Token: 0x04002069 RID: 8297
		public static bool IsImmortal;

		// Token: 0x0400206A RID: 8298
		private ClickableTextureComponent oneHitKillButton;

		// Token: 0x0400206B RID: 8299
		public static bool IsOneHitKill;

		// Token: 0x0400206C RID: 8300
		private TextBox inventorySizeTextBox;

		// Token: 0x0400206D RID: 8301
		private ClickableTextureComponent inventorySizeButton;

		// Token: 0x0400206E RID: 8302
		private ClickableTextureComponent autoWaterButton;

		// Token: 0x0400206F RID: 8303
		private ClickableTextureComponent growAllButton;
	}
}
