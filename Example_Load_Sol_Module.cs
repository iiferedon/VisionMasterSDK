private void button22_Click(object sender, EventArgs e)
{
   
      
    try
    {
        string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        if (directory == null)
        {
            throw new InvalidOperationException("Could not determine the directory of the executing assembly.");
        }
        string fileName = "Circle.sol";
        string fullPath = Path.Combine(directory, fileName);
        CustomLogger.Log($"Attempting to load file from: {fullPath}", ConsoleColor.Yellow);
        this.Enabled = false;
        VmSolution.Load(fullPath);

        
        CustomLogger.Log("Loaded Module", ConsoleColor.Green);
        IMVSCircleFindModuTool circleFindModule = (IMVSCircleFindModuTool)VmSolution.Instance["Flow1.Circle Search1"];
        vmRenderControl1.ModuleSource = circleFindModule;
    }
    catch (VmException ex)
    {
        CustomLogger.Log($"LoadSolution failed. Error Code: "+ Convert.ToString(ex.errorCode, 16), ConsoleColor.Red);
        return;
    }
    finally
    {
        this.Enabled = true;
    }

}
