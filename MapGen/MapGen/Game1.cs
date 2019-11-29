using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace MapGen
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D GroundImage;
        Texture2D IceImage;
        Vector2 TileLocation;

        List<Tile> Tiles;
        string MapDesign;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
            Tiles = new List<Tile>();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TileLocation = new Vector2(100, 100);
            GroundImage = Content.Load<Texture2D>("ground");
            IceImage = Content.Load<Texture2D>("ice");
            MapDesign = File.ReadAllText(@"C:\Users\Ani\Documents\Visual Studio 2019\Projects\MapGen\MapGen\map.txt");
            for (int i = 0; i < MapDesign.Length; i++)
            {
                if (MapDesign[i] == 'G')
                {
                    Tiles.Add(new Tile(GroundImage, TileLocation));
                    TileLocation.X += GroundImage.Width;
                }
                else if (MapDesign[i] == 'I')
                {
                    Tiles.Add(new Tile(IceImage, TileLocation));
                    TileLocation.X += IceImage.Width;
                }
                else if (MapDesign[i] == '-')
                {
                    TileLocation.Y += GroundImage.Height;
                    TileLocation.X = 100;
                }
            }
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();

            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].Draw(spriteBatch);
            }
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
