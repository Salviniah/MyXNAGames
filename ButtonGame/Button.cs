using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ButtonGame;

public class Button
{
    private readonly Texture2D _texture;
    private Vector2 _position;
    private readonly Rectangle _rect;
    private Color _shade = Color.White;


    private MouseState _lastMouseState = Globals.LastMouseState;

    private MouseState _currentMouse = Globals.MouseState;
    
    public Button(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
        _rect = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
    }

    public void Update()
    {
        _lastMouseState = _currentMouse;
        _currentMouse = Mouse.GetState();
        Rectangle cursor = new(_currentMouse.Position.X, _currentMouse.Position.Y, 1, 1);

        if (Globals.MouseCursor.Intersects(_rect))
        {
            _shade = Color.DarkGray;
            if (Globals.Clicked)
            {
                Click();
            }
            
        }
        else
        {
            _shade = Color.White;
        }
    }

    public event EventHandler OnClick;

    private void Click ()
    {
        OnClick?.Invoke(this,EventArgs.Empty);
    }

   
    

    public void Draw()
    {
       Globals.SpriteBatch.Draw(_texture,_position,_shade);
    }
}