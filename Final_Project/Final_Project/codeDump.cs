using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project
{
    internal class codeDump
    {
        //        Console.WriteLine("What is the name of the item?");
        //            string v2 = Console.ReadLine()?.Trim();
        //            while (string.IsNullOrEmpty(v2))
        //            {
        //                Console.Write("Name cannot be empty. Enter name: ");
        //                v2 = Console.ReadLine()?.Trim();
        //        Console.WriteLine($"{v2}");
        //            }
        //    Console.WriteLine("What the type of media?");
        //            string v3 = Console.ReadLine()?.Trim();
        //            while (string.IsNullOrEmpty(v3))
        //            {
        //                Console.WriteLine("What the type of media?");
        //                v3 = Console.ReadLine()?.Trim();
        //    Console.WriteLine($"{v3}");
        //            }
        //Console.WriteLine("What is the Late fee?");
        //string input = Console.ReadLine();
        //int.TryParse(input, out int latefeeInput);
        //while (string.IsNullOrEmpty(v3))
        //{
        //    if (latefeeInput <= 1.00)
        //        Console.WriteLine("What is the Late fee?");
        //    string Feeinput = Console.ReadLine();
        //    int.TryParse(input, out int v4);
        //    Console.WriteLine($"{v4}");
        //}



        //        Console.WriteLine("What is the Late fee (e.g. 0.25)?");
        //        decimal lateFee;
        //        string feeInput = Console.ReadLine()?.Trim();
        //    // repeat until parse succeeds and fee is non-negative (adjust range as needed)
        //    while (!decimal.TryParse(feeInput, out lateFee) || lateFee< 0m)
        //    {
        //        Console.Write("Invalid fee. Enter a numeric late fee (e.g. 0.25): ");
        //        feeInput = Console.ReadLine()?.Trim();
        //    }
        //    Console.WriteLine($"{lateFee:C}");

        //    // Example: add the new item to catalog (ensure you have an ID generation strategy)
        //    int newId = LibraryItems.catalog.Any() ? LibraryItems.catalog.Max(i => i.itemID) + 1 : 101;
        //    LibraryItems.catalog.Add(new LibraryItems(newId, v2, v3, lateFee, true));
        //    Console.WriteLine("Item added.");
        //}




        //  //gather the actual item from the number input
        //  Console.WriteLine($"You selected item #{itemInput}. {ShopItems[itemInput - 1]}.");


        //  //Qty and price 
        //  Console.Write("How many?: ");
        //  string qtyStr = Console.ReadLine();
        //  int.TryParse(qtyStr, out int qty);

        //  float QTYprice = ShopPrices[itemInput - 1] * qty;
        //  float RoundQTYprice = (float)Math.Round(QTYprice);
        //  //print current order
        //  Console.WriteLine($"current order: {ShopItems[itemInput - 1]} for ${ShopPrices[itemInput - 1]:0.00} each x{qty} for a total of ${RoundQTYprice:0.00}");


        ////add it to cart
        //CartItems.Add(ShopItems[itemInput - 1]);
        //CartPrices.Add(ShopPrices[itemInput - 1]);




        //static void SaveLoadFile()
        //{
        //    string ItmFileType = "txt";
        //    string ItmFileName = "CartItems_File";
        //    string Itempath = $@"{ItmFileName}.{ItmFileType}";

        //    string PrcFileType = "txt";
        //    string PrcFileName = "CartPrices_File";
        //    string Pricepath = $@"{PrcFileName}.{PrcFileType}";

        //    string QtyFileType = "txt";
        //    string QtyFileName = "CartQty_File";
        //    string Qtypath = $@"{QtyFileName}.{QtyFileType}";

        //    Console.WriteLine("Save or Load file? (Type S or L)");
        //    string SaveORLoad = Console.ReadLine()?.Trim().ToUpperInvariant();

        //    if (SaveORLoad == "S")
        //    {
        //        Console.WriteLine("Would you like to save current cart to a file? (Y/N)");
        //        //saving items to file
        //        File.WriteAllLines(Itempath, CartItems);

        //        //saving prices to file
        //        // I have to turn it into a string ig?
        //        List<string> prcASstr = new List<string>();
        //        foreach (float f in CartPrices)
        //        {
        //            prcASstr.Add(f.ToString("0.00"));
        //        }
        //        File.WriteAllLines(Pricepath, prcASstr);

        //        //saving qty to file
        //        List<string> qtyASstr = new List<string>();
        //        foreach (float f in CartQty)
        //        {
        //            qtyASstr.Add(f.ToString());
        //        }
        //        File.WriteAllLines(Qtypath, qtyASstr);

        //        //check for file's existence
        //        if (File.Exists(Itempath))
        //        {
        //            Console.WriteLine("Cart Items file created.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Cart Items file NOT created.");
        //        }

        //        if (File.Exists(Pricepath))
        //        {
        //            Console.WriteLine("Cart Prices file created.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Cart Prices file NOT created.");
        //        }

        //        if (File.Exists(Qtypath))
        //        {
        //            Console.WriteLine("Cart Qty file created.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Cart Qty file NOT created.");
        //        }
        //    }
        //    else if (SaveORLoad == "L")
        //    {

        //    }
        //    else
        //    {
        //        Console.WriteLine("invalid input. Try again.");
        //    }



        //    //Load File

        //    if (!File.Exists(Itempath) || !File.Exists(Pricepath) || !File.Exists(Qtypath))
        //    {
        //        Console.WriteLine("One or more cart files are missing. Cannot load.");
        //        return;
        //    }

        //    // Read files once (not inside a loop)
        //    var FileItems = File.ReadAllLines(Itempath).ToList();
        //    var FilePrices = File.ReadAllLines(Pricepath);
        //    var FileQty = File.ReadAllLines(Qtypath);

        //    // Parse prices (try invariant then fallback)
        //    var loadedPrices = new List<float>();
        //    foreach (var line in FilePrices)
        //    {
        //        if (float.TryParse(line, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var p) ||
        //            float.TryParse(line, out p))
        //        {
        //            loadedPrices.Add(p);
        //        }
        //        else
        //        {
        //            loadedPrices.Add(0f);
        //        }
        //    }

        //    // Parse variables
        //    var loadedQty = new List<int>();
        //    foreach (var line in FileQty)
        //    {
        //        if (int.TryParse(line, out var q))
        //            loadedQty.Add(q);
        //        else
        //            loadedQty.Add(0);
        //    }

        //    // Align lists: use shortest length to keep entries consistent
        //    int minCount = Math.Min(FileItems.Count, Math.Min(loadedPrices.Count, loadedQty.Count));

        //    CartItems.Clear();
        //    CartPrices.Clear();
        //    CartQty.Clear();

        //    for (int i = 0; i < minCount; i++)
        //    {
        //        CartItems.Add(FileItems[i]);
        //        CartPrices.Add(loadedPrices[i]);
        //        CartQty.Add(loadedQty[i]);
        //    }

        //    Console.WriteLine($"Loaded {minCount} items into the cart.");
        //    ViewCart();
        //    return;
        //}
    }
}
