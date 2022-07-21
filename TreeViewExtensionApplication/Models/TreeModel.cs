using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewExtensionApplication.Models
{
    public class TreeModel : BindableObject
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TreeModel> Children { get; set; } = new ObservableCollection<TreeModel>();
    }
}
