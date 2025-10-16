namespace CalculadoraApp;

public partial class MainPage : ContentPage
{
    string currentEntry = "";

    public MainPage()
    {
        InitializeComponent();
    }

    // Cuando se hace clic en un número o símbolo
    void OnButtonClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        string value = button.Text;

        currentEntry += value;
        EntryOperacion.Text = currentEntry;
    }

    // Botón AC (limpiar todo)
    void OnClearClicked(object sender, EventArgs e)
    {
        currentEntry = "";
        EntryOperacion.Text = "";
        LabelResultado.Text = "";
    }

    // Botón borrar último carácter (⌫)
    void OnBackspaceClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(currentEntry))
        {
            currentEntry = currentEntry.Substring(0, currentEntry.Length - 1);
            EntryOperacion.Text = currentEntry;
        }
    }

    // Botón igual (=)
    void OnEqualClicked(object sender, EventArgs e)
    {
        try
        {
            // Reemplazar símbolos por equivalentes de C#
            string expression = currentEntry
                .Replace("÷", "/")
                .Replace("X", "*");

            double result = EvaluateExpression(expression);
            LabelResultado.Text = result.ToString();
        }
        catch
        {
            LabelResultado.Text = "Error";
        }
    }

    // Evaluador simple de expresiones usando DataTable
    double EvaluateExpression(string expression)
    {
        var table = new System.Data.DataTable();
        object value = table.Compute(expression, "");
        return Convert.ToDouble(value);
    }
}