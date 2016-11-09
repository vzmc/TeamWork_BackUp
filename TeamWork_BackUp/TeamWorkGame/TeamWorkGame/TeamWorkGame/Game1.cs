/////////////////////////////////////////////////
// Game1
// �ŏI�C�����ԁF2016�N11��3��
// By�@���J��C��
/////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TeamWorkGame.Actor;
using TeamWorkGame.Def;
using TeamWorkGame.Device;
using TeamWorkGame.Scene;
using TeamWorkGame.Utility;

namespace TeamWorkGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //�t�B�[���h
        private GraphicsDeviceManager graphicsDeviceManager;//�O���t�B�b�N�@��Ǘ���
        private GameDevice gameDevice;                      //�Q�[���f�o�C�X
        private Renderer renderer;                          //�`��I�u�W�F�N�g�̐錾
        private Sound sound;                                //Sound�Ǘ�
        private SceneManager sceneManager;                  //�V�[���Ǘ���

        public Game1()
        {
            //�O���t�B�b�N�@��Ǘ��҂̎��̂𐶐�
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.PreferredBackBufferWidth = Parameter.ScreenWidth;       //��ʉ���
            graphicsDeviceManager.PreferredBackBufferHeight = Parameter.ScreenHeight;      //��ʏc��

            //�R���e���c�f�[�^�̕ۑ��t�H���_��Content�ɐݒ�
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
            //�Q�[���f�o�C�X�̎��̐���
            gameDevice = new GameDevice(Content, GraphicsDevice);

            sound = gameDevice.GetSound();

            //�`��I�u�W�F�N�g�̐錾
            renderer = gameDevice.GetRenderer();

            //csv�Ǘ��̂��ߍ폜
            //MapManager.Init();
            sceneManager = new SceneManager();
            //IScene playScene = new PlayScene(gameDevice);
            sceneManager.Add(SceneType.Title, new Title(gameDevice));
            
            //�X�e�[�W�N���X�̒ǉ�
            //�t������
            //�Q�O�P�U�N�P�O���P�Q��
            sceneManager.Add(SceneType.Stage, new Stage(gameDevice));
            //�X�e�[�W�I���̒ǉ�
            //�t������
            //�Q�O�P�U�N�P�O���P�R��
            sceneManager.Add(SceneType.SmallStage, new SmallStage(gameDevice));
            sceneManager.Add(SceneType.PlayScene, new PlayScene(gameDevice, 0));
            sceneManager.Add(SceneType.Ending, new Ending(gameDevice));


            sceneManager.Change(new NextScene(SceneType.Title, -1));

            base.Window.Title = "�v�����e�E�X�̉�";

            base.Initialize();  //��΂ɏ�����
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            renderer.LoadTexture("hero");
            renderer.LoadTexture("light_off");
            //renderer.LoadTexture("light_on");
            renderer.LoadTexture("TileMapSource");
            renderer.LoadTexture("fire");
            renderer.LoadTexture("tree");
            renderer.LoadTexture("ice");
            renderer.LoadTexture("iron");
            renderer.LoadTexture("title");
            renderer.LoadTexture("clear");
            renderer.LoadTexture("goal");
            renderer.LoadTexture("coal");//������C
            renderer.LoadTexture("number");//������C
            renderer.LoadTexture("straw");
            //���[���h�}�b�v�̒ǉ�
            //�t������
            //�Q�O�P�U�N�P�O���P�Q��
            renderer.LoadTexture("worldmap");
            //�X�e�[�W�I�����̒ǉ�
            //�w�i�̒ǉ�
            //�t������
            //�Q�O�P�U�N�P�O���P�R��
            renderer.LoadTexture("smallmap");
            renderer.LoadTexture("frame");
            renderer.LoadTexture("forestBG");
            

            //by���J��C��  11/3
            renderer.LoadTexture("FireMeter");
            renderer.LoadTexture("iceAnime");
            renderer.LoadTexture("ironAnime");
            renderer.LoadTexture("wood");
            renderer.LoadTexture("playerAnime");
            renderer.LoadTexture("throwAnime");
            renderer.LoadTexture("sand");
            renderer.LoadTexture("backGround");
            renderer.LoadTexture("woodAnime");
            renderer.LoadTexture("strawAnime");

            //��
            renderer.LoadTexture("ClearWindow");
            renderer.LoadTexture("ClearWindow2");
            renderer.LoadTexture("selecter");
            renderer.LoadTexture("GameStartText");
            renderer.LoadTexture("WorldText");
            renderer.LoadTexture("StaffText");
            renderer.LoadTexture("balloon");
            

            //renderer.LoadTexture("puddle");

            renderer.LoadTexture("water");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            renderer.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // �I�������@Allows the game to exit
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                || (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                this.Exit();
            }

            //�Q�[���f�o�C�X�X�V
            gameDevice.Update(gameTime);

            //�V�[���̍X�V
            sceneManager.Update(gameTime);

            base.Update(gameTime);  //��΂ɏ�����
        }

        /// <summary>
        /// �Q�[���S�̂ŕ`��A�`��J�n�ƏI���͂����Ŏ��s����@BY���@10/13
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //�`��N���A���̐F��ݒ�
            GraphicsDevice.Clear(Color.CornflowerBlue);

            renderer.Begin();
            //�V�[���̕`��
            sceneManager.Draw(gameTime, renderer);

            renderer.End();
            base.Draw(gameTime);    //��΂ɏ�����
        }
    }
}
