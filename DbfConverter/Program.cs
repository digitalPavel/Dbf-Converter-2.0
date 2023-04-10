using System.Text;
using System.Collections;
using System.Data;
using DbfConverterImplementation;

namespace DbfConverter; 

public class Programs
{
    public static void Main(string[] args)
    {
        // Get the path of the DBF file from the command line arguments
        string dbfPath = args[1];

        DbfInBytes convertDbf = new DbfInBytes();

        // Read the contents of the DBF file into a byte array
        byte[] allBytes = convertDbf.ReturnFileInBytes(dbfPath);
        // Extract the header section of the DBF file and parse it to create a list of column descriptors
        byte[] headerBytes = convertDbf.ReturnHeaderInBytes(dbfPath, allBytes);
        ArrayList descipList = convertDbf.ReturnDiscriptorsForEachHeader(headerBytes);

        //Json Output
        BuildJson buildJson = new BuildJson();
        string json = buildJson.ReturnJson(descipList, allBytes);
        Console.WriteLine(json);

        //Table Output
        BuildTable buildtable = new BuildTable();
        DataTable table = buildtable.ReturnTable(descipList, allBytes);
    }
}




