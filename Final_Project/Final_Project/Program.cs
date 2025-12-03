using System;
using System.Data.Common;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Final_Project
{

            

    //manipulate all lists (adding/removing books from gathered like the cart from the cafe) via THE !!ID NUMBER!!
    internal class Program
    {
        //define your global variables here
        public DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
        public static List<int> Gathered = new List<int>();

        static void Main(string[] args)
        {
            createCatalog();
            MainMenu();
        }

        static void createCatalog()
        {
            LibraryItems.catalog = new List<LibraryItems>();

            LibraryItems.catalog.AddRange(new[]
            {
                new LibraryItems(101, "Basics of Reading", "Book", 0.25, true),
                new LibraryItems(102, "Advanced Reading", "Book", 0.50, true),
                new LibraryItems(103, "The Giving Tree", "Book", 0.25, true),
                new LibraryItems(104, "Where the Sidewalk Ends", "Book", 0.25, true),
                new LibraryItems(105, "Ghostbusters", "DVD", 0.75, true),
                new LibraryItems(106, "Jaws", "DVD", 0.75, true)
            }
            );
        }



        static void MainMenu()
        {
            //print main menu
            Console.WriteLine("=====================================");
            Console.WriteLine("1. View Library Catalog");  //specify available vs not via BOOL
            Console.WriteLine("2. Add to Library Catalog");  //ensure all details are added
            Console.WriteLine("3. Gather Books to Check Out");
            Console.WriteLine("4. View Gathered Books");
            Console.WriteLine("5. Return from Gathered Books");
            Console.WriteLine("6. Return a Checked Out Book");
            Console.WriteLine("7. View Checked Out Books Receipt"); 
            Console.WriteLine("8. Save/Load Checked Out Books to File");
            Console.WriteLine("9. Check Out");
            Console.WriteLine("=====================================");

            //USER INPUT
            Console.Write("Select what you'd like to do, by list number. press '0' to exit ");
            string MMInputStr = Console.ReadLine();
            if (!int.TryParse(MMInputStr, out int MMInput))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                MainMenu();

            }

            if (MMInput == 0)
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(0); //Exit with success code

            }

            if (MMInput < 0)
            {
                Console.WriteLine("Enter a positive number.");
                MainMenu();
            }

            //actual commands/requests
            if (MMInput == 1) //View Library Catalogue
            {
                LibraryItems.ViewCatalog();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 2) //add to library catalogue
            {
                AddLibrary();
                LibraryItems.ViewCatalog();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 3) //Gather books -- pre-checkout
            {
                GatherItems();
                Console.WriteLine("   ");
                MainMenu();
            }


            if (MMInput == 4) //view gathered books
            {
                ViewGathered();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 5) //return from Gathered
            {                
                ReturnGathered();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 6) //return from Checked out items
            {
                ReturnCheckedOut();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 7) //view checked out books receipt
            {
                CheckoutItems.ViewCheckout();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 8) // save/load checked out books to file
            {
                SaveLoadFile();
                Console.WriteLine("   ");
                MainMenu();
            }

            if (MMInput == 9) //check out
            {
                Checkout();
                Console.WriteLine("   ");
                MainMenu();
            }

            else
            {
                Console.WriteLine("invalid input, please select an option within range");
                MainMenu();
            }
        }

        public static void AddLibrary()
        {
            //to do ID: just increment, in order
            
            Console.WriteLine("What is the name of the item?");
            string v2 = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(v2))
            {
                Console.Write("Name cannot be empty. Enter name: ");
                v2 = Console.ReadLine()?.Trim();
                
            }
            Console.WriteLine($"{v2}");

            Console.WriteLine("What is the type of media?");
            string v3 = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(v3))
            {
                Console.Write("Media type cannot be empty. Enter media type: ");
                v3 = Console.ReadLine()?.Trim();

            }
            Console.WriteLine($"{v3}");

            Console.WriteLine("What is the Late fee? (formatted 0.xx)");
            double v4 = 0.00;
            double lateFee;
            string feeInput = Console.ReadLine()?.Trim();
            while (!double.TryParse(feeInput, out lateFee) || lateFee < 0)
            {
                Console.Write("Invalid fee. Enter a numeric late fee (e.g. 0.25): ");
                feeInput = Console.ReadLine()?.Trim();
            }
            v4 = lateFee; //assert it as the correct variable
            Console.WriteLine($"{v4:C}"); //:C means currency

            //this increments the new item id by +1 and saves the value
            int v1 = LibraryItems.catalog.Any() ? LibraryItems.catalog.Max(i => i.itemID) + 1 : 101;
            //this creates the item and tells you it's been created.
            LibraryItems.catalog.Add(new LibraryItems(v1, v2, v3, v4, true));
            Console.WriteLine("Item added."); 
        }

        public static void GatherItems()
        {
            //try copying and altering the code from prev project??
            // validate Y/N answer
            while (true)
            {
                Console.Write("Would you like to gather Items? (Y/N): ");
                string orderBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (orderBOOL == "Y")
                {
                    // print menu per loop
                    LibraryItems.ViewCatalog();

                    // ask for item ID w/ validation
                    while (true)
                    {
                        Console.WriteLine("what Item would you like? (select by Item ID)");
                        string gatherStr = Console.ReadLine();
                        if (!int.TryParse(gatherStr, out int gatheredItem))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        if (gatheredItem == 0)
                        {
                            Console.WriteLine("Order cancelled.");
                            break;
                        }

                        //actual item adding code
                        
                        var product = LibraryItems.catalog.FirstOrDefault(p => p.itemID == gatheredItem); //note:FirstOrDefault returns the first element that satisfies the condition, or a default if it doesn't exist
                        if (product != null)
                        {
                            Console.WriteLine($"\nFound Item: {product.itemName} Media type: {product.mediaType}  Late fee: {product.lateFee}");
                        }
                        else
                        {
                            Console.WriteLine($"\nNo product found with Id {gatheredItem}");
                            continue;
                        }

                        if (product.available)
                        {
                            Console.WriteLine($"You selected item {gatheredItem} -- Item Available! Now gathered.");
                            Gathered.Add(product.itemID);
                            product.toggleAvailability();
                        }
                        else
                        {
                            Console.WriteLine($"You selected item {gatheredItem} -- Item Unavailable! select a different item or exit.");
                        }

                            break;
                    }
                    //actually exit this time
                    break;
                }
                else if (orderBOOL == "N")
                {
                    Console.WriteLine("Nothing gathered.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' or 'N'.");
                    continue;
                }
            }
            //ADD A GATHERED LIST PRINT COMMAND AT THE END ONCE IT'S WRITTEN
        }

        public static void ViewGathered()
        {
            foreach (var id in Gathered)
            {
                var item = LibraryItems.catalog.FirstOrDefault(i => i.itemID == id);
                //Console.WriteLine(item != null ? item.itemName : $"Missing item {id} {item.itemName} Media type: {item.mediaType}  Late fee: {item.lateFee}  ");
                Console.WriteLine($" {id}. {item.itemName}   Media type: {item.mediaType}  Late fee: {item.lateFee}");
            }
            Console.WriteLine("    ");
        }

        public static void ReturnGathered()
        {
            

            // validate Y/N answer 
            while (true)
            {
                Console.Write("Would you like to return a gathered item? (Y/N): ");
                string orderBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (orderBOOL == "Y")
                {
                    // print cart for each loop
                    ViewGathered();

                    // ask item number w/ validation
                    while (true)
                    {
                        Console.Write("What would you like to return?? (input item ID, or 0 to cancel): ");
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

                        var product = LibraryItems.catalog.FirstOrDefault(p => p.itemID == rmvInput); //note:FirstOrDefault returns the first element that satisfies the condition, or a default if it doesn't exist
                        if (product != null)
                        {
                            Console.WriteLine($"\nFound Item: {product.itemName} Media type: {product.mediaType}  Late fee: {product.lateFee}");
                            Gathered.Remove(product.itemID);
                        }
                        else
                        {
                            Console.WriteLine($"\nNo product found with Id {rmvInput}");
                            continue;
                        }

                        //Console.WriteLine($"Selected: {Gathered[rmvInput]}.");
                        ViewGathered();
                        

                        return;
                        

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

        //putting the checkout list here bc all of the checkout commands start here
        public static List<CheckoutItems> checkoutCatalog = new();
        public static void Checkout()
        {
            //put everything from gathered in checked out
            foreach (var itemID in Gathered)
            {
                var libraryItem = LibraryItems.catalog.FirstOrDefault(i => i.itemID == itemID);
                if (libraryItem != null)
                {
                    CheckoutItems.checkoutCatalog.Add(new CheckoutItems(libraryItem.itemID, libraryItem.itemName, libraryItem.mediaType, libraryItem.lateFee));
                }
            }
            CheckoutItems.ViewCheckout();
            Gathered.Clear();

        }

        public static void ReturnCheckedOut()
        {
            // validate Y/N answer 
            while (true)
            {
                
                Console.Write("Would you like to return a checked out item? (Y/N): ");
                string orderBOOL = Console.ReadLine()?.Trim().ToUpperInvariant();

                if (orderBOOL == "Y")
                {
                    // print cart for each loop
                    CheckoutItems.ViewCheckout();


                    // ask item number w/ validation
                    while (true)
                    {
                        Console.Write("What would you like to return?? (input item ID, or 0 to cancel): ");
                        string rmvInputStr = Console.ReadLine();
                        if (!int.TryParse(rmvInputStr, out int rmvInput))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid ID.");
                            continue;
                        }

                        if (rmvInput == 0)
                        {
                            Console.WriteLine("Return cancelled.");
                            break;
                        }

                        if (rmvInput < 0)
                        {
                            Console.WriteLine("Enter a positive number.");
                            continue;
                        }

                        //product is a reference variable and is unique, no need to specify by ID
                        var product = CheckoutItems.checkoutCatalog.FirstOrDefault(p => p.ItemID == rmvInput); //note:FirstOrDefault returns the first element that satisfies the condition, or a default if it doesn't exist
                        if (product != null)
                        {
                             decimal totalfee = CheckoutItems.CalcLateFeeTotal();
                            Console.WriteLine($"\nFound Item: {product.ItemName} Media type: {product.MediaType}  Late fee: {product.LateFee:c}  Total fee: {totalfee:c}");
                            CheckoutItems.checkoutCatalog.Remove(product);
                            
                            
                        }
                        else
                        {
                            Console.WriteLine($"\nNo product found with Id {rmvInput}");
                            continue;
                        }


                        
                        CheckoutItems.ViewCheckout();


                        return;


                    }
                }
                else if (orderBOOL == "N")
                {
                    Console.WriteLine("Nothing Returned..");
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 'Y' or 'N'.");
                }

            }

        }

        public static void SaveLoadFile()
        {
            /* 
            try to save each trait formatted like 
              ItemID, ItemName | MediaType | LateFee | CheckedOutDate | DaysLate
            with a new line per item

            split from pipes "|" using a string.split command

            Tell it to load it separating attributes by commas, and objects by new lines (how? idk we'll learn)
             */
            string ItmFileType = "txt";
            string ItmFileName = "Checkout_File";
            string Itempath = $@"{ItmFileName}.{ItmFileType}";
            


            Console.WriteLine("Save or Load Checkout file? (Type S or L)");
            string SaveORLoad = Console.ReadLine()?.Trim().ToUpperInvariant();

            if (SaveORLoad == "S")
            {
                
                //code to save to file
                foreach( var item in CheckoutItems.checkoutCatalog)
                {
                   File.AppendAllText(Itempath, item.FormatItem() + Environment.NewLine); //saves the Checkout into the txt file and tacks a new line
                }
                if (File.Exists(Itempath))
                {
                    Console.WriteLine("Cart Items file created.");
                }
                else
                {
                    Console.WriteLine("Cart Items file NOT created. Make sure to check out before creating the file.");
                }

            }
            else if(SaveORLoad == "L")
            {
                //code to load file

                try
                {

                    var FileItems = File.ReadAllLines(Itempath);
                    foreach (var line in FileItems)
                    {
                        string[] parts = line.Split('|');  // split line on '|'
                        var item = new CheckoutItems();    // create ONE item per line

                        foreach (var part in parts)
                        {
                            string[] keyValue = part.Split(':');
                            if (keyValue.Length < 2) continue; // skip malformed entries

                            string key = keyValue[0].Trim(); //e.g. "ID" or "Item Name"
                            string value = keyValue[1].Trim(); //e.g. "101" or "Basics of Reading"

                            switch (key)  //this maps each value into its proper attribute, making sure the id goes in id, name in name, and so on
                            {
                                case "ID":
                                    item.ItemID = int.Parse(value);
                                    break;
                                case "Item":
                                    item.ItemName = value;
                                    break;
                                case "Media Type":
                                    item.MediaType = value;
                                    break;
                                case "Late Fee":
                                    item.LateFee = double.Parse(value,
                                        System.Globalization.NumberStyles.Currency);
                                    break;
                                case "Days Late":
                                    item.DaysLate = int.Parse(value);
                                    break;
                            }
                        }

                        CheckoutItems.checkoutCatalog.Add(item); //add after filling all fields
                        //print the added lines
                        Console.WriteLine($"{item.ItemID}, {item.ItemName}, {item.MediaType}, {item.LateFee}, {item.DaysLate}");
                    }
                }

                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Error: File '{Itempath}' not found.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        
            else
            {
                Console.WriteLine("invalid input. Try again.");
            }
        }


    }
}
