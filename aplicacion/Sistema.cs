using System.Collections.Generic;
class Sistema
{
    List<int> data = new();

    //Metodos de el lenguaje empresarial
    public int Metodo1(DataModel data)
    {
        if (data.a > 7)
            return 0;
        if (data.SonIguales())
            return 1;
        return -1;
    }

}