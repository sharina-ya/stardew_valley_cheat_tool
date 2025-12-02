using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StardewValley.Menus
{
	// Token: 0x02000351 RID: 849
	public class CheatMenu : IClickableMenu
	{
		// Token: 0x0600268B RID: 9867
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
			this.immortalButton = new ClickableTextureComponent(new Rectangle(num + num2 + 165 + 50, y, 150, 40), Game1.mouseCursors, new Rectangle(0, 256, 64, 64), 0.8f, false);
		}

		// Token: 0x0600268C RID: 9868
		private Rectangle GetTextBoxBounds()
		{
			return new Rectangle(this.moneyTextBox.X, this.moneyTextBox.Y, this.moneyTextBox.Width, this.moneyTextBox.Height);
		}

		// Token: 0x0600268D RID: 9869
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
			this.closeButton.draw(b);
			base.draw(b);
			base.drawMouse(b);
		}

		// Token: 0x0600268E RID: 9870
		public override void performHoverAction(int x, int y)
		{
			base.performHoverAction(x, y);
			this.addMoneyButton.tryHover(x, y, 0.1f);
			this.closeButton.tryHover(x, y, 0.1f);
		}

		// Token: 0x0600268F RID: 9871
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
		}

		// Token: 0x06002690 RID: 9872
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

		// Token: 0x06002691 RID: 9873
		public override void update(GameTime time)
		{
			base.update(time);
			this.moneyTextBox.Update();
		}

		// Token: 0x060029A6 RID: 10662
		static CheatMenu()
		{
		}

		// Token: 0x04002064 RID: 8292
		private TextBox moneyTextBox;

		// Token: 0x04002065 RID: 8293
		private ClickableTextureComponent addMoneyButton;

		// Token: 0x04002066 RID: 8294
		private ClickableTextureComponent energyButton;

		// Token: 0x04002067 RID: 8295
		private ClickableTextureComponent closeButton;

		// Token: 0x0400221A RID: 8730
		private ClickableTextureComponent immortalButton;

		// Token: 0x040023E7 RID: 9191
		public static bool IsImmortal;
	}
}
