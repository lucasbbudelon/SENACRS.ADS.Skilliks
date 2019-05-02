using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contracts.Repository
{
    public interface IMigration
    {
        string Up();
        string Down();
    }
}
