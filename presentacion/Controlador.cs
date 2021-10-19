using System;
using System.Collections.Generic;
using System.Linq;
class Controlador
{
    private Sistema _sistema;
    private Vista _vista;


    Dictionary<string, Action> _casosDeUso;

    public Controlador(Sistema sistema, Vista vista)
    {
        this._sistema = sistema;
        this._vista = vista;
        this._casosDeUso = new Dictionary<string, Action>(){
                // Action = Func sin valor de retorno
                { "Caso de Uso 1", CasoDeUso1 },
                { "Caso de Uso 2", CasoDeUso2 },
                {"Obtener entrada de tipo ", PruebasDeObtenerEntradaDeTipo},
                // Lambda
                { "Obtener la luna",() => vista.Display($"Caso de uso no implementado") },
            };
    }

    public void Run()
    {

        try
        {
            while (true)
            {
                var menu = new List<string> { "uno", "dos", "tres" };
                var key = _vista.TrySeleccionarOpcionDeListaEnumerada<string>(
                         "TITULO DE APLICACION",
                          _casosDeUso.Keys.ToList(),
                         "Selecciona un caso de uso");
                _vista.Display($"escogido{key}");

                   _casosDeUso[key].Invoke();

                switch (menu.FindIndex(e => e == key))
                {
                    case 1:
                        _vista.Display("Caso  de uso uno");
                        break;
                    case 2:
                        _vista.Display("Caso de uso uno");
                        break;
                    case 3:
                        _vista.Display("Caso de uso uno");
                        break;
                }
            }

        }
        catch (Exception e)
        {
            _vista.Display("Agur usuario!");

        }


    }
    void CasoDeUso1()
    {
        _vista.Display("CASO DE USO 1");
    }
    void CasoDeUso2()
    {

    }
    void PruebasDeObtenerEntradaDeTipo()
        {
            try
            {
                var s = _vista.TryObtenerEntradaDeTipo<string>("un string");
                Console.WriteLine($"Recibido: {s}");
                var d = _vista.TryObtenerEntradaDeTipo<decimal>("un decimal");
                Console.WriteLine($"Recibido: {d}");
                var f = _vista.TryObtenerEntradaDeTipo<float>("un float");
                Console.WriteLine($"Recibido: {f}");
                var i = _vista.TryObtenerEntradaDeTipo<int>("un int");
                var i2 =_vista.TryObtenerEntradaDeTipo<int>("un int");
                Console.WriteLine($"Recibido: {i}");
                var data = new DataModel{ 
                     a= i,
                     b =i2
                };
               
                var result = _sistema.Metodo1(data);
                _vista.Display($"El resultado es {result}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
}