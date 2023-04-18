using SqlBasics.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SqlBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            using ( var db = new SqlBasicsDB())
            {
                Console.WriteLine($"Specializarile din baza de date sunt: ");
                db.Specializare.Select(x => x.profileName).ToList().ForEach(x => { Console.WriteLine(x); } );

                Console.WriteLine($"Studenti din baza de date sunt: ");
                db.Students.ToList().ForEach(x => { Console.WriteLine($"{x.id} - {x.nume} {x.prenume} {x.varsta} "); });

                var IdSpecializari = db.Specializare.ToList();

                // Add Students
                //var students = new[] 
                //{
                //    new Students { nume = "Popescu", prenume = "Catalin", varsta = 40, specializare = IdSpecializari[0] },
                //    new Students { nume = "Ionescu", prenume = "Razvan", varsta = 20, specializare = IdSpecializari[1] },
                //    new Students { nume = "Basescu", prenume = "Catalin", varsta = 23, specializare = IdSpecializari[2] },
                //    new Students { nume = "Antonescu", prenume = "Irinel", varsta = 70, specializare = IdSpecializari[1] },
                //    new Students { nume = "Vadim", prenume = "Tudor", varsta = 30, specializare = IdSpecializari[2] },
                //    new Students { nume = "Borsescu", prenume = "Madalin", varsta = 13, specializare = IdSpecializari[3] },
                //    new Students { nume = "Lucaciu", prenume = "Laviniu", varsta = 22, specializare = IdSpecializari[3] },

                //};

                //db.Students.AddRange(students);
                //db.SaveChanges();


                // Studenti in ordine alfabetica
                Console.WriteLine($"Afisare studenti in ordine alfabetica: ");
                db.Students.OrderBy(x => x.nume).ToList().ForEach(x => { Console.WriteLine($"{x.id} - {x.nume} {x.prenume} {x.varsta} "); });

                // Afisare celui mai tanar student de la constructii
                Console.WriteLine($"Afisare celui mai tanar student de la constructii cu varsta de peste 20 de ani: ");
                var youngestStudent = db.Students.Include(x => x.specializare).Where(x => x.specializare.profileName == "Constructii" && x.varsta > 20).OrderBy(x => x.varsta).FirstOrDefault();
               
                if (youngestStudent != null)
                {
                    Console.WriteLine($"Cel mai tânăr student din specializarea Constructii care are peste 20 de ani este {youngestStudent.nume} {youngestStudent.prenume}, care are {youngestStudent.varsta} ani.");
                }
                else
                {
                    Console.WriteLine("Nu a fost găsit niciun student care să îndeplinească criteriile.");
                }

                // Afisare studentilor cu specializarile lor
                db.Students.Include(x =>x.specializare).OrderBy(x => x.prenume).ToList().ForEach(x => { Console.WriteLine($"{x.id} - {x.nume} {x.prenume} {x.varsta} - {x.specializare.profileName}"); });

                Console.ReadLine();
            }
        }
    }
}