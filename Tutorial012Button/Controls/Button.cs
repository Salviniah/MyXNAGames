using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tutorial012.Controls;

public class Button : Component
{
    #region Fields
    private MouseState _currentMouse;
    private SpriteFont _font;
    private bool _isHovering;
    private MouseState _previousMouse;
    private Texture2D _texture;
    public Color Color = Color.Red;
    private bool isClicked;
    #endregion  

    #region Properties

    public event EventHandler Click;
    public bool Clicked { get; private set; }
    public Color FontColour { get; set; }
    public Vector2 Position { get; set; }
    public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); //rect for text box
    public string Text { get; set; }
    public int Tag { get; set; }
    #endregion


    #region Methods

    public Button(Texture2D texture, SpriteFont font)
    {
        _texture = texture;
        _font = font;
        FontColour = Color.Black;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        // var colour = Color.White;

        if (_isHovering && !isClicked)
        {
            Color = Color.Gray;
        }


        spriteBatch.Draw(_texture,Rectangle,Color);

        if (!string.IsNullOrEmpty(Text))
        {
             var x = (Rectangle.X + (Rectangle.Width / 2) - (_font.MeasureString(Text).X / 2)); 
            var y = (Rectangle.Y + (Rectangle.Height / 2) - (_font.MeasureString(Text).Y / 2));
            
            spriteBatch.DrawString(_font,Text,new Vector2(x,y),FontColour);
        }
    }

    public override void Update(GameTime gameTime)
    {
        _previousMouse = _currentMouse;
        _currentMouse = Mouse.GetState();

        // if (!_isHovering)
        // {
        //     Color = Color.Red;
        // }
        var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
        _isHovering = false;

        if (mouseRectangle.Intersects(Rectangle))
        {
            _isHovering = true;
            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed) //clicked 
            {
                Click?.Invoke(this, EventArgs.Empty);
                isClicked = true;
                Color = Color.Green;
            }
        }
        else
        {

            if (!_isHovering && !isClicked)
            {
                Color = Color.Red;
            }
        }
    }
    #endregion
}