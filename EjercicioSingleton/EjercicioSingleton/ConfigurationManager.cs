using System;
using System.Collections.Generic;

namespace EjercicioSingleton;

public sealed class ConfigurationManager

{
    private static ConfigurationManager _instancia;

    private Dictionary<string, string> _configuraciones;

    private ConfigurationManager()
    {

        _configuraciones = new Dictionary<string, string>
        {
            ["ConnectionString"] = "Server=localhost; Database=Gimnasio;",
            ["AdminEmail"] = "admin@gimnasio.com",
            ["MaxIntentosLogin"] = "3",
            ["TimeoutSegundos"] = "30",
            ["Ambiente"] = "Desarrollo"
        };

    }

    public static ConfigurationManager Instancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = new ConfigurationManager();            
            }
            return _instancia;
        }
    }

    public bool Existe(string clave)
    {
        if (clave == null)
        {
            return false;
        }

        else
        {
            return _configuraciones.ContainsKey(clave);
        }
    }

    public string Get(string clave)
    {
        if (!Existe(clave))
        {
            return null;
        }

        else
        {
            return _configuraciones[clave];
        }
    }

    public void Set(string clave, string valor)
    {
        _configuraciones[clave] = valor;
    }
}
