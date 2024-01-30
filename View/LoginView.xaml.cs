using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF1.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public static string[] lines = { "DR Kongo, Regenwald, Fufu,n,Warm",
                "Frankreich,Berge/Küsten,Croissant,y,gemäßigt",
                "Kanada,Berge/Ebenen, Poutine,y,Wechselhaft",
                "Madagaskar, Regenwald/Grasland, Romazava,y,Warm",
                "Elfenbeinküste, Küstenebenen/Regenwald, Attiéké,y,Warm",
                "Kamerun, Regenwald/Savanne, Ndolé,y,Warm",
                "Niger, Wüste/Savanne, Jollof Reis,n,Warm",
                "Mali, Wüste/Savanne, Tieboudienne,n,Warm",
                "Burkina Faso, Savanne/Plateaus, Riz gras,n,Warm",
                "Tschad, Wüste/Savanne, Boule,n,Warm",
                "Senegal, Sahel/Savanne, Thieboudienne,y,Warm",
                "Guinea, Regenwald/Savanne, Maafe,y,Warm",
                "Ruanda, Berge/Plateaus, Ugali,n,Warm",
                "Benin, Küstenebenen/Savanne, Fufu,y,Warm",
                "Burundi, Plateaus/Hochländer, Bohnen und Reis,n,Warm",
                "Haiti, Berge/Küsten, Griot,y,Warm",
                "Belgien, Ebenen/Hügel, Belgische Waffeln,y,gemäßigt",
                "Togo, Küstenebenen/Plateaus, Fufu,y,warm",
                "Schweiz, Berge/Plateaus, Fondue,n, gemäßigt",
                "Republik Kongo, Regenwald/Savanne, Moambe,y,warm",
                "Zentralafrikanische Republik, Regenwald/Savanne, Maniok,n,warm",
                "Gabun, Regenwald/Küstenebenen, Nyembwe,y,warm",
                "Äquatorialguinea, Regenwald/Küstenebenen, Maniokbrot,y,warm",
                "Dschibuti, Wüste/Küste, Skoudehkaris,y,warm",
                "Réunion, Vulkaninsel, Rougail,y, gemäßigt",
                "Komoren, Vulkaninseln, Langouste a la vanille,y,Warm",
                "Luxemburg, bewaldete Hügel/Plateaus, Judd mat Gaardebounen,n, gemäßigt",
                "Guadeloupe, Regenwald/Küsten, Accras,y,Warm",
                "Martinique, Berge/Küsten, Colombo,y,Warm",
                "Mayotte, Vulkaninsel, Pilao,y,Warm",
                "Vanuatu, Vulkaninseln, Lap Lap,y, gemäßigt",
                "Französisch-Guayana, Regenwald/Küste, Bouillon d'Aoura,y,Warm",
                "Französisch-Polynesien, Vulkaninseln/Atolle, Poisson Cru,y,Warm",
                "Neukaledonien, Korallenriffe/Berge, Bougna,y, gemäßigt",
                "Jersey, Küstenebenen/Hügel, Jersey Royal Potatoes,y, gemäßigt",
                "Seychellen, Koralleninseln, Oktopus-Curry,y,Warm",
                "Monaco, urban/Küste, Barbagiuan,y,Warm",
                "Saint-Martin, Küstenebenen/Hügel, Conch,y,Warm",
                "Wallis und Futuna, Vulkaninseln, Ufi,y, gemäßigt",
                "Saint-Barthélemy, Küstenebenen/Hügel, Accras,y,Warm",
                "Saint-Pierre und Miquelon, Küstenebenen/Inseln, Gravlax,y, gemäßigt"};
        public static Dictionary<string, List<string>> countriesAndAttributes = new Dictionary<string, List<string>>();
        public static Dictionary<string, Int32> countryScores = new Dictionary<string, Int32>();
        public static string currentKlimaButton = "";
        private void getCountries(string landschaft, string klima, bool strand)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                countriesAndAttributes[lines[i].Split(',')[0]] = new List<string> { lines[i].Split(',')[1], lines[i].Split(',')[2], lines[i].Split(',')[3], lines[i].Split(',')[4] };
            }            
            
            //Rate the matches

            foreach (KeyValuePair<string, List<string>> entry in countriesAndAttributes)
            {
                //Console.WriteLine($"{{{entry.Key}, {{{entry.Value[0]},{entry.Value[1]},{entry.Value[2]},{entry.Value[3]}}}}}");       //print all entrys
                countryScores[entry.Key] = 0;

                //check if the landscape matches
                if (entry.Value[0].ToLower().Contains(landschaft.ToLower()))
                {
                    countryScores[entry.Key] += 2;
                }
                //check if the beach option matches
                if (strand)
                {
                    if (entry.Value[2].ToLower().Contains("y"))
                    {
                        countryScores[entry.Key] += 2;
                    }
                }
                else
                {
                    if (entry.Value[2].ToLower().Contains("n"))
                    {
                        countryScores[entry.Key] += 2;
                    }
                }
                //check if the climate option matches
                switch (klima)
                {
                    case "warm":
                        if (entry.Value[3].ToLower().Contains("warm"))
                        {
                            countryScores[entry.Key] += 2;
                        }
                        break;
                    case "gemässigt":
                        if (entry.Value[3].ToLower().Contains("gemäßigt"))
                        {
                            countryScores[entry.Key] += 2;
                        }
                        break;
                    case "kalt":
                        if (entry.Value[3].ToLower().Contains("kalt"))
                        {
                            countryScores[entry.Key] += 2;
                        }
                        break;
                    case "wechselhaft":
                        if (entry.Value[3].ToLower().Contains("wechselhaft"))
                        {
                            countryScores[entry.Key] += 2;
                        }
                        break;
                }
            }
            //find the country with the highest rating
            // Create a list of key-value pairs
            List<KeyValuePair<string, int>> sortedList = countryScores.ToList();

            // Sort the list based on the values
            sortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            // Create a new sorted dictionary
            Dictionary<string, int> sortedDictionary = sortedList.ToDictionary(x => x.Key, x => x.Value);

            // Display the sorted dictionary
            var keysWithCertainValues = sortedList.Where(pair => pair.Value == sortedList[0].Value).Select(pair => pair.Key).ToList();


            int j = 0;
            foreach (var v in keysWithCertainValues)
            {
                if (j >= 6)
                {
                    break;
                }
                switch (j)
                {
                    case 0:
                        Land1Name.Text = v;
                        Land1Landschaft.Text = countriesAndAttributes[v][0];
                        if (countriesAndAttributes[v][2].ToLower() == "y")
                        {
                            Land1Strand.Text = "Hat Strand";
                        }
                        else
                        {
                            Land1Strand.Text = "Hat keinen Strand";
                        }
                        Land1Klima.Text = countriesAndAttributes[v][3];
                        Land1Essen.Text = countriesAndAttributes[v][1];
                        break;
                    case 1:
                        Land2Name.Text = v;
                        Land2Landschaft.Text = countriesAndAttributes[v][0];
                        if (countriesAndAttributes[v][2].ToLower() == "y")
                        {
                            Land2Strand.Text = "Hat Strand";
                        }
                        else
                        {
                            Land2Strand.Text = "Hat keinen Strand";
                        }
                        Land2Klima.Text = countriesAndAttributes[v][3];
                        Land2Essen.Text = countriesAndAttributes[v][1];
                        break;
                    case 2:
                        Land3Name.Text = v;
                        Land3Landschaft.Text = countriesAndAttributes[v][0];
                        if (countriesAndAttributes[v][2].ToLower() == "y")
                        {
                            Land3Strand.Text = "Hat Strand";
                        }
                        else
                        {
                            Land3Strand.Text = "Hat keinen Strand";
                        }
                        Land3Klima.Text = countriesAndAttributes[v][3];
                        Land3Essen.Text = countriesAndAttributes[v][1];
                        break;
                    case 3:
                        Land4Name.Text = v;
                        Land4Landschaft.Text = countriesAndAttributes[v][0];
                        if (countriesAndAttributes[v][2].ToLower() == "y")
                        {
                            Land4Strand.Text = "Hat Strand";
                        }
                        else
                        {
                            Land4Strand.Text = "Hat keinen Strand";
                        }
                        Land4Klima.Text = countriesAndAttributes[v][3];
                        Land4Essen.Text = countriesAndAttributes[v][1];
                        break;
                    case 4:
                        Land5Name.Text = v;
                        Land5Landschaft.Text = countriesAndAttributes[v][0];
                        if (countriesAndAttributes[v][2].ToLower() == "y")
                        {
                            Land5Strand.Text = "Hat Strand";
                        }
                        else
                        {
                            Land5Strand.Text = "Hat keinen Strand";
                        }
                        Land5Klima.Text = countriesAndAttributes[v][3];
                        Land5Essen.Text = countriesAndAttributes[v][1];
                        break;
                    case 5:
                        Land6Name.Text = v;
                        Land6Landschaft.Text = countriesAndAttributes[v][0];
                        if (countriesAndAttributes[v][2].ToLower() == "y")
                        {
                            Land6Strand.Text = "Hat Strand";
                        }
                        else
                        {
                            Land6Strand.Text = "Hat keinen Strand";
                        }
                        Land6Klima.Text = countriesAndAttributes[v][3];
                        Land6Essen.Text = countriesAndAttributes[v][1];
                        break;
                        
                }
                j++;
            }
            j = 0;
        }
       
        private void Windows_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) { DragMove(); }
          
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void landschaftDropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), "y", true);
            if (landschaftDropdown.SelectedItem != null)
            {
                Land1Landschaft.Text = (landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString();
            }


        }
        private void refreshText()
        {
            Console.WriteLine("hi");
          
        }

        private void StrandJaButton_Checked(object sender, RoutedEventArgs e)
        {
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), currentKlimaButton, true);
        }

        private void StrandNeinButton_Checked(object sender, RoutedEventArgs e)
        {
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), currentKlimaButton, false);
        }

        private void KaltButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton clickedButton = (RadioButton)sender;
            string buttonText = clickedButton.Content.ToString();
            currentKlimaButton = buttonText;
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), currentKlimaButton, false);
            
        }

        private void GemaessigtButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton clickedButton = (RadioButton)sender;
            string buttonText = clickedButton.Content.ToString();
            currentKlimaButton = buttonText;
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), currentKlimaButton, false);
        }

        private void WarmButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton clickedButton = (RadioButton)sender;
            string buttonText = clickedButton.Content.ToString();
            currentKlimaButton = buttonText;
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), currentKlimaButton, false);
        }

        private void WechselhaftButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton clickedButton = (RadioButton)sender;
            string buttonText = clickedButton.Content.ToString();
            currentKlimaButton = buttonText;
            getCountries((landschaftDropdown.SelectedItem as ComboBoxItem)?.Content.ToString(), currentKlimaButton, false);

        }
        
    }
}
