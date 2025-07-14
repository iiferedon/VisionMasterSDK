//this assumes you have loaded the sol file 

private void button28_Click_1(object sender, EventArgs e)
{
        string strMsg = null;

        try
        {
            VmProcedure process = (VmProcedure)VmSolution.Instance["Levelling2"];
            if (process == null) return;

            string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (directory == null)
            {
                throw new InvalidOperationException("Could not determine the directory of the executing assembly.");
            }
            process.Run();
        IMVSIntensityMeasureModuTool IMFindModule = (IMVSIntensityMeasureModuTool)VmSolution.Instance["Levelling2.Intensity Measurement1"];
            if (IMFindModule == null) return;
        //IMFindModule.ModuParams.MeanLimitEnable = true;
        //IMFindModule.ModuParams.MeanLimitLow = Convert.ToDouble(levelblade2meanmin.Value);
        //IMFindModule.ModuParams.MeanLimitHigh = Convert.ToDouble(levelblade2meanmax.Value);

        IMFindModule.Run();
            var nLumMin = IMFindModule.ModuResult.LumMin;
            var nLumMax = IMFindModule.ModuResult.LumMax;
            var nLumMean = IMFindModule.ModuResult.LumMean;
            var nLumStd = IMFindModule.ModuResult.LumStd;
            var nLumHistContrast = IMFindModule.ModuResult.HistContrast;
        var nModuleStatus = (VmSolution.Instance["Levelling2.Intensity Measurement1.Outputs.ModuStatus.Value"] as Array)?.GetValue(0);
        //meanLimitEnable = new ParamItem(this, "MeanLimitEnable");
       // meanLimitLow = new ParamItem(this, "MeanLimitLow", 255.0);
       // meanLimitHigh = new ParamItem(this, "MeanLimitHigh", 255.0);
        IMVSIntensityMeasureModuCs.IMVSIntensityMeasureModuTool IMModule = (IMVSIntensityMeasureModuCs.IMVSIntensityMeasureModuTool)VmSolution.Instance["Levelling2.Intensity Measurement1"];

        vmRenderControl2.ModuleSource = IMModule;
        CustomLogger.Log("Module Status: " + Convert.ToString(nModuleStatus));
            CustomLogger.Log("LumMin: " + Convert.ToString(nLumMin));
            CustomLogger.Log("LumMax: " + Convert.ToString(nLumMax));
            CustomLogger.Log("LumMean: " + Convert.ToString(nLumMean));
            CustomLogger.Log("LumStd: " + Convert.ToString(nLumStd));
            CustomLogger.Log("HistContrast: " + Convert.ToString(nLumHistContrast));
           

    }
        catch (VmException ex)
        {
            strMsg = "ExecuteOnce failed. Error Code: " + Convert.ToString(ex.errorCode, 16);
            CustomLogger.Log(strMsg, ConsoleColor.Red);
            return;
        }
    }

private void button31_Click(object sender, EventArgs e)
{
    string strMsg = null;

    try
    {
        VmProcedure process = (VmProcedure)VmSolution.Instance["Levelling1"];
        if (process == null) return;

        string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory == null)
        {
            throw new InvalidOperationException("Could not determine the directory of the executing assembly.");
        }
        process.Run();
        IMVSIntensityMeasureModuTool IMFindModule = (IMVSIntensityMeasureModuTool)VmSolution.Instance["Levelling1.Intensity Measurement1"];
        if (IMFindModule == null) return;
        //IMFindModule.ModuParams.MeanLimitEnable = true;
        //IMFindModule.ModuParams.MeanLimitLow = Convert.ToDouble(levelblade2meanmin.Value);
        //IMFindModule.ModuParams.MeanLimitHigh = Convert.ToDouble(levelblade2meanmax.Value);

        IMFindModule.Run();
        var nLumMin = IMFindModule.ModuResult.LumMin;
        var nLumMax = IMFindModule.ModuResult.LumMax;
        var nLumMean = IMFindModule.ModuResult.LumMean;
        var nLumStd = IMFindModule.ModuResult.LumStd;
        var nLumHistContrast = IMFindModule.ModuResult.HistContrast;
        var nModuleStatus = (VmSolution.Instance["Levelling1.Intensity Measurement1.Outputs.ModuStatus.Value"] as Array)?.GetValue(0);
        //meanLimitEnable = new ParamItem(this, "MeanLimitEnable");
        // meanLimitLow = new ParamItem(this, "MeanLimitLow", 255.0);
        // meanLimitHigh = new ParamItem(this, "MeanLimitHigh", 255.0);
        IMVSIntensityMeasureModuCs.IMVSIntensityMeasureModuTool IMModule = (IMVSIntensityMeasureModuCs.IMVSIntensityMeasureModuTool)VmSolution.Instance["Levelling1.Intensity Measurement1"];

        vmRenderControl3.ModuleSource = IMModule;
        CustomLogger.Log("Module Status: " + Convert.ToString(nModuleStatus));
        CustomLogger.Log("LumMin: " + Convert.ToString(nLumMin));
        CustomLogger.Log("LumMax: " + Convert.ToString(nLumMax));
        CustomLogger.Log("LumMean: " + Convert.ToString(nLumMean));
        CustomLogger.Log("LumStd: " + Convert.ToString(nLumStd));
        CustomLogger.Log("HistContrast: " + Convert.ToString(nLumHistContrast));


    }
    catch (VmException ex)
    {
        strMsg = "ExecuteOnce failed. Error Code: " + Convert.ToString(ex.errorCode, 16);
        CustomLogger.Log(strMsg, ConsoleColor.Red);
        return;
    }
}

private void button26_Click(object sender, EventArgs e)
{
    string strMsg = null;
    
    try
    {
        VmProcedure process = (VmProcedure)VmSolution.Instance["Flow1"];
        if (process == null) return;

        string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (directory == null)
        {
            throw new InvalidOperationException("Could not determine the directory of the executing assembly.");
        }
        process.Run();
        var circleFindModule = (IMVSCircleFindModuTool)VmSolution.Instance["Flow1.Circle Search1"];
        if (circleFindModule == null) return;
        circleFindModule.Run();
        var nCenterX = circleFindModule.ModuResult.OutputCircle.CenterPoint.X;
        var nCenterY = circleFindModule.ModuResult.OutputCircle.CenterPoint.Y;
        var nModuleStatus = (VmSolution.Instance["Flow1.Circle Search1.Outputs.ModuStatus.Value"] as Array)?.GetValue(0);

        CustomLogger.Log("Module Status: " + Convert.ToString(nModuleStatus));
        CustomLogger.Log("Inner Circle X: " + Convert.ToString(nCenterX));
        CustomLogger.Log("Inner Circle Y: " + Convert.ToString(nCenterY));
      
        var circleFindModule1 = (IMVSCircleFindModuTool)VmSolution.Instance["Flow1.Circle Search2"];
        if (circleFindModule1 == null) return;
        circleFindModule1.Run();
        var nCenterX2 = circleFindModule1.ModuResult.OutputCircle.CenterPoint.X;
        var nCenterY2 = circleFindModule1.ModuResult.OutputCircle.CenterPoint.Y;
        var nModuleStatus2 = (VmSolution.Instance["Flow1.Circle Search2.Outputs.ModuStatus.Value"] as Array)?.GetValue(0);

        CustomLogger.Log("Module Status: " + Convert.ToString(nModuleStatus2));
        CustomLogger.Log("Outer Circle X: " + Convert.ToString(nCenterX2));
        CustomLogger.Log("Outer Circle Y: " + Convert.ToString(nCenterY2));
    }
    catch (VmException ex)
    {
        strMsg = "ExecuteOnce failed. Error Code: " + Convert.ToString(ex.errorCode, 16);
        CustomLogger.Log(strMsg, ConsoleColor.Red);
        return;
    }
}
