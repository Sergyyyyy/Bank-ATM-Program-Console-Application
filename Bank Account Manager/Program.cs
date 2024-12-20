namespace Bank_Account_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool running = true;
            string[] IDS = {"1", "12413969" };
            string[] PWS = {"1", "12Dec2005/" };
            int currentmoney = 1000;
            

            Console.WriteLine("-------------------BANK-PROGRAM-------------------");

            Console.WriteLine("\n\n\nWHAT WOULD YOU LIKE TO DO TODAY...........");
            

            while (running)
            {
                Console.WriteLine("1. SIGN UP");
                Console.WriteLine("2. LOG IN");
                Console.WriteLine("3. EXIT\n");

                int input;

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("\nENTER A VALID OPTION..........\n");
                    continue;
                }
                else if (input > 3)
                {
                    Console.WriteLine("\nENTER A VALID OPTION..........\n");
                }
                else
                {
                    switch (input)
                    {
                        case 1:
                            List<string> newuser = new List<string>(IDS);
                            List<string> newpw = new List<string>(PWS);

                            Console.Write("\nENTER A USER: ");
                            string newuserid = Console.ReadLine();

                            Console.Write("ENTER A PASSWORD: ");
                            string newpws = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(newuserid) || !newuserid.All(char.IsLetterOrDigit))
                            {
                                Console.WriteLine("\nUSER MUST NOT BE EMPTY AND MUST ONLY CONTAIN LETTERS OR NUMBERS.\n");
                            }
                            else if (newuser.Contains(newuserid))
                            {
                                Console.WriteLine("\nTHIS USER IS ALREADY TAKEN..........\n");
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(newpws))
                                {
                                    Console.WriteLine("\nPASSWORD CANNOT BE EMPTY.\n");
                                }
                                else
                                {
                                    newuser.Add(newuserid);
                                    newpw.Add(newpws);

                                    IDS = newuser.ToArray();
                                    PWS = newpw.ToArray();

                                    Console.WriteLine("\nUSER HAS BEEN REGISTERED..........\n");
                                }
                            }
                            break;
                        case 2:
                            bool login = true;


                            while (login)
                            {
                                bool isauthenticated = false;

                                Console.WriteLine("\nENTER YOUR USER..........");
                                string id = Console.ReadLine();

                                Console.WriteLine("\nENTER YOUR PASSWORD..........");
                                string pw = Console.ReadLine();

                                for (int i = 0; i < IDS.Length; i++)
                                {
                                    if (id == IDS[i] && pw == PWS[i])
                                    {
                                        Console.WriteLine("\nYOU ARE NOW LOGGED IN AS USER " + IDS[i]);
                                        login = false;
                                        isauthenticated = true;
                                        break;

                                    }

                                }

                                if (!isauthenticated)
                                {
                                    Console.WriteLine("\nERROR! INCORRECT USERID OR PASSWORD..........");
                                }
                                else
                                {
                                    bool login2 = true;

                                    while (login2)
                                    {
                                        Console.WriteLine("\nCHOOSE AN OPTION..........");
                                        Console.WriteLine("1. DEPOSIT");
                                        Console.WriteLine("2. CHECK BALANCE");
                                        Console.WriteLine("3. TRANSFER");
                                        Console.WriteLine("4. BACK\n");

                                        int input2 = Convert.ToInt32(Console.ReadLine());

                                        switch (input2)
                                        {
                                            case 1:
                                                Console.WriteLine("\nENTER AMOUNT TO BE DEPOSIT: \n");
                                                int amount = Convert.ToInt32(Console.ReadLine());

                                                int newmoney = amount + currentmoney;
                                                currentmoney = newmoney;

                                                Console.WriteLine("\n" + amount + " HAS BEEN ADDED TO YOUR BALANCE");
                                                break;
                                            case 2:
                                                Console.WriteLine("\nBALANCE: " + currentmoney + "\n");
                                                break;
                                            case 3:
                                                bool transferring = true;

                                                Console.Write("\nENTER USERID TRANSFEREE: ");
                                                int transferid = Convert.ToInt32(Console.ReadLine());

                                                while (transferring)
                                                {
                                                    Console.Write("\nENTER AMOUNT TO BE TRANSFERRED: ");
                                                    int transfer = Convert.ToInt32(Console.ReadLine());

                                                    if (transfer <= 0)
                                                    {
                                                        Console.WriteLine("\nERROR! INVALID AMOUNT..........\n");
                                                    }
                                                    else if (transfer > currentmoney)
                                                    {
                                                        Console.WriteLine("\nERROR! VALUE EXCEEDS THE BALANCE..........\n");
                                                    }
                                                    else
                                                    {
                                                        currentmoney = currentmoney - transfer;

                                                        Console.WriteLine(transfer + " HAS BEEN TRANSFERRED TO " + transferid + " FROM YOUR ACCOUNT..........");
                                                        transferring = false;
                                                    }
                                                }
                                                break;
                                            case 4:
                                                login2 = false;
                                                break;
                                        }
                                    }
                                }
                            }


                            break;
                        case 3:
                            Console.WriteLine("THANK YOU FOR USING THIS PROGRAM..........");
                            running = false;
                            break;
                        default:
                            break;
                    }
                }

                

                    
            }
            

            Console.ReadKey();
        }
    }
}
