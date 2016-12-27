using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentControl
{

    class Program
    {
        static void Main(string[] args)
        {
            barcode dc_bc = new barcode();
            string dc_rework_file;

            string dc_partnumber_file;

            dc_bc.field2 = dc_bc.field2.Replace("/", string.Empty);

            if (dc_bc.field2.Length > 3) if (dc_bc.field2.Substring(dc_bc.field2.Length - 3, 3) == "_XX") dc_bc.field2 = dc_bc.field2.Substring(0, dc_bc.field2.Length - 3);

            dc_rework_file = dc_getfilename(@"C:\Profiles\Alan\Programming\C# 6.0 and the .NET 4.6 Framework, Seventh Edition\DocumentControl\DocCtlRewks",dc_bc.field1 + "-"+dc_bc.field2);

            if (dc_rework_file != null)
            {
                Console.WriteLine("Found file {0}", dc_rework_file);
                System.Diagnostics.Process.Start(dc_rework_file);
            }
            else 
            {

                dc_partnumber_file = dc_getfilename(@"C:\Profiles\Alan\Programming\C# 6.0 and the .NET 4.6 Framework, Seventh Edition\DocumentControl\DocCtlParts",dc_bc.field2);
                if (dc_partnumber_file != null)
                {
                    Console.WriteLine("Found file {0}", dc_partnumber_file);
                    System.Diagnostics.Process.Start(dc_partnumber_file);
                }
                    
                else
                {
                    Console.WriteLine("File not found");
                }
            }



            Console.ReadLine();
        }

        static string dc_getfilename(string dc_path, string dc_file)
        {
            DirectoryInfo diTop = new DirectoryInfo(@dc_path);
            string dc_fullfilename = null;

            try
            {
                foreach (var fi in diTop.EnumerateFiles())
                {
                    try
                    {
                        // Display each file;
                        Console.WriteLine("FullName {0}\t\t{1}", fi.FullName, fi.Length.ToString("N0"));
                        Console.WriteLine("Name {0}\t\t{1}", fi.Name, fi.Length.ToString("N0"));
                    }
                    catch (UnauthorizedAccessException UnAuthTop)
                    {
                        Console.WriteLine("{0}", UnAuthTop.Message);
                    }
                }

                foreach (var di in diTop.EnumerateDirectories("*"))
                {
                    try
                    {
                        foreach (var fi in di.EnumerateFiles("*", SearchOption.AllDirectories))
                        {
                            try
                            {
                                //// Display each file;
                                //Console.WriteLine("FullName {0}\t\t{1}", fi.FullName, fi.Length.ToString("N0"));
                                //Console.WriteLine("Name {0}\t\t{1}", fi.Name, fi.Length.ToString("N0"));
                                if (Path.GetFileNameWithoutExtension(fi.FullName) == dc_file)
                                {
                                    dc_fullfilename = fi.FullName;
                                }
                            }
                            catch (UnauthorizedAccessException UnAuthFile)
                            {
                                Console.WriteLine("UnAuthFile: {0}", UnAuthFile.Message);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException UnAuthSubDir)
                    {
                        Console.WriteLine("UnAuthSubDir: {0}", UnAuthSubDir.Message);
                    }
                }
            }
            catch (DirectoryNotFoundException DirNotFound)
            {
                Console.WriteLine("{0}", DirNotFound.Message);
            }
            catch (UnauthorizedAccessException UnAuthDir)
            {
                Console.WriteLine("UnAuthDir: {0}", UnAuthDir.Message);
            }
            catch (PathTooLongException LongPath)
            {
                Console.WriteLine("{0}", LongPath.Message);
            }
            return dc_fullfilename;
        }

        public class barcode
        {
            public string field1;
            public string field2;
            public string field3;
            public string field4;
            public string field5;
            public string field6;
            public string field7;
            public string field8;

            public barcode()
            {
                Console.Write("field1: ");
                field1 = Console.ReadLine();

                Console.Write("field2: ");
                field2 = Console.ReadLine();

                Console.Write("field3: ");
                field3 = Console.ReadLine();

                Console.Write("field4: ");
                field4 = Console.ReadLine();

                Console.Write("field5: ");
                field5 = Console.ReadLine();

                Console.Write("field6: ");
                field6 = Console.ReadLine();

                Console.Write("field7: ");
                field7 = Console.ReadLine();

                Console.Write("field8: ");
                field8 = Console.ReadLine();

            }

        }


    }
}
