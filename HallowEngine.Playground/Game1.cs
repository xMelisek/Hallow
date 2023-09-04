using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HallowEngine;
using HallowEngine.Core;

namespace HallowEngine.Playground
{
    public class Game1 : GameWindow
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SliceTex _stretchedSliced;
        private Texture2D _defaultTex;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _stretchedSliced = new SliceTex(Content.Load<Texture2D>("Graphics/Outline"), new Point(1, 1));
            _defaultTex = Content.Load<Texture2D>("Graphics/Outline");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _stretchedSliced.DrawSlices(_spriteBatch, new Rectangle(120, 240, 50, 50), Color.Green);
            _stretchedSliced.DrawSlices(_spriteBatch, new Rectangle(120, 300, 50, 100), Color.Green);
            _spriteBatch.Draw(_defaultTex, new Rectangle(200, 240, 50, 50), Color.White);
            _spriteBatch.Draw(_defaultTex, new Rectangle(200, 300, 50, 100), Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}