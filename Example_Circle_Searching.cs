(Innerx, Innery, Outerx, Outery) = VM_Locate_Disc();

    if (Innerx != 0 || Innery != 0)
    {
        //found
 
    }
    else
    {
         //not found
    }


private (float,float,float,float) VM_Locate_Disc()
{
    try
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        VmProcedure process = (VmProcedure)VmSolution.Instance["Flow1"];
        

        string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory == null)
        {
            throw new InvalidOperationException("Could not determine the directory of the executing assembly.");
        }
        process.Run();
        var circleFindModule = (IMVSCircleFindModuTool)VmSolution.Instance["Flow1.Circle Search1"];
       
        circleFindModule.Run();
        float nCenterX = circleFindModule.ModuResult.OutputCircle.CenterPoint.X;
        float nCenterY = circleFindModule.ModuResult.OutputCircle.CenterPoint.Y;
        var nModuleStatus = (VmSolution.Instance["Flow1.Circle Search1.Outputs.ModuStatus.Value"] as Array)?.GetValue(0);
        
        if (nCenterX != 0 || nCenterY != 0)
        {
            CustomLogger.Log("Module Status: " + Convert.ToString(nModuleStatus));
            CustomLogger.Log("Inner Circle X: " + Convert.ToString(nCenterX));
            CustomLogger.Log("Inner Circle Y: " + Convert.ToString(nCenterY));
        }
        

        var circleFindModule1 = (IMVSCircleFindModuTool)VmSolution.Instance["Flow1.Circle Search2"];
        
        circleFindModule1.Run();
        float nCenterX2 = circleFindModule1.ModuResult.OutputCircle.CenterPoint.X;
        float nCenterY2 = circleFindModule1.ModuResult.OutputCircle.CenterPoint.Y;
        var nModuleStatus2 = (VmSolution.Instance["Flow1.Circle Search2.Outputs.ModuStatus.Value"] as Array)?.GetValue(0);

        if (nCenterX2 != 0 || nCenterY2 != 0)
            {
            CustomLogger.Log("Module Status: " + Convert.ToString(nModuleStatus2));
            CustomLogger.Log("Outer Circle X: " + Convert.ToString(nCenterX2));
            CustomLogger.Log("Outer Circle Y: " + Convert.ToString(nCenterY2));
        }

        stopwatch.Stop();
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        CustomLogger.Log($"Scan Time: {elapsedMilliseconds} ms", ConsoleColor.Cyan);
        return (nCenterX, nCenterY, nCenterX2, nCenterY2);
    }
    catch (VmException ex)
    {
        CustomLogger.Log("ExecuteOnce failed. Error Code: " + Convert.ToString(ex.errorCode, 16), ConsoleColor.Red);
        return (0,0,0,0);
    }
    
}
