using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalDatabaseDS.Models;
using LocalDatabaseDS.SQLite;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LocalDatabaseDS
{
	public partial class MainPage : ContentPage
	{
	    private SQLiteConnection _sqLiteConnection;
        public MainPage()
		{
			InitializeComponent();
        }
      

        protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        RefeshListView();
	    }

	    private async void RefeshListView()
	    {
	        try
	        {
	            _sqLiteConnection = await DependencyService.Get<ISQLite>().GetConnection();
                var listData = _sqLiteConnection.Table<StaffTable>().ToList();
	            MyListView.ItemsSource = listData;
            }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
	        
        }

	    private async void ButtonSave_OnClicked(object sender, EventArgs e)
	    {
	        StaffTable staff = new StaffTable
	        {
	            FullName = EntryFullName.Text,
	            Address = EntryAddress.Text
	        };

	        var result = _sqLiteConnection.Insert(staff);

	        if (result != 0)
	        {
	            RefeshListView();
	        }
	        else
	        {
	            await DisplayAlert("Error!", "Add new guy error!", "Ok");
	        }
        }

	    private void ButtonDelete_OnClicked(object sender, EventArgs e)
	    {
	        try
	        {
	            var staff = MyListView.SelectedItem as StaffTable;

	            var result = _sqLiteConnection.Delete(staff);
                //var result = _sqLiteConnection.Delete<DepartmentTable>(staff);

                if (result != 0)
	            {
	                RefeshListView();
	            }
	        }
	        catch (Exception ex)
	        {

	        }
        }
	}
}
