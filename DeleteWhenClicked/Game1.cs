using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Test.Sprites;

namespace Test;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private List<Sprite> _sprites;
    public static ContentManager ContentManager;
    private Texture2D _texture;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ContentManager = Content;
        _texture = ContentManager.Load<Texture2D>("Player");

        #region Initialize Players and assign click event
        var Player2 = new Player(_texture) { Position = new Vector2(900,250), };
        var Player3 = new Player(_texture) { Position = new Vector2(100, 100), };
        var Player4 = new Player(_texture) { Position = new Vector2(300, 500), };
        var Player5 = new Player(_texture) { Position = new Vector2(700, 700), };
        Player2.Click += Player_Click;
        Player3.Click += Player_Click;
        Player4.Click += Player_Click;
        Player5.Click += Player_Click;
        #endregion
        
        _sprites = new List<Sprite>()
        {
            
            Player2,
            Player3,
            Player4,
            Player5,
            
        };
        base.Initialize();
    }

    private void Player_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < _sprites.Count; i++) 
        {
            if (_sprites[i] is Player player && player.Rectangle.Contains(player.CurrentMouse.X,player.CurrentMouse.Y))
            {
                _sprites.RemoveAt(i);
                break;
                
            }
        }
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        for (int i = _sprites.Count - 1; i >= 0; i--) //from 4 to 0
        {
            var sprite = _sprites[i];
            sprite.Update(gameTime);
        }

        
        // TODO: Add your update logic here
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        foreach (var sprite in _sprites)
        {
            sprite.Draw(_spriteBatch);
        }
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}