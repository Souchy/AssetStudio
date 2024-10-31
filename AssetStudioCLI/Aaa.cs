using AssetStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetStudioCLI;
public class Aaa
{

    public static int ExtractBundleFile(FileReader reader, string savePath)
    {
        //StatusStripUpdate($"Decompressing {reader.FileName} ...");
        var bundleFile = new BundleFile(reader);
        reader.Dispose();
        if (bundleFile.fileList.Length > 0)
        {
            var extractPath = Path.Combine(savePath, reader.FileName + "_unpacked");
            return ExtractStreamFile(extractPath, bundleFile.fileList);
        }
        return 0;
    }

    public static int ExtractStreamFile(string extractPath, StreamFile[] fileList)
    {
        int extractedCount = 0;
        foreach (var file in fileList)
        {
            var filePath = Path.Combine(extractPath, file.path);
            var fileDirectory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }
            if (!File.Exists(filePath))
            {
                using (var fileStream = File.Create(filePath))
                {
                    file.stream.CopyTo(fileStream);
                }
                extractedCount += 1;
            }
            file.stream.Dispose();
        }
        return extractedCount;
    }

}
