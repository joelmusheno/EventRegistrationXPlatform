using System;
namespace SoS.Models
{
    public class Session : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
