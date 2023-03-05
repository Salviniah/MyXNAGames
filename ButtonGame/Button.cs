using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ButtonGame;

public class Button
{
    private readonly Texture2D _texture;
    private Vector2 _position;
    
    public Button(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public void Update()
    {
            
    }

    public void Draw(SpriteBatch spriteBatch)
    {
       spriteBatch.Draw(_texture,_position,Color.White);
       
    }
}