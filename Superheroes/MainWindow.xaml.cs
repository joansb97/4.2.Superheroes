using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Superheroe> listaSuperheroes;

        public MainWindow()
        {
            InitializeComponent();

            listaSuperheroes = Superheroe.GetSamples();
            superheroeDockPanel.DataContext = listaSuperheroes.FirstOrDefault();
            actualTextBlock.Text = "1";
            totalTextBlock.Text = listaSuperheroes.Count.ToString();
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            listaSuperheroes.Add((Superheroe)this.Resources["nuevo"]);
            MessageBox.Show("Superhéroe insertado con exito", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            totalTextBlock.Text = listaSuperheroes.Count.ToString();
        }

        private void leftImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(actualTextBlock.Text);

            if (actual > 1)
            {
                superheroeDockPanel.DataContext = listaSuperheroes[actual - 2];
                actualTextBlock.Text = (actual - 1).ToString();
            }
        }

        private void rightImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = Int32.Parse(actualTextBlock.Text);

            if (actual < listaSuperheroes.Count)
            {
                superheroeDockPanel.DataContext = listaSuperheroes[actual];
                actualTextBlock.Text = (actual + 1).ToString();
            }
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            nombreTextBox.Clear();
            imagenTextBox.Clear();
            vengadoresCheckBox.IsChecked = false;
            xMenCheckBox.IsChecked = false;
            heroeRadioButton.IsChecked = true;
        }
    }
}
