using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FnaTemplate;

public sealed class Main : Game
{
    public static GraphicsDeviceManager Graphics;
    public static SpriteBatch SpriteBatch;
    
    public Main()
    {
        Graphics = new GraphicsDeviceManager(this);
        Graphics.PreferredBackBufferWidth = 1280;
        Graphics.PreferredBackBufferHeight = 720;
        Graphics.PreferMultiSampling = true;

        Window.AllowUserResizing = true;
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        SpriteBatch  = new SpriteBatch(GraphicsDevice);
        
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        base.Draw(gameTime);
    }
}