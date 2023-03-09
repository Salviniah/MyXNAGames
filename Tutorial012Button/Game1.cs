using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    private bool _secondClick, runonce;
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
                Tag = 1,
            };
            

        var deleteButton =
            new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(200, 0),
                Text = "Delete",
                Tag = 2,
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


    // Event handler for the mouse click event extra

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

                if(_secondClick && _addEnabled)
                {
                    if (_timer > 0.5f)
                    {
                        _currentMouse = Mouse.GetState();
                        _objectPosition = new Vector2(_currentMouse.X, _currentMouse.Y); //set the object's position to  the position of the second click
                        var apple = new Apple(Content.Load<Texture2D>("Sprites/apple"), new Vector2(_objectPosition.X, _objectPosition.Y));
                        _gameComponents.Add(apple);
                        _timer = 0;
                        break;
                    }
                    
                }

                if (_delEnabled)
                {
                    _currentMouse = Mouse.GetState();
                    if (gameComponent is Apple apple && apple.AppRect.Contains(_currentMouse.X,_currentMouse.Y))
                    {
                        _gameComponents.RemoveAt(i);
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
        
        for (int i = _gameComponents.Count -1; i>=0; i--)
        {
            var gameComponent = _gameComponents[i];
            
            if (gameComponent is Button button && button.Tag == 2)
            {
                button.Color = Color.Red;
                if (!runonce)
                {
                    runonce = true;
                    break;
                }

                if (runonce && gameComponent is Apple) //rider telling me this code will be always false but to understand the logic, I want to keep this code 
                {
                    _gameComponents.RemoveAt(_gameComponents.Count-1);
                    
                }
            }
        } //Switch button colors

    }
    

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        _delEnabled = true;
        _addEnabled = false;
        
        for (int i = _gameComponents.Count -1; i>=0; i--)
        {
            var gameComponent = _gameComponents[i];
            
            if (gameComponent is Button button && button.Tag == 1)
            {
                button.Color = Color.Red;
                _gameComponents.RemoveAt(_gameComponents.Count-1);
            } //Switch button colors
            
           
        }
    }
}