using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace ButtonGame;

public class GameManager //everything gathered in a class
{
    private readonly UIManager _ui = new UIManager();

    public GameManager()
    {
        _ui.Addbutton(new Vector2(100, 100)).OnClick += Action;
        _ui.Addbutton(new Vector2(500, 100)).OnClick += Action2;
        _ui.Addbutton(new Vector2(100, 500)).OnClick += Action3;
        _ui.Addbutton(new Vector2(500, 500)).OnClick += Action4;
    }

    
    
    public void Action(object sender, EventArgs e)
    {
        _ui.Counter++;
    }
    public void Action2(object sender, EventArgs e)
    {
        _ui.Counter+= 10;
    }
    public void Action3(object sender, EventArgs e)
    {
        _ui.Counter--;
    }
    public void Action4(object sender, EventArgs e)
    {
        _ui.Counter-= 10;
    }

    public void Update()
    {
        _ui.Update();
    }

    public void Draw()
    {
        _ui.Draw();
    }
    
}