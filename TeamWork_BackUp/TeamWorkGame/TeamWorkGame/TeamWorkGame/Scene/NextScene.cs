#region 概要
//-----------------------------------------------------------------------------
// 次のシーンの構造体
// 作成者：氷見悠人
//-----------------------------------------------------------------------------
#endregion


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamWorkGame.Scene
{
    struct NextScene
    {
        public SceneType sceneType;
        public int stageIndex;

        public NextScene(SceneType scene, int index)
        {
            sceneType = scene;
            stageIndex = index;
        }
    }
}
