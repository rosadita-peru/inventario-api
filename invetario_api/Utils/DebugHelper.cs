using System;
using System.Reflection;

namespace invetario_api.Utils;

public class DebugHelper
{
    public static void PrintNullProperties(object obj, string objectName = "Object")
    {
        if (obj == null)
        {
            Console.WriteLine($"[DEBUG] {objectName} es completamente NULL");
            return;
        }

        Console.WriteLine($"=== Verificando propiedades nulas de {objectName} ({obj.GetType().Name}) ===");

        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var hasNulls = false;

        foreach (var prop in properties)
        {
            try
            {
                var value = prop.GetValue(obj);

                if (value == null)
                {
                    Console.WriteLine($"  ❌ {prop.Name} ({prop.PropertyType.Name}) = NULL");
                    hasNulls = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  ⚠️  {prop.Name} - Error al leer: {ex.Message}");
            }
        }

        if (!hasNulls)
        {
            Console.WriteLine("  ✅ Todas las propiedades tienen valores");
        }

        Console.WriteLine("===============================================");
    }

    public static void PrintAllProperties(object obj, string objectName = "Object")
    {
        if (obj == null)
        {
            Console.WriteLine($"[DEBUG] {objectName} es completamente NULL");
            return;
        }

        Console.WriteLine($"=== Propiedades de {objectName} ({obj.GetType().Name}) ===");

        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties)
        {
            try
            {
                var value = prop.GetValue(obj);
                var displayValue = value == null ? "NULL" : value.ToString();

                Console.WriteLine($"  {prop.Name} ({prop.PropertyType.Name}) = {displayValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  {prop.Name} - Error: {ex.Message}");
            }
        }

        Console.WriteLine("===============================================");
    }
}
