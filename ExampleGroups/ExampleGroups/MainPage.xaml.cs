using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ExampleGroups.App;

namespace ExampleGroups
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var contactos = new List<Contacto>
        {
            new Contacto { Name = "Ana", PhoneNumber = "123-456-7890" },
            new Contacto { Name = "Carlos", PhoneNumber = "234-567-8901" },
            new Contacto { Name = "David", PhoneNumber = "345-678-9012" },
            new Contacto { Name = "Elena", PhoneNumber = "456-789-0123" },
            new Contacto { Name = "Fabiola", PhoneNumber = "567-890-1234" },
            new Contacto { Name = "Gabriel", PhoneNumber = "678-901-2345" }
        };

            contactos = contactos.OrderBy(c => c.Name).ToList();

            var grupos = new List<string>();
            foreach (var contacto in contactos)
            {
                var inicial = contacto.Name.Substring(0, 1);
                if (!grupos.Contains(inicial))
                {
                    grupos.Add(inicial);
                }
            }

            var gruposContactos = contactos
                .GroupBy(c => c.Name.Substring(0, 1))
                .Select(g => new Grouping<string, Contacto>(g.Key, g.ToList()))
                .ToList();

            contactosListView.ItemsSource = gruposContactos;
        }
    }
}
