namespace Color_Maker;

public partial class MainPage : ContentPage
{
	bool isRandom = false;
	string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

	private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if(isRandom == false)
		{
			var red = sldRed.Value;
			var green = sldGreen.Value;
			var blue = sldBlue.Value;

			Color color = Color.FromRgb(red, green, blue);

			SetColor(color);
		}
	}

	private void SetColor(Color color)
	{
		Container.BackgroundColor = color;
		hexValue = color.ToHex();
		lblHex.Text = hexValue;
	}

	private void btnRandom_Clicked(object sender, EventArgs e)
	{
		isRandom = true;

		var random = new Random();
		
		var color = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));

		SetColor(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;

		isRandom = false;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.Default.SetTextAsync(hexValue);
		await DisplayAlert("Clipboard", "Your color has been copied", "Acept");
	}
}

