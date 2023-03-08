using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tutorial012.Sprites;
using Button = Tutorial012.Controls.Button;
namespace Tutorial012;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Color _backgroundColour = Color.CornflowerBlue;
    private List<Component> _gameComponents;
    private MouseState _currentMouse;
    private bool _addEnabled, _delEnabled;
    private bool _secondClick = false;
    private Vector2 _objectPosition;
    private float _timer;
    public event EventHandler Click;
    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        var addButton =
            new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(0, 0),
                Text = "Add",
            };
            

        var deleteButton =
            new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(200, 0),
                Text = "Quit",
            };

        
        
        _gameComponents = new List<Component>()
        {
            addButton,
            deleteButton,
            
        };
        
        addButton.Click += AddButton_Click;
        deleteButton.Click += DeleteButton_Click;
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
    }


    // Event handler for the mouse click event

    protected override void Update(GameTime gameTime)
    {
        _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        for (int i = 0; i < _gameComponents.Count; i++)
        {
            var gameComponent = _gameComponents[i];

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (!_secondClick)
                {
                    //set the object's position to the position of the first click
                    _secondClick = true;
                } //Only run for clicked once

                if(_secondClick)
                {
                    if (_addEnabled)
                    {
                        //set the object's position to  the position of the second click
                        _objectPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                        var apple = new Apple(Content.Load<Texture2D>("Sprites/apple"), new Vector2(_objectPosition.X, _objectPosition.Y));
                        _gameComponents.Add(apple);
                        break;  
                    }
                }
            }
            gameComponent.Update(gameTime);
        }


        base.Update(gameTime);
        
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(_backgroundColour);
        _spriteBatch.Begin();
        foreach (var gameComponent in _gameComponents)
        {
            gameComponent.Draw(gameTime,_spriteBatch);
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        _addEnabled = true;
        _delEnabled = false;
        
        _currentMouse = Mouse.GetState();
        Click?.Invoke(this, EventArgs.Empty);

    }
    

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        Exit();
    }
}