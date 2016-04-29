using System.Collections.Generic;

namespace HomeWork10.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }
        
        public List<AdvertEntity> Adverts { get; set; }
    }
} 