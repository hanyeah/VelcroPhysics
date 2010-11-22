using System;
using FarseerPhysics.DemoBaseXNA.Components;
using FarseerPhysics.DemoBaseXNA.Screens;
using FarseerPhysics.DemoBaseXNA.ScreenSystem;
using Microsoft.Xna.Framework;

namespace FarseerPhysics.SimpleSamplesXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FarseerPhysicsGame : Game
    {
        private GraphicsDeviceManager _graphics;

        public FarseerPhysicsGame()
        {
            Window.Title = "Farseer Physics Engine Samples Framework";
            _graphics = new GraphicsDeviceManager(this);

            _graphics.SynchronizeWithVerticalRetrace = false;
            _graphics.PreferMultiSampling = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            IsFixedTimeStep = true;

            _graphics.SynchronizeWithVerticalRetrace = false;

            //new-up components and add to Game.Components
            ScreenManager = new ScreenManager(this);
            Components.Add(ScreenManager);

            FrameRateCounter frameRateCounter = new FrameRateCounter(ScreenManager);
            frameRateCounter.DrawOrder = 101;
            Components.Add(frameRateCounter);
        }

        public ScreenManager ScreenManager { get; set; }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //Set window defaults. Parent game can override in constructor
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += WindowClientSizeChanged;

            Demo1Screen demo1 = new Demo1Screen();
            Demo2Screen demo2 = new Demo2Screen();
            Demo3Screen demo3 = new Demo3Screen();
            Demo4Screen demo4 = new Demo4Screen();
            Demo5Screen demo5 = new Demo5Screen();
            Demo6Screen demo6 = new Demo6Screen();
            Demo7Screen demo7 = new Demo7Screen();
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.AddMainMenuItem(demo1.GetTitle(), demo1);
            mainMenuScreen.AddMainMenuItem(demo2.GetTitle(), demo2);
            mainMenuScreen.AddMainMenuItem(demo3.GetTitle(), demo3);
            mainMenuScreen.AddMainMenuItem(demo4.GetTitle(), demo4);
            mainMenuScreen.AddMainMenuItem(demo5.GetTitle(), demo5);
            mainMenuScreen.AddMainMenuItem(demo6.GetTitle(), demo6);
            mainMenuScreen.AddMainMenuItem(demo7.GetTitle(), demo7);
            mainMenuScreen.AddMainMenuItem("Exit", null, true);

            ScreenManager.AddScreen(new BackgroundScreen(), null);
            ScreenManager.AddScreen(mainMenuScreen, null);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.SteelBlue);

            base.Draw(gameTime);
        }

        private void WindowClientSizeChanged(object sender, EventArgs e)
        {
            if (Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
            {
                _graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                _graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            }

            //We recreate the projection matrix to keep aspect ratio.
            ScreenManager.Camera.CreateProjection();
        }
    }
}