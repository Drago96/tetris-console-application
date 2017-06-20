﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.Contracts
{
    interface IScoreInfo
    {
        int Level { get; set; }

        int Score { get; set; }

        int LinesCleared { get; set; }
    } 
}
