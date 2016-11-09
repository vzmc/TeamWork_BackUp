﻿//////////////////////////////////////////////////////
//TitleSceneの選択機能
//作成時間：2016/10/13
//作成者：柏杳
//////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TeamWorkGame.Device;
using TeamWorkGame.Utility;

namespace TeamWorkGame.Scene
{
    class TitleSelect       //柏
    {
        private Timer flashTimer;
        private InputState inputState;

        private float startTextalpha;   //透明度
        private Vector2 startTextPosition;  //座標

        private float worldTextalpha;
        private Vector2 worldTextPosition;

        private float staffTextalpha;
        private Vector2 staffTextPosition;


        private Vector2 selectPosition1;
        private Vector2 selectPosition2;

        private bool isStarted;
        private int x;
        
        public TitleSelect(InputState inputState) {
            this.inputState = inputState;
            Initialize();
        }

        public void Initialize() {
            isStarted = false;
            x = 1;
            startTextalpha = 1;
            worldTextalpha = 1;
            staffTextalpha = 1;
            flashTimer = new Timer(0.2f);
            startTextPosition = new Vector2(380, 480);
            worldTextPosition = new Vector2(380, 450);
            staffTextPosition = new Vector2(380, 530);
            selectPosition1 = new Vector2(320, 440);
            selectPosition2 = new Vector2(320, 515);
        }

        public void Update() {
            Select();
            Flash();
        }

        //点滅する処理
        private void Flash() {
            flashTimer.Update();
            if (flashTimer.IsTime()) {
                if (!isStarted) {
                    if (startTextalpha == 1.0f) { startTextalpha = 0.5f; flashTimer.Initialize(); }
                    else { startTextalpha = 1.0f; flashTimer.Initialize(); }
                }
                else {
                    switch (x) {
                        case 1:
                            if (worldTextalpha == 1.0f) { worldTextalpha = 0.5f; flashTimer.Initialize(); }
                            else { worldTextalpha = 1.0f; flashTimer.Initialize(); }
                            break;
                        case 2:
                            if (staffTextalpha == 1.0f) { staffTextalpha = 0.5f; flashTimer.Initialize(); }
                            else { staffTextalpha = 1.0f; flashTimer.Initialize(); }
                            break;
                    }
                }
            }
        }

        //選択肢チェンジ機能
        private void Select() {
            if (!isStarted) { return; }
            if (inputState.IsKeyDown(Keys.Down))
            {
                if (x == 2) { return; }
                x++;
            }
            else if (inputState.IsKeyDown(Keys.Up))
            {
                if (x == 1) { return; }
                x--;
            }
        }

        //選択された選択肢は外に出す
        public int GetSelect {
            get { return x; }
        }

        //今映すのはStartかWorldとStaffか、外に表明する
        public bool GetStarted {
            get { return isStarted; }
            set { isStarted = value; }
        }


        //状況に合わせて描画する
        public void Draw(Renderer renderer)
        {
            if (!isStarted) {
                renderer.DrawTexture("GameStartText", startTextPosition, startTextalpha);
            }
            else { 
                renderer.DrawTexture("WorldText", worldTextPosition, worldTextalpha);
                renderer.DrawTexture("StaffText", staffTextPosition, staffTextalpha);
                switch (x) {
                    case 1:
                        renderer.DrawTexture("selecter", selectPosition1);
                        break;
                    case 2:
                        renderer.DrawTexture("selecter", selectPosition2);
                        break;
                }

            }

        }
    }
}
