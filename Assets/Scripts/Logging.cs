using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Logging
{
    public static void Write(object str)
    {
        using (var file = new StreamWriter(Application.dataPath.ToString() + "/Log.txt", true))
        {
            file.WriteLine(str);
        }
    }
}
