using ConcurrentDictionary;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace TestConcurrentDictionary
{

    public class UnitTest1
    {

       
        [Theory]
        [InlineData(100,"nombre","apellido")]
        //[InlineData(1000, "nombre", "apellido")]
        //[InlineData(10000, "nombre", "apellido")]

        public void CrearDictionaryPersona(int cant,string nomb, string ape)
        {
            var listas = new ConcurrentDictionary<int, Persona>();
          
            int key = 1;
            Random rd = new Random();
           

            for (int i = 0; i < cant; i++)
            {
                var persona = new Persona();
               
                persona.Nombre = nomb;
                persona.Apellido = ape;
                persona.Edad = rd.Next(10, 60);

                listas.TryAdd(key, persona);
                key++;
            }

            Console.Write(listas.Count);
            Assert.True(!listas.IsEmpty);

        }



        [Theory]
        [InlineData(100, "nombre", "apellido")]
        public void BuscarEdadYActualizarDictionaryPersona(int cant, string nomb, string ape)
        {
            int edad = 15;

            var listas = new ConcurrentDictionary<int, Persona>();
            var persona = new Persona();
            int key = 1;
            Random rd = new Random();


            for (int i = 0; i < cant; i++)
            {
                persona = new Persona();

                persona.Nombre = nomb + key + 1;
                persona.Apellido = ape + key + 1;
                persona.Edad = rd.Next(10, 60);

                listas.TryAdd(key, persona);
                key++;
            }




            var c = listas.Where(x => x.Value.Edad < edad).ToList();

          
            Console.Write(listas.Count);
            Console.Write(c.Count);
           
            if (c.Count != 0)
            {
                foreach (var x in c)
                {
                    var p = x.Value;
                   
                    p.Edad = 30;
                    p.IsActivo = true;
                    if(listas.TryUpdate(x.Key, p, x.Value))
                    {
                        Console.WriteLine("Se ha podido actualizar");
                    }
                    else
                    {
                        Console.WriteLine("No se ha podido actualizar");
                    }
                }
            }
            Console.Write(listas.Count);
            Assert.True(!listas.IsEmpty);
        }






        [Theory]
        [InlineData(100, "nombre", "apellido")]
        public void BuscarEdadYEliminaDictionaryPersona(int cant, string nomb, string ape)
        {
            int edad = 20;

            var listas = new ConcurrentDictionary<int, Persona>();
            var persona = new Persona();
            int key = 1;
            Random rd = new Random();


            for (int i = 0; i < cant; i++)
            {
                persona = new Persona();

                persona.Nombre = nomb+ key+1;
                persona.Apellido = ape+key + 1;
                persona.Edad = rd.Next(10, 60);

                listas.TryAdd(key, persona);
                key++;
            }




            var c = listas.Where(x => x.Value.Edad < edad).ToList();
         

            Console.Write(listas.Count);
            Console.Write(c.Count);
          
            if (c.Count != 0)
            {
              foreach (var x in c)
                {

                   if(listas.TryRemove(x.Key,out var removedObject))
                    {
                        Console.WriteLine("Se ha podido eliminar");
                    }
                    else
                    {
                        Console.WriteLine("No se ha podido eliminar");
                    }
                }
            }
            Console.Write(listas.Count);
            Assert.True(!listas.IsEmpty);
        }


    }
}