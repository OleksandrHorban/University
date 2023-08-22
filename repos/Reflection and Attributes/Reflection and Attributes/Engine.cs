using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;

public class Engine
{
    private Reader reader;
    private Writer writer;

    public Engine()
    {
        reader = new Reader();
        writer = new Writer();
    }

    public void Run()
    {
        Type classType = typeof(HarvestingFields);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        string command = reader.ReadLine();
        while (command != "HARVEST")
        {
            switch (command)
            {
                case "private":
                    PrintFields(fields.Where(f => f.IsPrivate));
                    break;
                case "protected":
                    PrintFields(fields.Where(f => f.IsFamily));
                    break;
                case "public":
                    PrintFields(fields.Where(f => f.IsPublic));
                    break;
                case "all":
                    PrintFields(fields);
                    break;
            }
            command = reader.ReadLine();
        }
    }

    private void PrintFields(IEnumerable<FieldInfo> fields)
    {
        StringBuilder sb = new StringBuilder();
        foreach (FieldInfo field in fields)
        {
            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
        }
        sb.Replace("family", "protected");
        writer.WriteLine(sb.ToString().Trim());
    }
}
