using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BckGmmn.Core;
using BckGmmn.Core.Common;
using UnityEngine;
using Zenject;

namespace BckGmmn.App.Components
{
    public class Game : MonoBehaviour
    {
        [Inject] private IGame _game;

        public PlayerId Turn { get => _game.Turn; set => _game.Turn = value; }

        public PlayerId Winner => _game.Winner;
    }
}
