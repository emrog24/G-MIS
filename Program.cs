using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hackathonfirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DfWbe9E4t0flZGNL
            //mongodb+srv://ottoacha28:DfWbe9E4t0flZGNL@hackcomp.g4h4sx9.mongodb.net/;
            //data base mongo db atlas
            //system auth0 next js

            Console.WriteLine("Ingrese que servicio desea usted con el numero ('1')\n" +
            "1- Mudanza\n" +
            "2- Cargo internacional\n" +
            "3- Cargo nacional\n" +
            "4- Carga Pesada");
            int op = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Formato de fecha Dia/Mes/año - xx/xx/xxxx");
            Console.WriteLine("Ingrese la fecha de salida esperada: ");
            string daysend = Console.ReadLine();
            Console.WriteLine("Formato de fecha Dia/Mes/año - xx/xx/xxxx");
            Console.WriteLine("Ingrese la fecha de entrega esperada: ");
            string dayarrive = Console.ReadLine();
            DateTime OutDate = Convert.ToDateTime(daysend);

            Console.WriteLine("Ingresa el total de toneladas que se transportaran: ");
            double tonel = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de kilometros que se viajaran: ");
            double distance = Convert.ToDouble(Console.ReadLine());



            DateTime ReceiveDate = Convert.ToDateTime(dayarrive);
            int numberOfDays = (ReceiveDate - OutDate).Days;

            // Console.WriteLine(numberOfDays);
            //Mini Data set


            int ton = 0;


            switch (op)
            {
                case 1:

                    //Moving
                    string CasP = "Castores";
                    double[] CasM = [1450, 256, 1200, 710, .82];

                    string MueP = "MyM";
                    double[] MueM = [1620, 235, 700, 1200, .77];

                    string TriP = "Two man and a Truck";
                    double[] TriM = [1750, 240, 500, 1250, .81];
                    int Mdate = 8; //base date difference 8 days
                    int Mdis = 90; //base distance 90km
                    ton = 12; // base ton 12t
                    double aproxday1 = numberOfDays * CasM[4];
                    double aprozday2 = numberOfDays * MueM[4];
                    double aproxday3 = numberOfDays * TriM[4];
                    DaysExtra(numberOfDays, Mdate, CasM, MueM, TriM, CasP, MueP, TriP);
                    Tonextra(tonel, ton, CasM, MueM, TriM, CasP, MueP, TriP);
                    Distanciaextra(distance, Mdis, CasM, MueM, TriM, CasP, MueP, TriP);
                    break;
                case 2:

                    //international shipping
                    string TruP = "Truck Fair";
                    double[] TruM = [2980, 521, 1000, 1000, .60];

                    string AirP = "Airway Transport";
                    double[] AirM = [3760, 100, 107, 1000, .95];

                    string FerP = "International Train Company";
                    double[] FerM = [2650, 450, 110, 1000, .72];

                    int Idate = 31; //base date difference 31 days
                    int Idis = 900; //base distance 900km
                    ton = 12; // base ton 12t
                    DaysExtra(numberOfDays, Idate, TruM, AirM, FerM, TruP, AirP, FerP);
                    Tonextra(tonel, ton, TruM, AirM, FerM, TruP, AirP, FerP);
                    Distanciaextra(distance, Idis, TruM, AirM, FerM, TruP, AirP, FerP);
                    break;

                case 3:

                    //Base price, date difference cost, Distance cost, extra per ton, Time est.
                    //Retail
                    string WalP = "Walmart Transport";
                    double[] WalM = [2000, 160, 300, 1120, .70];
                    //  +   +   +   +   -   -   -   +    +     /
                    string MexP = "Mexico Transporte";
                    double[] MexM = [1780, 200, 900, 800, .61];
                    //  +   +    +   +  -    -   -    +     +    /
                    string TraP = "Transporte Rojo";
                    double[] TraM = [1960, 189, 170, 920, .74];
                    //  +   +  +   +    -  -   -    +    +    /
                    int Rdate = 14; //base date difference 14 days
                    int Rdis = 230; //base distance 230km
                    ton = 12; // base ton 12t
                    DaysExtra(numberOfDays, Rdate, WalM, MexM, TraM, WalP, MexP, TraP);
                    Tonextra(tonel, ton, WalM, MexM, TraM, WalP, MexP, TraP);
                    Distanciaextra(distance, Rdis, WalM, MexM, TraM, WalP, MexP, TraP);
                    break;

                case 4:

                    //Heavy Work =
                    string HevP = "Heavy Trucks";
                    double[] HevM = [2340, 417, 100, 1000, .53];

                    string MetP = "Metal Transport co.";
                    double[] MetM = [2110, 352, 160, 1000, .69];

                    string WanP = "Wangley Air Transport";
                    double[] WanM = [1210, 190, 170, 1000, .20];

                    int Hdate = 18; //base date difference 18 days
                    int Hdis = 200;//base distance 200km
                    ton = 12; // base ton 12t
                    DaysExtra(numberOfDays, Hdate, HevM, MetM, WanM, HevP, MetP, WanP);
                    Tonextra(tonel, ton, HevM, MetM, WanM, HevP, MetP, WanP);
                    Distanciaextra(distance, Hdis, HevM, MetM, WanM, HevP, MetP, WanP);
                    break;
                default:
                    break;
            }
        }
        public static void DaysExtra(int numberOfDays, int Mdate, double[] CasM, double[] MueM, double[] TriM, string name1, string name2, string name3)
        {
            double x = 0;
            double totaldays = 0.0;
            double extraDays1 = 0.0;
            double extraDays2 = 0.0;
            double extraDays3 = 0.0;
            if (numberOfDays > Mdate)
            {
                totaldays = numberOfDays - Mdate;
                extraDays1 = CasM[1] * totaldays;
                extraDays2 = MueM[1] * totaldays;
                extraDays3 = TriM[1] * totaldays;

                Console.WriteLine($"La Empresa {name1} Te Cobraria un extra, ya que se pasaron los dias que ellos contemplan, saliendo en un total de {extraDays1} pesos");
                Console.WriteLine($"La Empresa {name2} Te Cobraria un extra, ya que se pasaron los dias que ellos contemplan, saliendo en un total de {extraDays2} pesos");
                Console.WriteLine($"La Empresa {name3} Te Cobraria un extra, ya que se pasaron los dias que ellos contemplan, saliendo en un total de {extraDays3} pesos");
                Console.WriteLine("**************************************************************************************************************************************************");
            }
            else
            {
                Console.WriteLine($"La Empresa {name1} Te Respetara el precio de {CasM[0]}");
                Console.WriteLine($"La Empresa {name2} Te Respetara el precio de {MueM[0]}");
                Console.WriteLine($"La Empresa {name3} Te Respetara el precio de {TriM[0]}");
                Console.WriteLine("**************************************************************************************************************************************************");
            }
        }
        public static void Tonextra(double tonel, int ton, double[] CasM, double[] MueM, double[] TriM, string name1, string name2, string name3)
        {
            double TotalTon = 0.0;
            double extraTon1 = 0.0;
            double extraTon2 = 0.0;
            double extraTon3 = 0.0;
            if (tonel > ton)
            {
                TotalTon = tonel - ton;
                extraTon1 = CasM[3] * TotalTon;
                extraTon1 = MueM[3] * TotalTon;
                extraTon1 = TriM[3] * TotalTon;
                Console.WriteLine($"La Empresa {name1} Te Cobraria un extra, ya que se pasaron las Toneladas que ellos contemplan, saliendo en un total de {extraTon1} pesos");
                Console.WriteLine($"La Empresa {name2} Te Cobraria un extra, ya que se pasaron las Toneladas que ellos contemplan, saliendo en un total de {extraTon2} pesos");
                Console.WriteLine($"La Empresa {name3} Te Cobraria un extra, ya que se pasaron las Toneladas que ellos contemplan, saliendo en un total de {extraTon3} pesos");
                Console.WriteLine("**************************************************************************************************************************************************");
            }
            else
            {
                Console.WriteLine($"La Empresa {name1} Te Respetara el precio de {CasM[0]}");
                Console.WriteLine($"La Empresa {name2} Te Respetara el precio de {MueM[0]}");
                Console.WriteLine($"La Empresa {name3} Te Respetara el precio de {TriM[0]}");
                Console.WriteLine("**************************************************************************************************************************************************");
            }

        }
        public static void Distanciaextra(double tonel, int ton, double[] CasM, double[] MueM, double[] TriM, string name1, string name2, string name3)
        {
            double TotalDistance = 0.0;
            double extradistance1 = 0.0;
            double extradistance2 = 0.0;
            double extradistance3 = 0.0;
            if (tonel > ton)
            {
                TotalDistance = tonel- ton;
                extradistance1 = CasM[3] * TotalDistance;
                extradistance2 = MueM[3] * TotalDistance;
                extradistance3 = TriM[3] * TotalDistance;
                Console.WriteLine($"La Empresa {name1} Te Cobraria un extra, ya que se paso la distancia maxima que ellos contemplan, saliendo en un total de {extradistance1} pesos");
                Console.WriteLine($"La Empresa {name2} Te Cobraria un extra, ya que se paso la distancia maxima que ellos contemplan, saliendo en un total de {extradistance2} pesos");
                Console.WriteLine($"La Empresa {name3} Te Cobraria un extra, ya que se paso la distancia maxima que ellos contemplan, saliendo en un total de {extradistance3} pesos");
                Console.WriteLine("**************************************************************************************************************************************************");
            }
            else
            {
                Console.WriteLine($"La Empresa {name1} Te Respetara el precio de {CasM[0]}");
                Console.WriteLine($"La Empresa {name2} Te Respetara el precio de {MueM[0]}");
                Console.WriteLine($"La Empresa {name3} Te Respetara el precio de {TriM[0]}");
                Console.WriteLine("**************************************************************************************************************************************************");
            }
        }

    }
    
}