using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UniBanca
{
    internal class Banca
    {
        public static List<ContoCorrente> Conti = new List<ContoCorrente>();
        public static List<Movimento> Movimenti = new List<Movimento>();
       
        public static void CreaConti()
        {
            ContoCorrente conto1 = new ContoCorrente("Giuseppe", "Cifarelli", new DateTime(2023,07,05) , 1, 10000);
            ContoCorrente conto2 = new ContoCorrente("Imad", "Mohamed", new DateTime(2023,02,04), 2, 5000);
            ContoCorrente conto3 = new ContoCorrente("Fabio", "Giannasi", new DateTime(2022,04,12), 3, 10000);
            ContoCorrente conto4 = new ContoCorrente("Federico", "Maso", new DateTime(2021,10,23), 4, 7500);
            ContoCorrente conto5 = new ContoCorrente("Francesco", "Lettieri", new DateTime(2022,03,17), 5, 15000);
            Conti.Add(conto1);
            Conti.Add(conto2);
            Conti.Add(conto3);
            Conti.Add(conto4);
            Conti.Add(conto5);
        }

        public static void Menu()
        {
            Console.WriteLine("===============MENU===============");
            Console.WriteLine("1. Crea nuovo conto");
            Console.WriteLine("2. Operazione sul conto");
            Console.WriteLine("3. Lista dei movimenti");
            Console.WriteLine("4. Saldo dei conti memorizzati");
            Console.WriteLine("5. ESCI");
            Console.WriteLine("===============MENU===============");

            try
            {
                int option = Convert.ToInt16(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        CreaConto();
                        Menu();
                        break;

                    case 2:
                        MenuMovimento();   
                        Menu();
                        break;

                    case 3:
                        MostraListaMovimenti();
                        Menu();
                        break;

                    case 4:
                        MostraSaldoConti();
                        Menu();
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opzione non valida");
                        Menu();
                        break;

                }
            }
            catch {
                Console.WriteLine("Dato inserito non valido");
                Menu();
            }
        }

        public static void CreaConto()
        {
            Console.WriteLine("Inserisci il nome del proprietario");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci il cognome del proprietario");
            string cognome = Console.ReadLine();
            ContoCorrente conto = new ContoCorrente(nome, cognome);
            conto.NrConto = Conti.Count + 1;
            Conti.Add(conto);
        }

        public static void MenuMovimento()
        {
            Console.WriteLine("Quale operazione vuoi effettuare?");
            Console.WriteLine("1. ACCREDITO");
            Console.WriteLine("2. ADDEBITO");
            int option = Convert.ToInt16(Console.ReadLine());
            switch(option)
            {
                case 1:
                    Accredito();
                    break;

                case 2:
                    Addebito();
                    break;

                default:
                    Console.WriteLine("L' operazione inserita non esiste!");                   
                    break;
            }
        }

        public static void Accredito()
        {
            Console.WriteLine($"Sono presenti {Conti.Count} conti memorizzati");
            Console.WriteLine("Su quale conto vuoi effettuare l' accredito?");
            int nrConto = Convert.ToInt16(Console.ReadLine());
            if (nrConto > Conti.Count)
            {
                Console.WriteLine("Il Numero di Conto inserito non esiste");
                Menu();
            }
            Console.WriteLine("Quanto vuoi versare sul conto?");
            double accredito = Convert.ToDouble(Console.ReadLine());
            foreach (ContoCorrente conto in Conti)
            {
                if (conto.NrConto == nrConto)
                {
                    conto.Saldo += accredito;
                    Movimento movimento = new Movimento(accredito);
                    movimento.Tipo = "Accredito";
                    movimento.NrConto = nrConto;
                    Movimenti.Add(movimento);
                    Console.WriteLine("Versamento riuscito!");
                }
            }
        }

        public static void Addebito()
        {
            Console.WriteLine($"Sono presenti {Conti.Count} conti memorizzati");
            Console.WriteLine("Su quale conto vuoi effettuare l' addebito?");
            int nrConto = Convert.ToInt16(Console.ReadLine());
            if (nrConto > Conti.Count)
            {
                Console.WriteLine("Il Numero di Conto inserito non esiste");
                Menu();
            }
            Console.WriteLine("Quanto vuoi addebitare sul conto?");
            double addebito = Convert.ToDouble(Console.ReadLine());
            foreach (ContoCorrente conto in Conti)
            {
                if (conto.NrConto == nrConto)
                {
                    if(addebito > conto.Saldo) {
                        Console.WriteLine("Il saldo disponibile è insufficiente");
                        Menu();
                    }
                    else { 
                        conto.Saldo -= addebito;
                        Movimento movimento = new Movimento(addebito);
                        movimento.Tipo = "Addebito";
                        movimento.NrConto = nrConto;
                        Movimenti.Add(movimento);
                        Console.WriteLine("Addebito riuscito!");
                    }
                }
            }

        }

        public static void MostraListaMovimenti()
        {
            Console.WriteLine($"Sono presenti {Conti.Count} conti memorizzati");
            Console.WriteLine("Qual è il numero di Conto che vuoi controllare?");
            int option = Convert.ToInt16(Console.ReadLine());
            if (option > Conti.Count)
            {
                Console.WriteLine("Il Numero di Conto inserito non esiste");
                Menu();
            }

            foreach (ContoCorrente conto in Conti)
            {
                if (conto.NrConto == option)
                {
                    Console.WriteLine($"Il conto di {conto.NomeCorrentista} {conto.CognomeCorrentista} aperto in data {conto.DataApertura} ha un saldo di ${conto.Saldo}");
                }
            }

            Console.WriteLine("=====APERTURA LISTA MOVIMENTI=====");
            foreach (Movimento mov in Movimenti)
            {
                if(mov.NrConto == option)
                {
                    Console.WriteLine($"E' stato effettuato un {mov.Tipo} di ${mov.Importo}");
                } 
            }
            Console.WriteLine("=====CHIUSURA LISTA MOVIMENTI=====");
        }

        public static void MostraSaldoConti()
        {
            foreach(ContoCorrente conto in Conti)
            {
                Console.WriteLine($"Il conto di {conto.NomeCorrentista} {conto.CognomeCorrentista} aperto in data {conto.DataApertura} ha un saldo di ${conto.Saldo}");
            }
        }
    }
}
