using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ButtonGame;

public class UIManager
{
       private Texture2D ButtonTexture { get; }
       private SpriteFont Font { get; }
       public List<Button> Buttons = new List<Button>();
       public int Counter { get; set; } 
       
       public UIManager()
       {
           ButtonTexture = Globals.Content.Load<Texture2D>("button");
           Font = Globals.Content.Load<SpriteFont>("Font");
       }

       public Button Addbutton(Vector2 pos) //initialize button add to the list and then return the button
       {
           Button button = new Button(ButtonTexture, pos);
           Buttons.Add(button);
           return button;
       }

       public void Update()
       {
           foreach (var button in Buttons)
           {
               button.Update();
           }
       }

       public void Draw()
       {
           foreach (var button in Buttons)
           {
               button.Draw();
           }
           
           Globals.SpriteBatch.DrawString(Font,Counter.ToString(),new Vector2(10,10),Color.Black);
       }
}