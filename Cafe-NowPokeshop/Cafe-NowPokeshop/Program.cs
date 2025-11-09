//create a class for the menu, cart, etc.(?)
//obj within Menu class: items and prices
//obj within cart class: the cart items, the prices for each items, and the quantity of each item.
// Include a file in/out (OPTIPNAL: ask to save or reate option to save )
using System.Security.Cryptography.X509Certificates;

namespace MietheH_Cafe_C_
{
    internal class Cafe_project
    {
        static void Main()
        {
            //creating some things???? idk
            // myCart = new Cart();
            string Shop_Name = "PokeShop";
            double Tax_rate = 1.58;

            //banner for now
            Console.WriteLine("---------------------");
            Console.WriteLine(Shop_Name, Tax_rate);
            Console.WriteLine("---------------------");


            MainMenu();


        }
        public static void MainMenu()
        {
            //print the options
            Console.WriteLine("=====================================");
            Console.WriteLine("1. View Cart");
            Console.WriteLine("2. Add to Cart");
            Console.WriteLine("3. Remove from Cart");
            Console.WriteLine("4. Save/Load File");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("=====================================");

            Console.Write("Select what you'd like to do, by list number ");
            string MMInputStr = Console.ReadLine();
            if (!int.TryParse(MMInputStr, out int MMInput))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                //continue;
            }

            if (MMInput == 0)
            {
                Console.WriteLine("Exiting..."); //CODE AN EXIT COMMAND??
                //break;
            }

            if (MMInput < 0)
            {
                Console.WriteLine("Enter a positive number.");
                //continue;
            }

            //actual comands/requests
            if (MMInput == 1)
            {
                ViewCart();
                MainMenu();
            }

            if (MMInput == 2)
            {
                AddItem();
                MainMenu();
            }

            if (MMInput == 3)
            {
                RemoveItem();
                MainMenu();
            }

            if (MMInput == 4)
            {
                SaveLoadFile();
                MainMenu();

                //Save to a file
            }

            

            if (MMInput == 5)
            {
                //Checkout 
                Checkout();
            }
        }
        public static List<string> ShopItems = new List<string>()
        {
             "Potion",
            "Pokeball",
            "Ultraball",
            "Revive",
            "Rare Candy",
            "Elixr",
            "Full Heal",
            "Full Restore"
         };
        public static List<float> ShopPrices = new List<float>()
        {
            3.00f,
            2.50f,
            5.50f,
            5.00f,
            8.00f,
            4.00f,
            6.50f,
            6.50f
        };
        public static void Menu()
        {

            //print menu
            for (int i = 0; i < ShopItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ShopItems[i]} -- {ShopPrices[i]:0.00}");
            }
        }
        public static List<string> CartItems = new List<string>();
        public static List<float> CartPrices = new List<float>();
        public static List<int> CartQty = new List<int>();
        public static void Cart()
        {
            //create cart and save it into a text file
            //create cart file here, ADD THIS CODE ONCE YOU GET CART LISTS WORKING
            //        string path = "Cart.txt";

            //creating the lists for cart
            //    List<string> CartItems = new List<string>();
            //    List<float> CartPrices = new List<float>();
            //    List<int> CartQty = new List<int>();
            //
        }
        static void AddItem()
        {
            // show menu once up-front
            Menu();

            // validate Y/N answer
            while (true)
            {
                Console.Write("Would you like to order? (Y/N): ");
                string orderBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (orderBOOL == "Y")
                {
                    // print menu per loop
                    Menu();

                    // ask for item number w/ validation
                    while (true)
                    {
                        Console.Write("What would you like? (input item number, or 0 to cancel): ");
                        string itemInputStr = Console.ReadLine();
                        if (!int.TryParse(itemInputStr, out int itemInput))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        if (itemInput == 0)
                        {
                            Console.WriteLine("Order cancelled.");
                            break;
                        }

                        if (itemInput < 0)
                        {
                            Console.WriteLine("Enter a positive number.");
                            continue;
                        }

                        //gather the actual item from the number input
                        Console.WriteLine($"You selected item #{itemInput}. {ShopItems[itemInput - 1]}.");


                        //Qty and price 
                        Console.Write("How many?: ");
                        string qtyStr = Console.ReadLine();
                        int.TryParse(qtyStr, out int qty);

                        float QTYprice = ShopPrices[itemInput - 1] * qty;
                        float RoundQTYprice = (float)Math.Round(QTYprice);
                        //print current order
                        Console.WriteLine($"current order: {ShopItems[itemInput - 1]} for ${ShopPrices[itemInput - 1]:0.00} each x{qty} for a total of ${RoundQTYprice:0.00}");


                        //add it to cart
                        CartItems.Add(ShopItems[itemInput - 1]);
                        CartPrices.Add(ShopPrices[itemInput - 1]);
                        CartQty.Add(qty);

                        break;
                    }
                    //actually exit this time, pinhead
                    break;
                }
                else if (orderBOOL == "N")
                {
                    Console.WriteLine("No order placed.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' or 'N'.");
                }




            }
        }

        static void ViewCart()
        {
            for (int i = 0; i < CartItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CartItems[i]} -- {CartPrices[i]:0.00}  x{CartQty[i]}");

            }
            Console.WriteLine("    ");
        }

        static void RemoveItem()
        {
            // show cart first initially
            ViewCart();

            // validate Y/N answer 
            while (true)
            {
                Console.Write("Would you like to Remove an Item? (Y/N): ");
                string orderBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (orderBOOL == "Y")
                {
                    // print cart for each loop
                    ViewCart();

                    // ask item number w/ validation
                    while (true)
                    {
                        Console.Write("What would you like to remove?? (input item number, or 0 to cancel): ");
                        string rmvInputStr = Console.ReadLine();
                        if (!int.TryParse(rmvInputStr, out int rmvInput))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        if (rmvInput == 0)
                        {
                            Console.WriteLine("Removal cancelled.");
                            break;
                        }

                        if (rmvInput < 0)
                        {
                            Console.WriteLine("Enter a positive number.");
                            continue;
                        }

                        int index = rmvInput - 1; // now to 0-based
                        if (index < 0 || index >= CartItems.Count)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {CartItems.Count}.");
                            continue;
                        }

                        string name = CartItems[index];
                        float price = CartPrices[index];
                        int currentQty = CartQty[index];

                        Console.WriteLine($"Selected: {name} x{currentQty} @ {price:0.00} each.");
                        Console.Write("How many would you like to remove? (enter 0 to cancel): ");
                        if (!int.TryParse(Console.ReadLine(), out int rmvqty) || rmvqty < 0)
                        {
                            Console.WriteLine("Invalid quantity. Try again.");
                            continue;
                        }
                        if (rmvqty == 0)
                        {
                            Console.WriteLine("Removal cancelled.");
                            return;
                        }

                        if (rmvqty >= currentQty)
                        {
                            // remove whole line
                            CartItems.RemoveAt(index);
                            CartPrices.RemoveAt(index);
                            CartQty.RemoveAt(index);
                            Console.WriteLine($"Removed {name} x{currentQty} (All items removed).");
                        }
                        else
                        {
                            // partial removal: lower quantity
                            CartQty[index] = currentQty - rmvqty;
                            Console.WriteLine($"Removed {name} x{currentQty}. Remaining: {CartQty[index]}");
                        }

                        return;
                        //actually exit this time, pinhead

                    }
                }
                else if (orderBOOL == "N")
                {
                    Console.WriteLine("Nothing Removed..");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' or 'N'.");
                }


            }
        }

        static void SaveLoadFile()
        {
                string ItmFileType = "txt";
                string ItmFileName = "CartItems_File";
                string Itempath = $@"{ItmFileName}.{ItmFileType}";

                string PrcFileType = "txt";
                string PrcFileName = "CartPrices_File";
                string Pricepath = $@"{PrcFileName}.{PrcFileType}";

                string QtyFileType = "txt";
                string QtyFileName = "CartQty_File";
                string Qtypath = $@"{QtyFileName}.{QtyFileType}";

            Console.WriteLine("Save or Load file? (Type S or L)");
            string SaveORLoad = Console.ReadLine()?.Trim().ToUpperInvariant();

            if (SaveORLoad == "S")
            {
                Console.WriteLine("Would you like to save current cart to a file? (Y/N)");
                //saving items to file
                File.WriteAllLines(Itempath, CartItems);

                //saving prices to file
                // I have to turn it into a string ig?
                List<string> prcASstr = new List<string>();
                foreach (float f in CartPrices)
                {
                    prcASstr.Add(f.ToString("0.00"));
                }
                File.WriteAllLines(Pricepath, prcASstr);

                //saving qty to file
                List<string> qtyASstr = new List<string>();
                foreach (float f in CartQty)
                {
                    qtyASstr.Add(f.ToString());
                }
                File.WriteAllLines(Qtypath, qtyASstr);

                //check for file's existence
                if (File.Exists(Itempath))
                {
                    Console.WriteLine("Cart Items file created.");
                }
                else
                {
                    Console.WriteLine("Cart Items file NOT created.");
                }

                if (File.Exists(Pricepath))
                {
                    Console.WriteLine("Cart Prices file created.");
                }
                else
                {
                    Console.WriteLine("Cart Prices file NOT created.");
                }

                if (File.Exists(Qtypath))
                {
                    Console.WriteLine("Cart Qty file created.");
                }
                else
                {
                    Console.WriteLine("Cart Qty file NOT created.");
                }
            }
            else if (SaveORLoad == "L")
            {

            }
            else
            {
                Console.WriteLine("invalid input. Try again.");
            }



            //Load File

            if (!File.Exists(Itempath) || !File.Exists(Pricepath) || !File.Exists(Qtypath))
            {
                Console.WriteLine("One or more cart files are missing. Cannot load.");
                return;
            }

            // Read files once (not inside a loop)
            var FileItems = File.ReadAllLines(Itempath).ToList();
            var FilePrices = File.ReadAllLines(Pricepath);
            var FileQty = File.ReadAllLines(Qtypath);

            // Parse prices (try invariant then fallback)
            var loadedPrices = new List<float>();
            foreach (var line in FilePrices)
            {
                if (float.TryParse(line, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var p) ||
                    float.TryParse(line, out p))
                {
                    loadedPrices.Add(p);
                }
                else
                {
                    loadedPrices.Add(0f);
                }
            }

            // Parse variables
            var loadedQty = new List<int>();
            foreach (var line in FileQty)
            {
                if (int.TryParse(line, out var q))
                    loadedQty.Add(q);
                else
                    loadedQty.Add(0);
            }

            // Align lists: use shortest length to keep entries consistent
            int minCount = Math.Min(FileItems.Count, Math.Min(loadedPrices.Count, loadedQty.Count));

            CartItems.Clear();
            CartPrices.Clear();
            CartQty.Clear();

            for (int i = 0; i < minCount; i++)
            {
                CartItems.Add(FileItems[i]);
                CartPrices.Add(loadedPrices[i]);
                CartQty.Add(loadedQty[i]);
            }

            Console.WriteLine($"Loaded {minCount} items into the cart.");
            ViewCart();
            return;
        }

        static void Checkout()
        {
            //steps: add up all totals and qty, then discount, then Tax
            //float SubTotal = new float();
            double SubTotal = 0.00;
            List<float> priceWqtylist = new List<float>();
            double priceWqty = 0.00;

            int count = Math.Min(CartItems.Count, Math.Min(CartPrices.Count, CartQty.Count));
            for (int i = 0; i < count; i++)
            {
                float lineTotal = CartPrices[i] * CartQty[i];
                SubTotal += lineTotal;
                Console.WriteLine($"{i + 1}. {CartItems[i]} @ {CartPrices[i]:0.00} x{CartQty[i]} = ${lineTotal:0.00}");
            }

            //Discount
            Console.WriteLine("Enter Discount Code: TRAINER10");
            string DiscCode = Console.ReadLine();
            //float  Discount = new float();
            double Discount = 0.10;
            if ( DiscCode == "TRAINER10")
            {
                Console.WriteLine("Code applied");
                SubTotal -= SubTotal * Discount;
                Console.WriteLine($"Current Subtotal: {SubTotal:0.00}");
            }
            else
            {
                Console.WriteLine("Incorrect. Discount not applied.");               
            }

            //Taxes
            double Tax_rate = 1.58;
            double Total = 0.00;
            Total += SubTotal * Tax_rate;
            Console.WriteLine($"Total: {Total}"); 


            //Print Receipt
            Console.WriteLine("----------------RECEIPT----------------");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {CartItems[i]} @ {CartPrices[i]:0.00} x{CartQty[i]}");

            }
            Console.WriteLine($"DISCOUNT: TRAINER10 -- 10% OFF!!");
            Console.WriteLine($"SUBTOTAL: {SubTotal}");
            Console.WriteLine($"TAX RATE: {Tax_rate}");
            Console.WriteLine($"FINAL TOTAL: {Total}");
            Console.WriteLine("---------------------------------------");
        }
    }
}
