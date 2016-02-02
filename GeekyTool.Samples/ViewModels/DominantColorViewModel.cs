using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GeekyTool.Commands;
using GeekyTool.Common;
using GeekyTool.ViewModels;

namespace GeekyTool.Samples.ViewModels
{
    public class DominantColorViewModel : ViewModelBase
    {
        public DominantColorViewModel()
        {
            ChooseNewPhotoCommand = new DelegateCommandAsync(ChooseNewPhotoCommandDelegate);
        }

        private ImageSource img;
        public ImageSource Img
        {
            get { return img; }
            set
            {
                if (img == value) return;
                img = value;
                OnPropertyChanged();
            }
        }


        private string myColor;
        public string MyColor
        {
            get { return myColor; }
            set
            {
                if (myColor == value) return;
                myColor = value;
                OnPropertyChanged();
            }
        }

        private string myInvertColor;
        public string MyInvertColor
        {
            get { return myInvertColor; }
            set
            {
                if (myInvertColor == value) return;
                myInvertColor = value;
                OnPropertyChanged();
            }
        }

        private async Task ChooseNewPhotoCommandDelegate()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            filePicker.SettingsIdentifier = "picker1";
            filePicker.CommitButtonText = "Open File to Process";

            var file = await filePicker.PickSingleFileAsync();

            MyColor = (await GeekyHelper.GetDominantColor(file)).ToString();
            MyInvertColor = GeekyHelper.InvertColor(MyColor).ToString();

            var base64 = await EncodeHelper.ToBase64(file);
            Img = await EncodeHelper.FromBase64(base64);
        }

        public override Task OnNavigatedFrom(NavigationEventArgs e)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs e)
        {
            return null;
        }

        public ICommand ChooseNewPhotoCommand { get; private set; }
    }
}
