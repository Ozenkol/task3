using System;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using Model;
using View;

namespace app
{
    class Programm
    {
        static readonly View.ConsoleView view = new();
        private static readonly DiceStore store = Model.DiceStore.Instance; 
        static readonly Controller.Controller controller = new();
        static void Main(string[] args)
        {
            controller.ValidateArgs(args);
            store.Init(args);
            view.WelcomeView();
            view.SecretWordView();
            view.FirstMoveView();
            view.DiceChooseView();
            view.DiceGameView();
        }
    }
}