using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMedlem.Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Member[] members = new Member[100];
            Boat[] boats = new Boat[100];

            boats = readBoats(boats);
            members = readMembers(members);
            int arrayPosition = members.Count(s => s != null);           // Räkna antal medlemmar
            int boatsPosition = boats.Count(z => z != null);
            int input = 10;

            do
            {
                
                ViewMenu();
                try
                {
                    input = int.Parse(Console.ReadLine());

                    if (input >= 0 && input <= 8)       // Rätt val i menyn
                    {
                    }

                    else
                    {
                        ViewMessage("FEL! Ange ett nummer mellan 0 och 8.", true);
                    }
                }

                catch
                {
                    ViewMessage("FEL! Ange ett nummer mellan 0 och 8.", true);
                }

                switch (input)
                {
                    case 0:
                        continue;

                    case 1:
                        // Skapa medlem 
                        members[arrayPosition] = AddMember();
                        arrayPosition++;
                        break;

                    case 2:
                        // Lista medlem
                        ViewMembers(members, arrayPosition, boats, boatsPosition);
                        break;

                    case 3:
                        //Info om medlem
                        if (arrayPosition == 0)
                        {
                            ViewMessage("Inga medlemmar finns ännu, försök igen senare.", true);        // Om inga medlemmar finns
                            break;
                        }

                        ViewMessage("Vilken medlem vill du ha information om?", false);
                        int whatMember = GetMemberNumber();     // Skaffar rätt position

                        if (whatMember < 0)
                        {
                        }

                        else if (whatMember > (arrayPosition - 1))                   // Kollar data, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                            break;
                        }

                        else if (whatMember <= arrayPosition)
                        {
                            GetMemberInfo(members, whatMember);         // Hittar och visar data
                        }
                        break;


                    case 4:

                        ViewMessage("Vilken medlem vill du redigera?", false);
                        int whichMember = GetMemberNumber();        // Hittar rätt nummer

                        if (whichMember < 0)
                        {
                        }

                        else if (whichMember > (arrayPosition - 1))      // Kollar numret, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        else if (whichMember <= arrayPosition)
                        {
                            EditMemberInfo(members, whichMember);       // Hittar och tillåter ändring av data
                        }
                        break;

                    case 5:
                        // Ta bort medlem
                        ViewMessage("Vilken medlem vill du radera?", false);
                        int whoMember = GetMemberNumber();        // Hittar rätt nummer

                        if (whoMember < 0)
                        {
                        }

                        else if (whoMember > (arrayPosition - 1))      // Kollar numret, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den medlemmen, försök igen.", true);
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        else if (whoMember <= arrayPosition)
                        {
                            members = DeleteMember(members, whoMember);       // Hittar och raderar
                            arrayPosition--;

                        }
                        break;

                    case 6:
                        // Lägg till båt
                        boats[boatsPosition] = AddBoat(members, arrayPosition);
                        boatsPosition++;
                        break;

                    case 7:
                        // Ta bort båt
                        ViewMessage("Vilken båt vill du radera?", false);
                        int whatBoat = GetBoatNumber(members, arrayPosition, boats, boatsPosition);        // Hittar rätt nummer

                        if (whatBoat < 0)
                        {
                        }

                        else if (whatBoat > (arrayPosition - 1))      // Kollar numret, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den båten, försök igen.", true);
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        else if (whatBoat <= arrayPosition)
                        {
                            boats = DeleteBoat(boats, whatBoat);
                            boatsPosition--;

                        }
                        break;

                    case 8:
                        ViewMessage("Vilken båt vill du redigera?", false);
                        int whichBoat = GetBoatNumber(members, arrayPosition, boats, boatsPosition);        // Hittar rätt nummer

                        if (whichBoat < 0)
                        {
                        }

                        else if (whichBoat > (arrayPosition - 1))      // Kollar numret, så den finns att hitta
                        {
                            ViewMessage("Kunde inte hitta den båten, försök igen.", true);
                            Console.WriteLine("Tryck på en tangent för att fortsätta...");
                            Console.ReadKey();
                        }

                        else if (whichBoat <= arrayPosition)
                        {
                            EditBoatInfo(boats, whichBoat);       // Hittar och tillåter ändring av data
                        }
                        break;
                }
            } while (input != 0);
        

        saveMembers(members, arrayPosition);
        saveBoats(boats, boatsPosition);
        }

        static void ViewMenu()      // Menyn
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("======================================");
            Console.WriteLine("=                                    =");
            Console.WriteLine("=         Medlemsregister            =");
            Console.WriteLine("=                                    =");
            Console.WriteLine("======================================\n");
            Console.ResetColor();

            Console.WriteLine("0. Avsluta.\n");
            Console.WriteLine("1. Registrera ny medlem \n");
            Console.WriteLine("2. Lista medlemmar \n");
            Console.WriteLine("3. Få ut information om medlem \n");
            Console.WriteLine("4. Redigera medlem \n");
            Console.WriteLine("5. Ta bort medlem \n");
            Console.WriteLine("6. Registrera båt \n");
            Console.WriteLine("7. Ta bort båt \n");
            Console.WriteLine("8. Redigera båt \n");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("\nAnge menyval [0-8]:");
        }

        static Member[] readMembers(Member[] members)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Markus\Documents\GitHub\DesignMedlem\Members.txt");
            int count = 1;
            int i = 0;

            foreach (string line in lines)
            {
                if (count == 1)
                {
                    members[i] = new Member();
                    members[i].FirstName = line;
                }

                if (count == 2)
                {
                    members[i].LastName = line;
                }

                if (count == 3)
                {
                    members[i].MemberNumber = Int32.Parse(line);
                }

                if (count == 4)
                {
                    count = 0;
                    members[i].SocialSecurityNumber = Int32.Parse(line);
                    i++;
                }
                count++;
            }

            

            return members;
        }   // Läs medlemmar från textfil

        static Boat[] readBoats(Boat[] boats)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Markus\Documents\GitHub\DesignMedlem\Boats.txt");
            int count = 1;
            int i = 0;

            foreach (string line in lines)
            {
                if (count == 1)
                {
                    boats[i] = new Boat();
                    boats[i].OwnedBy = Int32.Parse(line);
                }

                if (count == 2)
                {
                    boats[i].Length = Int32.Parse(line);
                }

                if (count == 3)
                {
                    count = 0;
                    boats[i].Type = Int32.Parse(line);
                    i++;
                }
                count++;
            }
            return boats;
        }       // Läs båtar från textfil

        static void saveMembers(Member[] members, int numberOfMembers)
        {
            int count = 1;
            int i = 0;
            int x = 0;
            string[] lines = new string[400];

            numberOfMembers = numberOfMembers * 4;              // Antal medlemmar gånger antal rader med information

            for(int y = 0; y < numberOfMembers; y++)
            {
                {
                    if (count == 1)
                    {
                        lines[x] = members[i].FirstName;
                    }

                    if (count == 2)
                    {
                        lines[x] = members[i].LastName;
                    }

                    if (count == 3)
                    {
                        lines[x] = members[i].MemberNumber.ToString();
                    }

                    if (count == 4)
                    {
                        count = 0;
                        lines[x] = members[i].SocialSecurityNumber.ToString();
                        i++;
                    }
                    count++;
                    x++;
                }
            }

            lines = lines.Where(h => !string.IsNullOrEmpty(h)).ToArray();

            System.IO.File.WriteAllLines(@"C:\Users\Markus\Documents\GitHub\DesignMedlem\Members.txt", lines);

        }       // Spara medlemmar till textfil

        static void saveBoats(Boat[] boats, int numberOfBoats)
        {
            int count = 1;
            int i = 0;
            int x = 0;
            string[] lines = new string[400];

            numberOfBoats = numberOfBoats * 3;              // Antal medlemmar gånger antal rader med information

            for (int y = 0; y < numberOfBoats; y++)
            {
                {
                    if (count == 1)
                    {
                        lines[x] = boats[i].OwnedBy.ToString();
                    }

                    if (count == 2)
                    {
                        lines[x] = boats[i].Length.ToString();
                    }

                    if (count == 3)
                    {
                        count = 0;
                        lines[x] = boats[i].Type.ToString();
                        i++;
                    }
                    count++;
                    x++;
                }
            }

            lines = lines.Where(h => !string.IsNullOrEmpty(h)).ToArray();

            System.IO.File.WriteAllLines(@"C:\Users\Markus\Documents\GitHub\DesignMedlem\Boats.txt", lines);

        }       // Spara båtar till textfil

        static Member AddMember()
        {
            string nameInput = "John";
            bool continueBool = false;
            Member myMember = new Member();

            do
            {
                Console.WriteLine("Vad är förnamnet?");         // Förnamn
                try
                {
                    nameInput = Console.ReadLine();
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }


                myMember.FirstName = nameInput;
                continueBool = true;

            } while (!continueBool);

            do
            {
                continueBool = false;

                Console.WriteLine("Vad är efternamnet?");           // Efternamn
                try
                {
                    nameInput = Console.ReadLine();
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }


                myMember.LastName = nameInput;
                continueBool = true;

            } while (!continueBool);

            do
            {
                continueBool = false;
                int numberInput = 0;

                Console.WriteLine("Vad är personnumret?");           // personnummer
                try
                {
                    numberInput = int.Parse(Console.ReadLine());
                    continueBool = true;
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }



                myMember.SocialSecurityNumber = numberInput;
                

            } while (!continueBool);

            myMember.CreateMemberNumber();

            return myMember;
        }                       // Lägg till medlem

        static void ViewMessage(string message, bool error)     // Meddelandefunktion
        {
            if (error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }

            Console.WriteLine(message);
            Console.ResetColor();
        }

        static Boat AddBoat(Member[] members, int arrayPos)
        {
            int numberInput = 0;
            int memberNumber = 0;
            bool continueBool = false;
            Boat myBoat = new Boat();

            do
            {
                Console.WriteLine("Vad är medlemsnumret på ägaren?");         // Medlemsnummer
                try
                {
                    numberInput = Int32.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }


                for (int i = 0; i < arrayPos; i++)
                {
                    memberNumber = members[i].MemberNumber;

                    if (memberNumber == numberInput)
                    {
                        myBoat.OwnedBy = numberInput;
                        continueBool = true;
                        break;
                    }
                }

                if (memberNumber != numberInput)
                {
                    ViewMessage("Kunde inte hitta medlem med det numret, försök igen.", true);
                }

            } while (!continueBool);

            do
            {
                continueBool = false;

                Console.WriteLine("Vad är längden?");           // Längd
                try
                {
                    numberInput = Int32.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }


                myBoat.Length = numberInput;
                continueBool = true;

            } while (!continueBool);

            do
            {
                continueBool = false;

                Console.WriteLine("Vad är det för typ?\n");           // Typ
                Console.WriteLine("1. Segelbåt\n");
                Console.WriteLine("2. Motorseglare\n");
                Console.WriteLine("3. Motorbåt\n");
                Console.WriteLine("4. Kajak/Kanot\n");
                Console.WriteLine("5. Övrigt\n");
                try
                {
                    numberInput = int.Parse(Console.ReadLine());

                    continueBool = true;
                }

                catch
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }

                if (numberInput >= 1 && numberInput <= 5)
                {
                }

                else
                {
                    ViewMessage("Fel format, försök igen.", true);
                    continueBool = false;
                }

                myBoat.Type = numberInput;


            } while (!continueBool);

            return myBoat;
        }   // Lägg till båt

        static void ViewMembers(Member[] array, int pos, Boat[] boatsArray, int boatsPos)        // Visar medlemmar
        {
            Console.Clear();
            string printString;
            bool continueBool = false;
            int input = 0;


            if (pos == 0)
            {
                ViewMessage("Inga medlemmar är inlagda ännu. Försök igen senare.", true);
            }


            else
            {

                do
                {
                    Console.WriteLine("Kompakt[1] eller fullständig[2] lista?");         // Förnamn
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                    }

                    catch
                    {
                        ViewMessage("Fel format, försök igen.", true);
                        continueBool = false;
                    }

                    if (input == 1)
                    {
                        int boatNumber = 0;
                        int memberNumber = 0;
                        int numberOfBoats = 0;
                       
                        for (int i = 0; i < pos; i++)
                        {
                            memberNumber = array[i].MemberNumber;

                            for (int y = 0; y < boatsPos; y++)
                            {
                                boatNumber = boatsArray[y].OwnedBy;

                                if (memberNumber == boatNumber)
                                {
                                    numberOfBoats++;
                                }
                            }

                            array[i].NumberOfBoats = numberOfBoats;
                            printString = array[i].PrintCompact();
                            Console.WriteLine(printString);
                            numberOfBoats = 0;
                        }

                        continueBool = true;

                        Console.WriteLine("Tryck på en tangent för att fortsätta...");
                        Console.ReadKey();
                    }

                    if (input == 2)
                    {
                        int boatNumber = 0;
                        int memberNumber = 0;
                        int numberOfBoats = 0;
                        string boatInfo = "";

                        for (int i = 0; i < pos; i++)
                        {
                            memberNumber = array[i].MemberNumber;

                            for (int y = 0; y < boatsPos; y++)
                            {
                                boatNumber = boatsArray[y].OwnedBy;

                                if (memberNumber == boatNumber)
                                {
                                    boatInfo += boatsArray[y].BoatToString();

                                    numberOfBoats++;
                                }
                            }

                            array[i].NumberOfBoats = numberOfBoats;
                            printString = array[i].PrintCompact();
                            Console.WriteLine(printString);
                            Console.WriteLine(boatInfo);
                            numberOfBoats = 0;
                            boatInfo = "";
                        }

                        continueBool = true;

                        Console.WriteLine("Tryck på en tangent för att fortsätta...");
                        Console.ReadKey();
                    }

                } while (!continueBool);

               
            }
        }

        static int GetMemberNumber()
        {
            int numberInput = 0;



            Console.WriteLine("Obs! Anges i den ordning som medlemmar visas i medlemslistan!");
            Console.WriteLine("(0 för att avbryta)\n");

            do
            {
                try
                {
                    numberInput = int.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Hittade inte medlem, försök igen.", true);
                }

                if (numberInput == 0)
                {
                    break;
                }

                else if (numberInput > 0 && numberInput <= 100)
                {
                    numberInput = numberInput - 1;
                    return numberInput;
                }

                else
                {
                    ViewMessage("Hittade inte medlem, försök igen.", true);
                }
            } while (numberInput != 0);

            return -1;
        }               // Få numret

        static int GetBoatNumber(Member[] array, int pos, Boat[] boatArray, int boatPos)
        {
            int numberInput = 0;



            Console.WriteLine("Sök båt via medlemsnummer.\n");
            Console.WriteLine("(0 för att avbryta)\n");

            do
            {
                try
                {
                    numberInput = int.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Hittade inte båten, försök igen.", true);
                }

                if (numberInput == 0)
                {
                    break;
                }

                else if (numberInput > 0 && numberInput <= 999999999)
                {
                    int memberNumber = 0;
                    int matches = 0;
                    int[] positions = new int[50];
                    int x = 0;

                    for (int i = 0; i < boatPos; i++)
                    {
                        memberNumber = boatArray[i].OwnedBy;

                        if (numberInput == memberNumber)
                        {
                            matches++;
                            positions[x] = i;
                            x++;
                        }
                    }

                    if (matches == 0)
                    {
                        ViewMessage("Hittade inte båt, försök igen.", true);
                        Console.WriteLine("Tryck på en tangent för att fortsätta...");
                        Console.ReadKey();
                        return -1;
                    }

                    else if(matches == 1)
                    {
                        numberInput = positions[0]; // eller?
                    }

                    else if(matches > 1)
                    {
                        int positionOfBoat = 0;
                        int boatType = 0;
                        int boatLength = 0;
                        string type = "";

                        Console.WriteLine("Vilken båt letar du efter? \n");
                        for(int i = 0; i < matches; i++)
                        {
                            positionOfBoat = positions[i];
                            boatType = boatArray[positionOfBoat].Type;
                            boatLength = boatArray[positionOfBoat].Length;

                            if(boatType == 1)
                            {
                                type = "Segelbåt";
                            }

                            if(boatType == 2)
                            {
                                type = "Motorseglare";
                            }

                            if(boatType == 3)
                            {
                                type = "Motorbåt";
                            }

                            if(boatType == 4)
                            {
                                type = "Kajak/Kanot";
                            }

                            if(boatType == 5)
                            {
                                type = "Övrigt";
                            }

                            Console.WriteLine("Båt nummer {0}", i+1);
                            Console.WriteLine("Båttyp:\t{0}", type);
                            Console.WriteLine("Båtlängd:\t{0}\n", boatLength);
                        }

                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                        }

                        catch
                        {
                            ViewMessage("Hittade inte båten, försök igen.", true);
                        }

                        if(numberInput < 0 || numberInput > matches)
                        {
                            ViewMessage("Fel båt, försök igen.", true);
                            return -1;
                        }

                        else
                        {
                            numberInput = numberInput - 1;
                            return numberInput;
                        }
                    }


                    
                    return numberInput;
                }

                else
                {
                    ViewMessage("Hittade inte båt, försök igen.", true);
                }
            } while (numberInput != 0);

            return -1;
        }               // Få numret

        static void GetMemberInfo(Member[] array, int pos)
        {
            string printString;

            printString = array[pos].PrintFull();

            Console.WriteLine(printString);

            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();

        }       // Få info

        static void EditMemberInfo(Member[] array, int pos)
        {
            int input = 10;
            int number;
            string nameInput;
            string name;

            do
            {
                string printIt = array[pos].PrintFull();
                Console.Clear();
                Console.WriteLine(printIt, "\n");

                Console.WriteLine("Vilken egenskap vill du ändra? \n");
                Console.WriteLine("0. Avsluta\n1. Förnamn\n2. Efternamn\n3. Personnummer\n4. Medlemsnummer");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Inte ett tal mellan 0-4, försök igen.", true);
                }

                if (input < 0 && input > 4)
                {
                    ViewMessage("Inte ett tal mellan 0-4, försök igen.", true);
                }

                else if (input == 1)
                {
                    name = array[pos].FirstName;

                    Console.WriteLine("Vad vill du byta {0} till?", name);

                    nameInput = Console.ReadLine();

                    array[pos].FirstName = nameInput;
                }

                else if (input == 2)
                {
                    name = array[pos].LastName;

                    Console.WriteLine("Vad vill du byta {0} till?", name);

                    nameInput = Console.ReadLine();

                    array[pos].LastName = nameInput;
                }

                else if (input == 3)
                {
                    bool continueBool = false;
                    number = array[pos].SocialSecurityNumber;

                    do
                    {
                        continueBool = false;
                        int numberInput = 0;

                        Console.WriteLine("Vad vill du byta {0} till?", number);           // Personnummer

                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                            continueBool = true;
                        }

                        catch
                        {
                            ViewMessage("Fel format, försök igen.", true);
                            continueBool = false;
                        }

                        if (numberInput < 0)
                        {
                            ViewMessage("Måste vara större än 0, försök igen.", true);
                            continueBool = false;
                        }



                        array[pos].SocialSecurityNumber = numberInput;


                    } while (!continueBool);
                }

                else if (input == 4)
                {
                    bool continueBool = false;
                    number = array[pos].MemberNumber;

                    do
                    {
                        continueBool = false;
                        int numberInput = 0;

                        Console.WriteLine("Vad vill du byta {0} till?", number);           // Medlemsnummer

                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                            continueBool = true;
                        }

                        catch
                        {
                            ViewMessage("Fel format, försök igen.", true);
                            continueBool = false;
                        }

                        if (numberInput < 0)
                        {
                            ViewMessage("Måste vara större än 0, försök igen.", true);
                            continueBool = false;
                        }

                        array[pos].MemberNumber = numberInput;


                    } while (!continueBool);
                }

            } while (input != 0);
        }       // Ändra medlem

        static void EditBoatInfo(Boat[] array, int pos)
        {
            int input = 10;
            int length = 0;
            int type = 0;
            int owner = 0;

            do
            {
                string printIt = array[pos].BoatToStringFull();
                Console.Clear();
                Console.WriteLine(printIt, "\n");

                Console.WriteLine("Vilken egenskap vill du ändra? \n");
                Console.WriteLine("0. Avsluta\n1. Båttyp\n2. Längd\n3. Ägare\n");

                try
                {
                    input = int.Parse(Console.ReadLine());
                }

                catch
                {
                    ViewMessage("Inte ett tal mellan 0-3, försök igen.", true);
                }

                if (input < 0 && input > 3)
                {
                    ViewMessage("Inte ett tal mellan 0-3, försök igen.", true);
                }

                else if (input == 1)
                {
                    type = array[pos].Type;

                    Console.WriteLine("1. Segelbåt\n");
                    Console.WriteLine("2. Motorseglare\n");
                    Console.WriteLine("3. Motorbåt\n");
                    Console.WriteLine("4. Kajak/Kanot\n");
                    Console.WriteLine("5. Övrigt\n");

                    Console.WriteLine("Vad vill du byta {0} till?", type);

                    try
                    {
                        input = int.Parse(Console.ReadLine());
                    }

                    catch
                    {
                        ViewMessage("Inte ett tal mellan 1-5, försök igen.", true);
                    }

                    if (input < 1 && input > 5)
                    {
                        ViewMessage("Inte ett tal mellan 1-5, försök igen.", true);
                    }

                    else if(input >= 1 && input <= 5)
                    {
                        array[pos].Type = input;
                    }
                }

                else if (input == 2)
                {
                    length = array[pos].Length;
                    bool continueBool = false;

                    do
                    {
                        continueBool = false;
                        int numberInput = 0;

                        Console.WriteLine("Vad vill du byta {0} till?", length);      
                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                            continueBool = true;
                        }

                        catch
                        {
                            ViewMessage("Fel format, försök igen.", true);
                            continueBool = false;
                        }



                        array[pos].Length = numberInput;


                    } while (!continueBool);
                }

                else if (input == 3)
                {
                    owner = array[pos].OwnedBy;
                    bool continueBool2 = false;

                    do
                    {
                        continueBool2 = false;
                        int numberInput = 0;

                        Console.WriteLine("Vad vill du byta {0} till?", owner);
                        try
                        {
                            numberInput = int.Parse(Console.ReadLine());
                            continueBool2 = true;
                        }

                        catch
                        {
                            ViewMessage("Fel format, försök igen.", true);
                            continueBool2 = false;
                        }



                        array[pos].OwnedBy = numberInput;


                    } while (!continueBool2);
                }
            } while (input != 0);
        }       // Ändra båt

        static Member[] DeleteMember(Member[] array, int pos)       // Ta bort medlem
        {

            var newList = array.ToList();
            newList.RemoveAt(pos);
            Member[] newArray = new Member[100];
            newArray = newList.ToArray();

            return newArray;
        }

        static Boat[] DeleteBoat(Boat[] boats, int pos)
        {
            var newList = boats.ToList();
            newList.RemoveAt(pos);
            Boat[] newArray = new Boat[100];
            newArray = newList.ToArray();

            return newArray;
        }           // Ta bort båt
    }
}
