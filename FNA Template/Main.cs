using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Reflection;


namespace FNA_Template
{
    public class NewMain : Game
    {
        Assembly code;
        Microsoft.Xna.Framework.Main mainHolder;

        public NewMain()
        {
            code = Assembly.LoadFrom(Environment.CurrentDirectory + "\\Bin\\code.dll");
            foreach(var type in code.GetTypes())
            {
                if(typeof(Microsoft.Xna.Framework.Main).IsAssignableFrom(type))
                {
                    mainHolder = type.GetConstructor(new Type[] { typeof(Game) }).Invoke(new[] { this as Game }) as Microsoft.Xna.Framework.Main;
                }
            }
        }

        protected override void Initialize()
        {
            mainHolder.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            mainHolder.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            mainHolder.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            mainHolder.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
