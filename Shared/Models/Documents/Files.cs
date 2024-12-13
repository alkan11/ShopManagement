using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Documents
{
	public class Files
	{
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Name { get; set; }
        public string Filename { get; set; }
        public string FolderName { get; set; }
        public string Uuid { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
    }
}
