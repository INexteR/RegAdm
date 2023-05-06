using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Proxies
{
    public class ClientProxy : IdProxy<ClientDTO>
    {
        public string FullName => Data.FullName;

        public DateOnly BirthDate => Data.BirthDate;

        public string Seria => Data.Seria;

        public string Number => Data.Number;

        public string Phone => Data.Phone;

        public ClientProxy(ClientDTO client) : base(client.Id, client) { }
    }
}
