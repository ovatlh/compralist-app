using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using xamarinCompraList.Helpers;

namespace xamarinCompraList.Models
{
    public class compralistContext : INotifyPropertyChanged
    //public class compralistContext
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Actualizar([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        public string hostURL { get; set; }
        public string Username { get; set; }
        public HubConnection hubConnection;
        //public List<Item> ListItems_Base { get; set; }
        //public ObservableCollection<Item> ListItems_Obs { get; set; }
        //public List<Item> ListItems { get; set; }
        //public ObservableCollection<Item> ListItems { get; set; }

        //public SortableObservableCollection<Item> ListItems { get; set; }
        //private SortableObservableCollection<Item> listItems;

        //public SortableObservableCollection<Item> ListItems
        //{
        //    get { return listItems; }
        //    set { listItems = value; }
        //}

        private ObservableCollection<Item> listItems;

        public ObservableCollection<Item> ListItems
        {
            get { return listItems; }
            set { listItems = value; Actualizar(); }
        }
        //private List<Item> listItems;

        //public List<Item> ListItems
        //{
        //    get { return listItems; }
        //    set { listItems = value; Actualizar(); }
        //}

        //private ObservableCollection<Item> listItems;

        //public ObservableCollection<Item> ListItems
        //{
        //    //get { return listItems; }
        //    //set {
        //    //    listItems = listItems != null ? new ObservableCollection<Item>((from item in ListItems orderby item.Listo, item.Id descending select item).ToList()) : value;
        //    //}

        //    get 
        //    { 
        //        return new ObservableCollection<Item>((from item in listItems orderby item.Listo, item.Id descending select item).ToList()); 
        //    }
        //    set { listItems = value; }
        //}

        public compralistContext()
        {
            //hostURL = "https://compralist-web.conveyor.cloud/";
            hostURL = "https://compralist.itesrc.net/";
            //ListItems_Base = new List<Item>
            //{
            //    new Item { Id = 1, Listo = false, Nombre = "1kg de Papas", Quienloagrego = "Tavo" },
            //    new Item { Id = 2, Listo = false, Nombre = "Jamon", Quienloagrego = "Tavo" },
            //    new Item { Id = 3, Listo = false, Nombre = "Tomates", Quienloagrego = "Tavo" },
            //    new Item { Id = 4, Listo = true, Nombre = "Harina", Quienloagrego = "Tavo" }
            //};
            ListItems = new ObservableCollection<Item> { };

            hubConnection = new HubConnectionBuilder().WithUrl($"{hostURL}/compraListHub").Build();

            hubConnection.StartAsync();

            hubConnection.Closed += async (error) =>
            {
                Thread.Sleep(1000);
                await hubConnection.StartAsync();
                //await ServerConnection();
            };

            hubConnection.On<IEnumerable<Item>>("ReceiveMessage", (list) => {
                //CompralistContext.Reset_AllItems(list);
                LoadData();
            });

            LoadData();

            //ListItems = new ObservableCollection<Item>
            //{
            //    //new Item { Id = 1, Listo = false, Nombre = "1kg de Papas", Quienloagrego = "Tavo" },
            //    //new Item { Id = 2, Listo = false, Nombre = "Jamon", Quienloagrego = "Tavo" },
            //    //new Item { Id = 3, Listo = false, Nombre = "Tomates", Quienloagrego = "Tavo" },
            //    //new Item { Id = 4, Listo = true, Nombre = "Harina", Quienloagrego = "Tavo" },
            //    //new Item { Id = 5, Listo = false, Nombre = "1 celular", Quienloagrego = "Tavo" }
            //};
            //ListItems = (ObservableCollection<Item>)ListItems.OrderBy(x => x.Listo ? 0 : 1);
            //var result = (from item in ListItems orderby item.Listo select item).ToList();
            //ListItems.Clear();
            //foreach (var item in result)
            //{
            //    ListItems.Add(item);
            //}
            //ListItems = ListItems.OrderBy(x => x.Listo).ToList();
            //ListItems = new ObservableCollection<Item>((from item in ListItems orderby item.Listo select item).ToList());
            //ListItems = new SortableObservableCollection<Item>();
            //ListItems.Add(new Item { Id = 1, Listo = false, Nombre = "false 1", Quienloagrego = "Tavo" });
            //ListItems.Add(new Item { Id = 1, Listo = true, Nombre = "true 1", Quienloagrego = "Tavo" });
            //ListItems.Add(new Item { Id = 1, Listo = false, Nombre = "false 2", Quienloagrego = "Tavo" });
            List_OrderBy();
        }

        public void List_OrderBy()
        {
            //ListItems.Sort(x => x.Listo, ListSortDirection.Ascending);
            ListItems = new ObservableCollection<Item>((from item in ListItems orderby item.Listo, item.Id descending select item).ToList());
            //ListItems_Base = ListItems_Base.OrderBy(x => x.Listo).ThenBy(x => x.Nombre).ToList();
            //ListItems_Obs = new ObservableCollection<Item>(ListItems_Base);
        }

        public void Items_LoadAll()
        {
            List_OrderBy();
        }

        public void Item_Load()
        {

        }

        public void Reset_AllItems(List<Item> items)
        {
            ListItems = new ObservableCollection<Item>((from item in items orderby item.Listo, item.Id descending select item).ToList());
        }

        public async void Item_Add(string itemcontent, string username)
        {
            //var result = from item in ListItems orderby item.Id descending select item.Id;
            //int result = ListItems.Count > 0 ? ListItems.OrderByDescending(x => x.Id).FirstOrDefault().Id : 1;
            //ListItems.Add(new Item
            //{
            //    Id = result + 1,
            //    Listo = false,
            //    Nombre = itemcontent,
            //    Quienloagrego = username
            //});

            //int result = ListItems_Obs.Count > 0 ? ListItems_Obs.OrderByDescending(x => x.Id).FirstOrDefault().Id : 1;
            //ListItems_Base.Add(new Item
            //{
            //    Id = result + 1,
            //    Listo = false,
            //    Nombre = itemcontent,
            //    Quienloagrego = username
            //});
            //List_OrderBy();
            //Item new_item = new Item()
            //{
            //    Nombre = itemcontent,
            //    QuienAgrego = username
            //};

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(hostURL);

            string formdata = @"{""nombre"" : """ + itemcontent + @""", ""quienagrego"" : """ + username + @"""}";
            //string jsonData = @"{""nombre"" : """", ""quienagrego"" : """"}";

            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var content = new StringContent(new_item.ToString(), Encoding.UTF8, "application/json");
            var content = new StringContent(formdata, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/home/createitem", content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(result))
            {
                await App.Current.MainPage.DisplayAlert("Atencion", result, "Ok");
            }
            else
            {
                await hubConnection.InvokeAsync("SyncronizeItems");
            }
        }

        public async void Item_Delete(Item item)
        {
            //ListItems.Remove(item);
            //ListItems_Base.Remove(item);
            //List_OrderBy();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(hostURL);

            //string formdata = @"{""nombre"" : """ + itemcontent + @""", ""quienagrego"" : """ + username + @"""}";
            //string jsonData = @"{""nombre"" : """", ""quienagrego"" : """"}";

            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var content = new StringContent(new_item.ToString(), Encoding.UTF8, "application/json");
            var content = new StringContent(item.Id.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/home/deleteitem/" + item.Id, content);
            //HttpResponseMessage response2 = await client.PostAsync("/home/changestatus/" + item.Id);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(result))
            {
                await App.Current.MainPage.DisplayAlert("Atencion", result, "Ok");
            }
            else
            {
                await hubConnection.InvokeAsync("SyncronizeItems");
            }
        }

        public async void Item_Complete(Item item, string username)
        {
            //ListItems.FirstOrDefault(x => x.Id == item.Id).Listo = !item.Listo;
            //ListItems.FirstOrDefault(x => x.Id == item.Id).QuienAgrego = username;

            //ListItems_Base.FirstOrDefault(x => x.Id == item.Id).Listo = !item.Listo;
            //ListItems_Base.FirstOrDefault(x => x.Id == item.Id).Quienloagrego = username;

            //List_OrderBy();
            //ListItems = ListItems;

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(hostURL);

            //string formdata = @"{""nombre"" : """ + itemcontent + @""", ""quienagrego"" : """ + username + @"""}";
            //string jsonData = @"{""nombre"" : """", ""quienagrego"" : """"}";

            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var content = new StringContent(new_item.ToString(), Encoding.UTF8, "application/json");
            var content = new StringContent(item.Id.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("/home/changestatus/" + item.Id, content);
            //HttpResponseMessage response2 = await client.PostAsync("/home/changestatus/" + item.Id);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(result))
            {
                await App.Current.MainPage.DisplayAlert("Atencion", result, "Ok");
            }
            else
            {
                await hubConnection.InvokeAsync("SyncronizeItems");
            }
        }

        public async void LoadData()
        {
            HttpClient httpClient = new HttpClient();

            var json = await httpClient.GetAsync($"{hostURL}/home/getitemsall");

            json.EnsureSuccessStatusCode();
            List<Item> lista = JsonConvert.DeserializeObject<List<Item>>(await json.Content.ReadAsStringAsync());

            Reset_AllItems(lista);
        }
    }
}
