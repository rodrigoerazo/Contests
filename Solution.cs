﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Diagnostics;
using Deadline;
using System.Threading;

public class Solution : SolutionBase
{
    public Solution(IClient client, int time = 0)
        : base(client, time)
    { }

    public override void GetData()
    {
        base.GetData();
    }

    public override bool Act()
    {
        Result real;
        SolveMini(0);
        real = best;
        for(int i=1;i<1000000;i++)
        {
            SolveMini(i);
            real = real.PickBetter(best);
            ioClient.SaveResultIfBetter(real);
        }
        best = real;
        TakeBestAction();
        return true;
    }

    public bool SolveMini(int seed)
    {
        best = new Result(state);

        // solution

        ImproveAfter(best);
        best.CalculateQuality();
        return true;
    }

    public void ImproveAfter(Result result)
    {
        return;
    }
}
