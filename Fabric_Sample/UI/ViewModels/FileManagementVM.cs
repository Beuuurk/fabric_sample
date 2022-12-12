using Fabric.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fabric_Sample.UI.ViewModels
{
    public class FileManagementVM : ViewModel
    {
        private ICollection<string> _files;
        private ICommand _quitCommand;

        public ICollection<string> Files
        {
            get { return Get(ref _files); }
            set { Set(ref _files, value); }
        }

        public ICommand QuitCommand
        {
            get { return _quitCommand ?? new CommandHandler(OnQuitCommand); }
        }

        public FileManagementVM()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            _files = new List<string>();
            string[] fileList = Directory.GetFiles(".", "*.*", SearchOption.TopDirectoryOnly);
            fileList.ToList().ForEach(x => _files.Add(Path.GetFileName(x)));
        }

        private void OnQuitCommand(object obj)
        {
            FrameworkApplication.Instance.HostApplication.Shutdown();
        }
    }
}
