using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test.Sprites;

public abstract class Sprite
{
    protected readonly Texture2D Texture;
    public Vector2 Position;



    public Sprite(Texture2D texture)
    {
        Texture = texture;
       
        
    }

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch spriteBatch);

}