using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;

namespace nouveautés_cs9
{

    struct PersonneStruct
    {
        public string nom { get; set; }
        public int age { get; set; }

        public PersonneStruct()
        {
            this.nom = "Inconnu";
            this.age = -1;
        }
    }

    //record class PersonneRecord //  record struct PersonneRecord --> par valeur  ,  record  PersonneRecord --> par référence
    //{
    //    public string? nom { get; set; }
    //    public int age { get; set; }

    //}
   readonly record struct PersonneRecord ( string nom, int age ); // le record struct n'est pas immutable, ajouter readonly pour le rendre immutable

    class Program
    {
        static void Main(string[] args)
        {
            var ps1 = new PersonneStruct();
            var ps2= new PersonneStruct();

            var pr1 = new PersonneRecord("Toto", 20);  ///{ nom = "Paul", age = 20 };
           // var pr2 = new PersonneRecord("Toto", 20); // { nom = "Paul", age = 20 };
            var pr2 = pr1 with { nom = "tata" };  // Je copie p1 mais avec un autre nom à mon goût
                                                  // Avec les record on poite par référence et memoire
                                                  //var pr2 = pr1;
                                                  //pr1.nom = "Toto";
                                                  //  pr1.nom = "tata";

            Console.WriteLine(ps1.Equals(ps2)) ;
            Console.WriteLine(pr1); 
            Console.WriteLine(pr2);  // les record peuvent pointer vers l'objet string,
            Console.WriteLine(pr1 == pr2);

            //string nom = " ";
            //int age = 0;

            (var nom1, var age1) = pr1;
            Console.WriteLine(nom1);
            Console.WriteLine(age1);

        }
    }

}