using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tutorial012.Controls;

namespace Tutorial012;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Color _backgroundColour = Color.CornflowerBlue;
    private List<Component> _GameComponents;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        var randomButton =
            new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(0, 0),
                Text = "0",
            };

        var quitButton =
            new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(200, 0),
                Text = "Quit",
            };
        
        _GameComponents = new List<Component>()
        {
            randomButton,
            quitButton,
        };
        
        randomButton.Click += RandomButton_Click;
        quitButton.Click += QuitButton_Click;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        

    }

    private void RandomButton_Click(object sender, EventArgs e)
    {
        
    } private void QuitButton_Click(object sender, EventArgs e)
    {
        Exit();
    }

    protected override void Update(GameTime gameTime)
    {
        foreach (var gameComponent in _GameComponents)
        {
            gameComponent.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_backgroundColour);
        _spriteBatch.Begin();
        foreach (var gameComponent in _GameComponents)
        {
            gameComponent.Draw(gameTime,_spriteBatch);
        }
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}