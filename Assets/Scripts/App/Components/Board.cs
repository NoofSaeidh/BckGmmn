using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BckGmmn.Core;
using UnityEngine;
using Zenject;

namespace BckGmmn.App.Components
{
    public class Board : MonoBehaviour
    {
        [Inject] private IBoard _board;

        //private void FixedUpdate()
        //{

        //}
    }
}
