using System;



   
        
 var sistema = new Sistema();
 var vista = new Vista();
 var controlador = new Controlador(sistema, vista);
      
controlador.Run();