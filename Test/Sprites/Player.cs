using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test.Sprites;

public class Player : Sprite
{
    private Color _color = Color.Red;
    public Player(Texture2D texture, Vector2 position, Color color) : base(texture, position, color)
    {
        color = _color;
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture,Position,null,Color,0,Origin,1,SpriteEffects.None,1);
        spriteBatch.Draw(Texture,Position,null,Color.Black,0,Origin,1,SpriteEffects.None,2);
    }
}