using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Core.Entities.Business
{
    public class Type
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

}