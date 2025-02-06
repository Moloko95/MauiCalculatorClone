using System;
using Microsoft.Maui.Controls;

namespace MauiCalculatorClone;

public partial class MainPage : ContentPage
{
    private string currentEntry = "";
    private string operation = "";
    private double firstNumber = 0;
    private bool isNewEntry = true;

    public MainPage()
    {
        InitializeComponent();
    }

    // Handles number button clicks
    private void OnDigitClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string digit = button.Text;

        if (isNewEntry)
        {
            currentEntry = digit;
            isNewEntry = false;
        }
        else
        {
            currentEntry += digit;
        }

        DisplayLabel.Text = currentEntry;
    }

    // Handles operator button clicks (+, -, ×, ÷)
    private void OnOperatorClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        operation = button.Text;
        firstNumber = Convert.ToDouble(currentEntry);
        isNewEntry = true;
    }

    // Handles the equals (=) button click
    private void OnEqualsClicked(object sender, EventArgs e)
    {
        double secondNumber = Convert.ToDouble(currentEntry);
        double result = 0;

        switch (operation)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;
            case "-":
                result = firstNumber - secondNumber;
                break;
            case "×":
                result = firstNumber * secondNumber;
                break;
            case "÷":
                result = secondNumber != 0 ? firstNumber / secondNumber : 0;
                break;
        }

        DisplayLabel.Text = result.ToString();
        currentEntry = result.ToString();
        isNewEntry = true;
    }

    // Clears everything
    private void OnClearClicked(object sender, EventArgs e)
    {
        currentEntry = "0";
        firstNumber = 0;
        operation = "";
        DisplayLabel.Text = "0";
        isNewEntry = true;
    }

    // Handles decimal button click
    private void OnDecimalClicked(object sender, EventArgs e)
    {
        if (!currentEntry.Contains("."))
        {
            currentEntry += ".";
            DisplayLabel.Text = currentEntry;
        }
    }

    // Handles percentage button click
    private void OnPercentClicked(object sender, EventArgs e)
    {
        double value = Convert.ToDouble(currentEntry) / 100;
        DisplayLabel.Text = value.ToString();
        currentEntry = value.ToString();
    }

    // Handles negate button (+/-)
    private void OnNegateClicked(object sender, EventArgs e)
    {
        double value = Convert.ToDouble(currentEntry) * -1;
        DisplayLabel.Text = value.ToString();
        currentEntry = value.ToString();
    }
}
