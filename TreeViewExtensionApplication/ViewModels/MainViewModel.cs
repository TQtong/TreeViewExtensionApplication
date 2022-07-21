using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TreeViewExtensionApplication.Common;
using TreeViewExtensionApplication.Models;

namespace TreeViewExtensionApplication.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<TreeModel> TreeModels { get; set; } = new ObservableCollection<TreeModel>();

        private TreeModel selectItem;

        public TreeModel SelectItem
        {
            get => selectItem;
            set
            {
                selectItem = value;
                Console.WriteLine(SelectItem);
                OnPropertyChanged();
            }
        }

        public DelegateCommand<TreeView> Selected { get; private set; }

        public MainViewModel()
        {
            Selected = new DelegateCommand<TreeView>(Tree_SelectedItemChanged);
            CreateTree();
        }

        private void CreateTree()
        {

            for (int i = 0; i < 5; i++)
            {

                TreeModel treeModel = new TreeModel()
                {
                    Name = $"我是{i}"
                };

                TreeModels.Add(treeModel);

                for (int j = 0; j < 10; j++)
                {
                    treeModel.Children.Add(new TreeModel()
                    {
                        Name = $"我是{i}的{j}个孩子"
                    });
                }
            }
        }

        public void Tree_SelectedItemChanged(TreeView view)
        {
            SelectItem = view.SelectedItem as TreeModel;
        }
    }
}
