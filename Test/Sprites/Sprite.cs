using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test.Sprites;

public abstract class Sprite
{
    protected readonly Texture2D Texture;
    protected Vector2 Position;
    protected Color Color;
    protected Vector2 Origin => new Vector2(Position.X - (float)Texture.Width/2, Position.Y - (float)Texture.Height / 2);
    protected Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
    

    public Sprite(Texture2D texture, Vector2 position, Color color)
    {
        Texture = texture;
        Position = position;
        Color = color;
    }

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch spriteBatch);

}