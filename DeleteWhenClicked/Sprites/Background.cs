using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Test.Sprites;

public class Background : Sprite
{
    private Vector2 _position;
    public Background(Texture2D texture) : base(texture)
    {
        _position = new Vector2(0 + Texture.Width /2 , 0 + Texture.Height /2);
    }

    public override void Update(GameTime gameTime)
    {
        // _position.X += 5;
        // if (_position.X > 800)
        // {
        //     _position.X = 0;
        // }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture,_position,Color.White);
    }
}