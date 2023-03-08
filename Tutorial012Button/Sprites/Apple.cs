using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tutorial012.Sprites;

public class Apple : Component
{
    private Texture2D _texture;
    private Vector2 _Position;
    private Color _color;
    public Rectangle AppRect => new Rectangle((int)_Position.X, (int)_Position.Y, _texture.Width, _texture.Height);
    
    public Apple(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _Position = position;
    }


    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture,AppRect,Color.White);    
    }

    public override void Update(GameTime gameTime)
    {
        
    }
}