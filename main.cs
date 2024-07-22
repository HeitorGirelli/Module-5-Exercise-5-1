using System;

class Program {
  public static void Main (string[] args) {

    // User Prompt
    Console.WriteLine("Welcome to Holiday Homes, enter a salesperson initial (D, E, F) or enter \"Z\" to quit: \n");

    // Arrays to store salesperson data
    string[] salespersonNames = { "Danielle", "Edward", "Francis" };
    char[] salespersonInitials = { 'D', 'E', 'F' };
    double[] salesValues = new double[salespersonNames.Length];

    char initial;

    while (true) {

      // Get User's Initial & Make Sure it Reads Both Lowercase and Uppercase
      initial = Char.ToUpper(Console.ReadKey().KeyChar);
      Console.WriteLine("\n");

      // If User Enters Z, Quit Program
      if (initial == 'Z') {
        break;
      }

      // Check if the initial is valid
      int index = Array.IndexOf(salespersonInitials, initial);

      if (index != -1) {

        // Prompt the Sale Amount
        Console.WriteLine("Enter Sales Amount: \n");
        double salesAmount;

        // Validate Sales Amount
        if (Double.TryParse(Console.ReadLine(), out salesAmount) && salesAmount >= 0) {
          // Add Sales Amount to the correct salesperson's total
          salesValues[index] += salesAmount;
        } else {
          Console.WriteLine("Error, invalid sales amount, please enter a valid number.");
        }

      } else {
        // If User Enters Incorrect Letter, Display Error Message
        Console.WriteLine("Error, invalid salesperson selected, please try again");
      }

      // Calculate the Total Sales
      double grandTotal = 0;
      for (int i = 0; i < salesValues.Length; i++) {
        grandTotal += salesValues[i];
      }

      // Determine the Salesperson with the Highest Sales
      int topSalesIndex = 0;
      for (int i = 1; i < salesValues.Length; i++) {
        if (salesValues[i] > salesValues[topSalesIndex]) {
          topSalesIndex = i;
        }
      }

      // Display the Total Sales for Each Salesperson
      Console.WriteLine("\nSales Summary:");
      for (int i = 0; i < salespersonNames.Length; i++) {
        Console.WriteLine($"{salespersonNames[i]} ({salespersonInitials[i]}): ${salesValues[i]}");
      }
      Console.WriteLine($"\nGrand Total: ${grandTotal}");
      Console.WriteLine($"Highest Sale: {salespersonNames[topSalesIndex]} ({salespersonInitials[topSalesIndex]})");
      Console.WriteLine("");
    }
  }
}
