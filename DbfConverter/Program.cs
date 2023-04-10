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
        string dbfPath = args[2];

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

        //using (StreamWriter file = new StreamWriter(@"C:\Users\p.gayevsky\Documents\SomeProjects\DbfConverter\DbfConverter\testTable.txt"))
        //{
        //    // Write the header row
        //    for (int i = 0; i < table.Columns.Count; i++)
        //    {
        //        file.Write(table.Columns[i].ColumnName);
        //        if (i < table.Columns.Count - 1)
        //        {
        //            file.Write(",");
        //        }
        //    }
        //    file.WriteLine();

        //    // Write the data rows
        //    foreach (DataRow row in table.Rows)
        //    {
        //        for (int i = 0; i < table.Columns.Count; i++)
        //        {
        //            file.Write(row[i].ToString());
        //            if (i < table.Columns.Count - 1)
        //            {
        //                file.Write(",");
        //            }
        //        }
        //        file.WriteLine();
        //    }
        //}

    }
}




