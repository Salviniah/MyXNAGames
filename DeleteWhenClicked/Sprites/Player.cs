using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test.Sprites;

public class Player : Sprite
{
    private Color _color = Color.Red;
    public MouseState CurrentMouse;
    private bool _isHovering;
    private MouseState _previousMouse;
    public Rectangle MouseRectangle => new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);
    public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); //rect for text box

    public event EventHandler Click;
    public bool Clicked { get; private set; }
    public Color PenColour { get; set; }

    public Player(Texture2D texture) : base(texture)
    {
        //_position = new Vector2(0 + Texture.Width /2 , 0 + Texture.Height /2);
        PenColour = Color.Black;
    }

    public override void Update(GameTime gameTime)
    {
        _previousMouse = CurrentMouse;
        CurrentMouse = Mouse.GetState();

        var mouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);
        _isHovering = false;

        if (mouseRectangle.Intersects(Rectangle))
        {
            _isHovering = true;
            if (CurrentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
            {

                if (Click != null)
                {
                    Click(this, EventArgs.Empty);
                }

            }
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        var colour = Color.White;
        if (_isHovering) colour = Color.Red;
        spriteBatch.Draw(Texture,Rectangle,colour); 
        
        
    }
}